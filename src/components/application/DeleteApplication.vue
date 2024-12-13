<template>
  <dialog open>
    <div class="max-h-80 overflow-y-auto">
      <header>
        <label>Delete Application</label>
        <base-button @click="closePopUp('deleteApplication')">Cancel</base-button>
      </header>
      <div class="content">
        <label for="appId">Enter Application ID:</label>
        <input v-model.trim="appId" ref="appIdInput" @blur="appIdValidity"/>
        <base-button @click="validate">Proceed</base-button>
      </div>
      <p v-if="idValidity === 'invalid' || inputIsInvalid">Application ID cannot be empty!</p>
    </div>
  </dialog>

  <base-dialog v-if="proceeded" title="Confirmation">
    <template #content>
      <label>Are you sure you want to delete this application?</label>
      <base-button @click="closePopUp('deleteApplication')">No</base-button>
      <base-button @click="deleteApplication">Yes</base-button>
    </template>
    <template #actions>
      <base-button @click="closePopUp('deleteApplication')">Cancel</base-button>
    </template>
  </base-dialog>

  <base-dialog v-if="deleted" title="Success">
    <template #content>
      <label>Application has been deleted successfully.</label>
    </template>
    <template #actions>
      <base-button @click="closePopUp('deleteApplication')">Okay</base-button>
    </template>
  </base-dialog>

  <base-dialog v-if="!deleted && !appIdIsValid" title="Failed">
    <template #content>
      <label>Application ID does not exist!</label>
    </template>
    <template #actions>
      <base-button @click="closePopUp('deleteApplication')">Close</base-button>
    </template>
  </base-dialog>
</template>

<script>
import {defineComponent} from "vue";
import BaseButton from "../UI/BaseButton.vue";
import BaseDialog from "../UI/BaseDialog.vue";
import ApplicantService from "../../services/ApplicantService.js";

export default defineComponent({
  components: {BaseDialog, BaseButton},
  data() {
    return {
      appInfo: {},
      appId: '',
      idValidity: 'pending',
      appIdIsValid: true,
      inputIsInvalid: false,
      proceeded: false,
      deleted: false,
    };
  },
  props: {
    closePopUp: {
      type: Function,
      required: true
    }
  },
  emits: ['close'],
  methods: {
    validate() {
      const eAppId = this.$refs.appIdInput.value;

      if (eAppId.trim() === '') {
        this.inputIsInvalid = true;
      } else {
        this.inputIsInvalid = false;
        this.proceeded = true;
      }
    },
    appIdValidity() {
      if (this.appId === '') {
        this.idValidity = 'invalid';
      } else {
        this.idValidity = 'valid';
      }
    },
    deleteApplication() {
      ApplicantService.deleteApplicant(this.appId)
          .then(() => {
            this.deleted = true;
            this.closePopUp('deleteApplication', true);
          })
          .catch(error => {
            console.error("Failed to delete application:", error);
            this.deleted = false;
            this.appIdIsValid = false;
          });
    },
  }
})
</script>

<style scoped>
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

header {
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin-right: 0.75rem;
}

label {
  font-weight: bold;
  display: block;
  margin-bottom: 0.5rem;
}

input,
textarea {
  display: block;
  width: 50%;
  font: inherit;
  padding: 0.15rem;
  border: 1px solid #565449;
  border-radius: 0.2rem;
}

input:focus,
textarea:focus {
  outline: none;
  border-color: #565449;
  background-color: #d8cfbc;
}

p {
  color: darkred;
}

.content {
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin-top: 1rem;
  margin-right: 0.75rem;
}
</style>