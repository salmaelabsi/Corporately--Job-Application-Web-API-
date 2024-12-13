<template>
  <div class="flex-container">
    <div class="filters">
      <filters></filters>
    </div>
    <div class="all-jobs">
      <search-bar></search-bar>
      <AvailableJobs :jobs="availableJobs"/>
    </div>
  </div>
</template>

<script>
import AvailableJobs from '../jobs/AvailableJobs.vue';
import SearchBar from "../UI/SearchBar.vue";
import Filters from "../UI/Filters.vue";
import AddJob from "../jobs/AddJob.vue";
import JobService from "../../services/JobService.js";

export default {
  components: {Filters, SearchBar, AvailableJobs, AddJob},
  data() {
    return {
      availableJobs: [],
    };
  },
  provide() {
    return {
      jobs: this.availableJobs,
      addJob: this.addJob,
    };
  },
  methods: {
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
            this.availableJobs = payload.data;
          })
    }
  },
  mounted() {
    this.getJobSummary()
  }
}
</script>

<style scoped>
.flex-container {
  display: flex;
}

.filters {
  margin: 5rem 2rem 0.25rem;
  display: block;
  width: 10%;
}

.all-jobs {
  margin: 2rem 1rem 1rem;
  float: right;
  width: 75%;
}
</style>
