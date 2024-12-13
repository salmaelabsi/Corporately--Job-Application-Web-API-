<template>
  <dialog open>
    <div class="max-h-80 overflow-y-auto">
      <header>
        <label>Add New Job</label>
        <base-button @click="closePopUp('addJob')">Cancel</base-button>
      </header>
      <div class="form-control">
        <label for="jt">Job Title: </label>
        <input id="jt" name="jt" type="text" ref="jobTitle" v-model="jobInfo.jobTitle"/>
      </div>
      <div class="form-control">
        <label for="ct">Company Title: </label>
        <input id="ct" name="ct" type="text" ref="companyTitle" v-model="jobInfo.companyTitle"/>
      </div>
      <div class="form-control">
        <label for="loc">Location: </label>
        <input id="loc" name="loc" type="text" ref="location" v-model="jobInfo.location"/>
      </div>
      <div class="form-control">
        <label for="referrer3">Job Type: </label>
        <select id="referrer3" name="referrer3" v-model="jobInfo.jobType">
          <option value="Part-time">Part-time</option>
          <option value="Full-time">Full-time</option>
          <option value="Contract">Contract</option>
          <option value="Internship">Internship</option>
        </select>
      </div>
      <div class="form-control">
        <label for="referrer4">Work Mode: </label>
        <select id="referrer4" name="referrer4" v-model="jobInfo.workMode">
          <option value="On-site">On-site</option>
          <option value="Hybrid">Hybrid</option>
          <option value="Remote">Remote</option>
        </select>
      </div>
      <div class="form-control">
        <label for="referrer5">Job Status: </label>
        <div>
          <input id="referrer5" name="referrer5" value="Recruiting" type="radio" v-model="jobInfo.jobStatus"/>
          <span>Recruiting</span>
        </div>
        <div>
          <input id="referrer5" name="referrer5" value="Application closed" type="radio" v-model="jobInfo.jobStatus"/>
          <span>Application closed</span>
        </div>
      </div>
      <div class="form-control">
        <label for="referrer2">Experience Level: </label>
        <select id="referrer2" name="referrer2" v-model="jobInfo.experienceLevel">
          <option value="Entry level">Entry level</option>
          <option value="Associate">Associate</option>
          <option value="Senior">Senior</option>
          <option value="Director">Director</option>
          <option value="Executive">Executive</option>
        </select>
      </div>
      <div class="form-control">
        <label for="industry">Industry: </label>
        <input id="industry" name="industry" type="text" ref="industry" v-model="jobInfo.industry"/>
      </div>
      <div class="form-control">
        <label for="jDesc">Job Description: </label>
        <input id="jDesc" name="jDesc" type="text" ref="jobDescription" v-model="jobInfo.jobDescription"/>
      </div>
      <div class="form-control">
        <label for="about">About Company: </label>
        <input id="about" name="about" type="text" ref="aboutCompany" v-model="jobInfo.aboutCompany"/>
      </div>
      <div class="form-control">
        <label for="date">Posted On: </label>
        <input id="date" name="date" type="text" ref="postedOn" v-model="jobInfo.postedOn"/>
      </div>
      <div class="form-control">
        <base-button @click="addJob">Add</base-button>
      </div>
    </div>
  </dialog>

  <base-dialog v-if="added" title="Success">
    <template #content>
      <label>Job has been added successfully.</label>
    </template>
    <template #actions>
      <base-button @click="closePopUp('addJob')">Okay</base-button>
    </template>
  </base-dialog>

  <base-dialog v-if="!added && !jobInfoIsValid" title="Unsuccessful">
    <template #content>
      <label>Unable to add job.</label>
    </template>
    <template #actions>
      <base-button @click="closePopUp('addJob')">Close</base-button>
    </template>
  </base-dialog>
</template>

<script>
import BaseDialog from "../UI/BaseDialog.vue";
import BaseButton from "../UI/BaseButton.vue";
import JobService from "../../services/JobService.js";
import dayjs from "dayjs";

export default {
  components: {BaseDialog, BaseButton},
  props: {
    closePopUp: {
      type: Function,
      required: true
    }
  },
  emits: ['close'],
  data() {
    return {
      jobInfo: {},
      referrer2: 'Entry level',
      referrer3: 'Part-time',
      referrer4: 'On-site',
      jobInfoIsValid: true,
      added: false,
    };
  },
  methods: {
    addJob() {
      this.jobInfo.postedOn = dayjs(this.jobInfo.postedOn).format('YYYY-MM-DD');
      JobService.createJob(this.jobInfo)
          .then(() => {
            this.added = true;
            this.closePopUp('addJob', true);
          })
          .catch(error => {
            console.error("Failed to add job:", error);
            this.added = false;
            this.jobInfoIsValid = false;
          });
    }
  }
}
</script>

<style scoped>
.form-control {
  margin: 1rem 0;
}

label {
  font-weight: bold;
  display: block;
  margin-bottom: 0.5rem;
}

header {
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin-right: 0.75rem;
}

input,
textarea {
  display: block;
  width: 100%;
  font: inherit;
  padding: 0.15rem;
  border: 1px solid #ccc;
}

input:focus,
textarea:focus {
  outline: none;
  border-color: #565449;
  background-color: #d8cfbc;
}

dialog {
  position: fixed;
  top: 20vh;
  left: 10%;
  width: 40%;
  z-index: 100;
  border-radius: 12px;
  border: none;
  box-shadow: 0 2px 8px rgba(0, 0, 0, 0.26);
  padding: 2rem 2rem;
  margin: 2rem 2rem;
  overflow: hidden;
  background-color: #FFFBF4;
}

input[type='radio'] {
  display: inline-block;
  width: auto;
  margin-right: 0.5rem;
}

input[type='radio'] + label {
  font-weight: normal;
  margin-left: auto;
}

</style>