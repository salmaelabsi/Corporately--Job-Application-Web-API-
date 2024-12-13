<template>
  <dialog open>
    <div class="max-h-96 overflow-y-auto">
      <header>
        <label>All Applications</label>
        <base-button @click="closePopUp('seeApplications')">Cancel</base-button>
      </header>
      <div class="apps-layout">
        <UserApplications :applicationsList="allApplications"/>
      </div>
    </div>
  </dialog>
</template>

<script>

import {defineComponent} from "vue";
import UserApplications from "./UserApplications.vue";
import ApplicantService from "../../services/ApplicantService.js";
import BaseButton from "../UI/BaseButton.vue";

export default defineComponent({
  components: {BaseButton, UserApplications},
  data() {
    return {
      allApplications: [],
    };
  },
  props: {
    closePopUp: {
      type: Function,
      required: true
    }
  },
  emits: ['close'],
  provide() {
    return {
      applications: this.allApplications,
      addApplication: this.addApplication
    };
  },
  methods: {
    addApplication(jobId, id, name, title, address, email, phone, summary, experience, education,
                   hardSkills, softSkills, communitiesAndAwards, projects, references, hyperlinks, cv) {
      const newApplication = {
        id: new Date().toISOString(),
        jobId: jobId,
        name: name,
        title: title,
        address: address,
        email: email,
        phone: phone,
        summary: summary,
        experience: experience,
        education: education,
        hardSkills: hardSkills,
        softSkills: softSkills,
        communitiesAndAwards: communitiesAndAwards,
        projects: projects,
        references: references,
        hyperlinks: hyperlinks,
        cv: cv
      };
      this.allApplications.push(newApplication);
    },
    getApplicationsSummary() {
      ApplicantService.getApplicantsList()
          .then((payload) => {
            this.allApplications = payload.data;
          })
    }
  },
  mounted() {
    this.getApplicationsSummary();
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

.apps-layout {
  margin: 2rem 1rem 1rem;
  float: right;
  width: 90%;
}

</style>