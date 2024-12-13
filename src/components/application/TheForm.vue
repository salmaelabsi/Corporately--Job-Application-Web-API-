<template>
  <base-dialog title="Success" v-if="created && isSubmitted" @close="closePopUp">
    <template #content>
      <h6>Your application has been submitted successfully.</h6>
    </template>
    <template #actions>
      <base-button @click="closePopUp">Okay</base-button>
    </template>
  </base-dialog>

  <base-dialog title="Uploaded" v-if="cvIsUploaded">
    <template #content>
      <h6>Your CV has been uploaded successfully.</h6>
    </template>
  </base-dialog>

  <base-dialog title="Incorrect or missing fields" v-if="inputIsInvalid" @close="incorrectPopUp">
    <template #content>
      <h6>Input fields must contain at least 5 characters!</h6>
    </template>
    <template #actions>
      <base-button @click="incorrectPopUp">Okay</base-button>
    </template>
  </base-dialog>

  <base-dialog title="Unauthorised" v-if="!userIsAuthorized" @close="closePopUp">
    <template #content>
      <h6>You need to log in or sign up to perform this action.</h6>
    </template>
    <template #actions>
      <base-button @click="closePopUp">Okay</base-button>
    </template>
  </base-dialog>

  <base-dialog title="Prohibited" v-if="applicationExists" @close="closePopUp">
    <template #content>
      <h6>You cannot apply to the same job twice.</h6>
    </template>
    <template #actions>
      <base-button @click="closePopUp">Okay</base-button>
    </template>
  </base-dialog>

  <base-dialog title="Unsuccessful" v-if="!created && !appInfoIsValid" @close="closePopUp">
    <template #content>
      <label>Unable to create application.</label>
    </template>
    <template #actions>
      <base-button @click="closePopUp">Close</base-button>
    </template>
  </base-dialog>

  <div class="container">
    <base-card>
      <div>
        <h2>Apply for this position</h2>
      </div>

      <div class="form-control" :class="{invalid: nameValidity === 'invalid'}">
        <label for="name">Name: </label>
        <input v-model.trim="appInfo.name" id="name" name="name" type="text" ref="nameInput" @blur="name_Validity"
               class="border"/>
        <p v-if="nameValidity === 'invalid'">Cannot be empty!</p>
      </div>
      <div class="form-control" :class="{invalid: titleValidity === 'invalid'}">
        <label for="title">Professional Title: </label>
        <input v-model.trim="appInfo.title" id="title" name="title" type="text" ref="titleInput" @blur="title_Validity"
               class="border"/>
        <p v-if="titleValidity === 'invalid'">Cannot be empty!</p>
      </div>
      <div class="form-control" :class="{invalid: addressValidity === 'invalid'}">
        <label for="address">Address: </label>
        <input v-model.trim="appInfo.address" id="address" name="address" type="text" ref="addressInput"
               @blur="address_Validity" class="border"/>
        <p v-if="addressValidity === 'invalid'">Cannot be empty!</p>
      </div>
      <div class="form-control" :class="{invalid: emailValidity === 'invalid'}">
        <label for="email">Email: </label>
        <input v-model.trim="appInfo.email" id="email" name="email" type="text" ref="emailInput" @blur="email_Validity"
               class="border"/>
        <p v-if="emailValidity === 'invalid'">Cannot be empty!</p>
      </div>
      <div class="form-control" :class="{invalid: phoneValidity === 'invalid'}">
        <label for="phone">Phone: </label>
        <input v-model.trim="appInfo.phone" id="phone" name="phone" type="text" ref="phoneInput" @blur="phone_Validity"
               class="border"/>
        <p v-if="phoneValidity === 'invalid'">Cannot be empty!</p>
      </div>
      <div class="form-control" :class="{invalid: summaryValidity === 'invalid'}">
        <label for="summary">Summary: </label>
        <input v-model.trim="appInfo.summary" id="summary" name="summary" type="text" ref="summaryInput"
               @blur="summary_Validity" class="border"/>
        <p v-if="summaryValidity === 'invalid'">Cannot be empty!</p>
      </div>

      <div class="form-control" :class="{invalid: hsValidity === 'invalid'}">
        <label for="hs">Hard Skills: </label>
        <input v-model.trim="appInfo.hardSkills" id="hs" name="hs" type="text" ref="hsInput" @blur="hs_Validity"
               class="border"/>
        <p v-if="hsValidity === 'invalid'">Cannot be empty!</p>
      </div>
      <div class="form-control" :class="{invalid: ssValidity === 'invalid'}">
        <label for="ss">Soft Skills: </label>
        <input v-model.trim="appInfo.softSkills" id="ss" name="ss" type="text" ref="ssInput" @blur="ss_Validity"
               class="border"/>
        <p v-if="ssValidity === 'invalid'">Cannot be empty!</p>
      </div>

      <div class="form-control">
        <label>CV Upload: </label>
        <base-button @click="onPickFile">Choose 1 file, up to 5 MB</base-button>
        <input
            type="file"
            style="display: none"
            ref="fileInput"
            accept="image/*, application/pdf"
            @change="onFilePicked"/>
      </div>

      <div>
        <base-button @click="submitApplication">Submit Application</base-button>
      </div>
    </base-card>
  </div>
