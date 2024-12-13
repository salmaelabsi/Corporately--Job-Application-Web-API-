<template>
  <div><h1>Hello, Admin</h1></div>
  <div class="flex-container">
    <div class="button-group">
      <h3>Jobs</h3>
      <base-button :to="`/admin`">See All Jobs</base-button>
      <base-button @click="openDialog('addJob')">Add New Job</base-button>
      <base-button @click="openDialog('updateJob')">Update Existing Job</base-button>
      <base-button @click="openDialog('deleteJob')">Delete Job</base-button>
      <h3>Applications</h3>
      <base-button @click="openDialog('seeApplications')">See All Applications</base-button>
      <base-button @click="openDialog('deleteApplication')">Delete Application</base-button>
    </div>
    <div class="see-all">
      <admin-job-view v-if="!addJobPopUpIsOpen" :jobList="jobList"></admin-job-view>
    </div>
    <add-job v-if="dialogList['addJob']" :closePopUp="closeDialog"/>
    <update-job v-if="dialogList['updateJob']" :closePopUp="closeDialog"/>
    <delete-job v-if="dialogList['deleteJob']" :closePopUp="closeDialog"/>
    <div v-if="dialogList['seeApplications']">
      <see-all-applications :allApplications="allApplications" :closePopUp="closeDialog"></see-all-applications>
    </div>
    <delete-application v-if="dialogList['deleteApplication']" :closePopUp="closeDialog" />
  </div>
</template>

<script>
import {defineComponent} from "vue";
import BaseButton from "../UI/BaseButton.vue";
import AdminJobView from "../admin/AdminJobView.vue";
import AvailableJobs from "../jobs/AvailableJobs.vue";
import AddJob from "../jobs/AddJob.vue";
import UpdateJob from "../jobs/UpdateJob.vue";
import JobUpdater from "../jobs/JobUpdater.vue";
import DeleteJob from "../jobs/DeleteJob.vue";
import JobService from "../../services/JobService.js";
import SeeAllApplications from "../application/SeeAllApplications.vue";
import DeleteApplication from "../application/DeleteApplication.vue";

export default defineComponent({
  components: {
    JobUpdater,
    AddJob,
    DeleteJob,
    UpdateJob,
    AdminJobView,
    BaseButton,
    AvailableJobs,
    SeeAllApplications,
    DeleteApplication,
    JobService,
  },
  data() {
    return {
      addJobPopUpIsOpen: false,
      jobList: [],
      allApplications: [],
      dialogList:[]
    };
  },
  provide() {
    return {
      jobs: this.availableJobs,
      addJob: this.addJob
    };
  },
  methods: {
    openDialog(compName){
      this.dialogList[compName]=true;
    },
    closeDialog(compName,refresh){
      this.dialogList[compName]=false;
      if(refresh)
        this.getJobSummary();
    },
    addJob(jobTitle, companyTitle, location, jobType, workMode, industry, experienceLevel, jobDescription, aboutCompany, jobStatus, postedOn) {
      const newJob = {
        id: new Date().toISOString(),
        jobTitle: jobTitle,
        companyTitle: companyTitle,
        location: location,
        jobType: jobType,
        workMode: workMode,
        industry: industry,
        experienceLevel: experienceLevel,
        jobDescription: jobDescription,
        aboutCompany: aboutCompany,
        jobStatus: jobStatus,
        postedOn: postedOn,
      };
      this.availableJobs.unshift(newJob);
    },
    getJobSummary() {
      JobService.getJobList()
          .then((payload) => {
            this.jobList = payload.data;
          })
    },
  },
  mounted() {
    this.getJobSummary();
  }
})
</script>

<style scoped>
h1 {
  margin: 1rem 4rem;
  text-align: left;
  font-size: 2rem;
  font-weight: bold;
}

h3 {
  margin: 2rem 2rem 1rem;
  text-align: left;
  font-size: 1.25rem;
  font-weight: bold;
}

.button-group button {
  padding: 0.75rem 2rem;
  width: 12rem;
  margin: 0.5rem 2rem 0.25rem;
  display: block;
}

.flex-container {
  display: flex;
}

.see-all {
  margin: 2rem 1rem 1rem;
  text-align: left;
  float: right;
  width: 75%;
}

</style>