<template>
  <div>
    <h3>Filters</h3>
  </div>
  <form @submit.prevent="applyFilters">
    <div class="form-control">
      <label for="industry">Industry</label>
      <input id="industry" name="industry" type="text" ref="industry" class="border"/>
    </div>
    <div class="form-control">
      <label for="experience">Experience</label>
      <select id="experience" name="experience" @change="applyFilters">
        <option value="Entry level">Entry level</option>
        <option value="Associate">Associate</option>
        <option value="Senior">Senior</option>
        <option value="Director">Director</option>
        <option value="Executive">Executive</option>
      </select>
    </div>
    <div class="form-control">
      <label for="jobType">Job Type</label>
      <select id="jobType" name="jobType" @change="applyFilters">
        <option value="part">Part-time</option>
        <option value="full">Full-time</option>
        <option value="cont">Contract</option>
        <option value="intern">Internship</option>
      </select>
    </div>
    <div class="form-control">
      <label for="workMode">Work Mode</label>
      <select id="workMode" name="workMode" @change="applyFilters">
        <option value="On-site">On-site</option>
        <option value="Hybrid">Hybrid</option>
        <option value="Remote">Remote</option>
      </select>
    </div>
    <div class="form-control">
      <label for="jobStatus">Job Status</label>
      <select id="jobStatus" name="jobStatus" @change="applyFilters">
        <option value="rec">Recruiting</option>
        <option value="closed">Application closed</option>
      </select>
    </div>
    <div class="form-control">
      <base-button>Apply filters</base-button>
    </div>
  </form>
</template>

<script>
import BaseButton from "./BaseButton.vue";

export default {
  components: {BaseButton},
  data() {
    return {
      experience: 'entry',
      jobType: 'part',
      workMode: 'site',
      jobStatus: 'rec',
      filteredJobs: []
    };
  },
  methods: {
    applyFilters(event) {

    },
  }
}
</script>

<style scoped>
.form-control {
  margin: 0.5rem 0;
}

h3 {
  font-weight: bold;
  font-size: 1.25rem;
}

label {
  margin-top: 1rem;
  font-weight: bold;
}

input,
select {
  display: flex;
  width: 150px;
  font: inherit;
  margin-top: 0.5rem;
  margin-bottom: 1rem;
  border-color: #565449;
}

select {
  width: 9rem;
}

input {
  border-radius: 0.2rem;
  width: 144px;
}
</style>