</template>

<script>
import BaseButton from '../UI/BaseButton.vue';
import BaseDialog from "../UI/BaseDialog.vue";
import UploadService from "../../services/UploadService.js";
import ApplicantService from "../../services/ApplicantService.js";

export default {
  name: 'IndexView',
  components: {BaseDialog, BaseButton},
  props: {
    jobId: {
      type: String,
      required: true,
      default: ''
    },
  },
  data() {
    return {
      appInfo: {
        name: '',
        title: '',
        address: '',
        email: '',
        phone: '',
        summary: '',
        hardSkills: '',
        softSkills: '',

      },
      nameValidity: 'pending',
      titleValidity: 'pending',
      addressValidity: 'pending',
      emailValidity: 'pending',
      phoneValidity: 'pending',
      summaryValidity: 'pending',
      experience: '',
      education: '',
      hsValidity: 'pending',
      ssValidity: 'pending',
      communitiesAndAwards: '',
      projects: '',
      references: '',
      hyperlinks: '',
      cvValidity: 'pending',
      cvIsUploaded: false,
      inputIsInvalid: false,
      isSubmitted: false,
      userIsAuthorized: true,
      applicationExists: false,
      created: false,
      appInfoIsValid: true,
      fileInput: null,
    };
  },
  methods: {
    onPickFile() {
      this.$refs.fileInput.click()
    },
    onFilePicked(event) {
      const files = event.target.files
      console.log(files);
      let formData = new FormData();

      formData.append("files", files[0]);

      UploadService.upload(formData)
          .then((payload) => {
            console.log("payload", payload);
            this.cvIsUploaded = true;
          })
          .catch(error => {
            console.error("Failed to upload CV:", error.response || error.message || error);
            this.cvIsUploaded = false;
          });
    },
    submitApplication() {
      const {name, title, address, email, phone, summary, hardSkills, softSkills} = this.appInfo;

      if (!name || !title || !address || !email || !phone || !summary || !hardSkills || !softSkills) {
        this.inputIsInvalid = true;
        this.isSubmitted = false;
        return;
      } else {
        this.inputIsInvalid = false;
        this.isSubmitted = true;
      }

      const formData = {
        name: this.appInfo.name,
        title: this.appInfo.title,
        address: this.appInfo.address,
        email: this.appInfo.email,
        phone: this.appInfo.phone,
        summary: this.appInfo.summary,
        hardSkills: this.appInfo.hardSkills,
        softSkills: this.appInfo.softSkills
      };

      ApplicantService.createApplicant(this.jobId, formData)
          .then(() => {
            this.created = true;
            this.isSubmitted = true;
          })
          .catch(error => {
            console.error("Failed to create application:", error);
            this.created = false;
            this.appInfoIsValid = false;
          });
    },
    incorrectPopUp() {
      this.inputIsInvalid = false;
    },
    closePopUp() {
      this.$router.push('/jobs');
      this.inputIsInvalid = false;
    },
    name_Validity() {
      if (this.appInfo.name === '') {
        this.nameValidity = 'invalid';
      } else {
        this.nameValidity = 'valid';
      }
    },
    title_Validity() {
      if (this.appInfo.title === '') {
        this.titleValidity = 'invalid';
      } else {
        this.titleValidity = 'valid';
      }
    },
    address_Validity() {
      if (this.appInfo.address === '') {
        this.addressValidity = 'invalid';
      } else {
        this.addressValidity = 'valid';
      }
    },
    email_Validity() {
      if (this.appInfo.email === '') {
        this.emailValidity = 'invalid';
      } else {
        this.emailValidity = 'valid';
      }
    },
    phone_Validity() {
      if (this.appInfo.phone === '') {
        this.phoneValidity = 'invalid';
      } else {
        this.phoneValidity = 'valid';
      }
    },
    summary_Validity() {
      if (this.appInfo.summary === '') {
        this.summaryValidity = 'invalid';
      } else {
        this.summaryValidity = 'valid';
      }
    },
    hs_Validity() {
      if (this.appInfo.hardSkills === '') {
        this.hsValidity = 'invalid';
      } else {
        this.hsValidity = 'valid';
      }
    },
    ss_Validity() {
      if (this.appInfo.softSkills === '') {
        this.ssValidity = 'invalid';
      } else {
        this.ssValidity = 'valid';
      }
    },
  }
}
</script>

<style scoped>
form {
  margin: 2rem auto;
  max-width: 40rem;
  border-radius: 12px;
  box-shadow: 0 2px 8px rgba(0, 0, 0, 0.26);
  padding: 2rem;
  background-color: #FFFBF4;
}

.form-control {
  margin: 0.5rem 0;
}

.form-control.invalid input {
  border-color: darkred;
}

.form-control.invalid label, p {
  color: darkred;
  font-weight: bold;
}

input {
  border-color: #565449;
  border-radius: 0.2rem;
}

.container {
  width: 80rem;
  clear: both;
}

.container input {
  width: 100%;
  clear: both;
}

h2 {
  font-size: 1.25rem;
  font-weight: bold;
}
</style>