<template>
  <dialog open>
    <div v-if="step==='firstStep'" class="max-h-80 overflow-y-auto">
      <header>
        <label>Update Existing Job</label>
        <base-button @click="closePopUp('updateJob')">Cancel</base-button>
      </header>
      <div class="content">
        <label for="jobId">Enter Job ID:</label>
        <input v-model.trim="jobId" ref="jobIdInput" @blur="jobIdValidity"/>
        <base-button @click="getJobInfoById">Proceed</base-button>
      </div>
      <p v-if="idValidity === 'invalid' || inputIsInvalid">Job ID cannot be empty!</p>
    </div>
    <job-updater v-else-if="step==='secondStep'" :jobId="jobId" :jobInfoObject="jobInfo" :closePopUp="closePopUp"/>
  </dialog>
</template>

<script>
import {defineComponent} from "vue";
import BaseButton from "../UI/BaseButton.vue";
import JobUpdater from "./JobUpdater.vue";
import BaseDialog from "../UI/BaseDialog.vue";
import JobService from "../../services/JobService.js";

export default defineComponent({
  components: {BaseDialog, JobUpdater, BaseButton},
  data() {
    return {
      jobInfo: {},
      jobId: '',
      idValidity: 'pending',
      inputIsInvalid: false,
      proceeded: false,
      step: "firstStep"
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
      const eJobId = this.$refs.jobIdInput.value;

      if (eJobId.trim() === '') {
        this.inputIsInvalid = true;
      } else {
        this.inputIsInvalid = false;
        this.proceeded = true;
      }
    },
    getJobInfoById() {
      if (!this.jobId || this.jobId.length < 1)
        return;

      JobService.getJobById(this.jobId)
          .then((payload) => {
            this.jobInfo = payload.data;
            this.goToNextStep();
          })
    },
    goToNextStep() {
      this.step = 'secondStep';
    },
    jobIdValidity() {
      if (this.jobId === '') {
        this.idValidity = 'invalid';
      } else {
        this.idValidity = 'valid';
      }
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