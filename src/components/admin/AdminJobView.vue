<template>
    <li>
    <base-card v-for="job in jobList" :key="job.id">
      <header>
        <ul>
        <li><h4><strong>Job ID: </strong>{{ job.id }}</h4></li>
        <li><h4><strong>Job Title: </strong>{{ job.jobTitle }}</h4></li>
        </ul>
        <base-button @click="job.visible =! job.visible">{{ job.visible ? 'Hide' : 'Show' }} Details</base-button>
      </header>
      <ul v-if="job.visible">
        <li><strong>Company Title: </strong>{{ job.companyTitle }}</li>
        <li><strong>Location: </strong>{{ job.location }}</li>
        <li><strong>Job Type: </strong>{{ job.jobType }}</li>
        <li><strong>Work Mode: </strong>{{ job.workMode }}</li>
        <li><strong>Job Status: </strong>{{ job.jobStatus }}</li>
        <li><strong>Industry: </strong>{{ job.industry }}</li>
        <li><strong>Experience Level: </strong>{{ job.experienceLevel }}</li>
        <li><strong>Job Description: </strong>{{ job.jobDescription }}</li>
        <li><strong>About Company: </strong>{{ job.aboutCompany }}</li>
        <li><strong>Posted On: </strong>{{ job.postedOn }}</li>
      </ul>
    </base-card>
  </li>
</template>

<script>
import BaseButton from "../UI/BaseButton.vue";

export default {
  components: {BaseButton, },
  props:{
    jobList:{
      type:Array
    }
  },
  data() {
    return {
      dataVisible: false,
      job: {}
    };
  },
}
</script>

<style scoped>
li {
  max-width: 40rem;
  list-style: none;
  margin: 0.5rem;
}

header {
  display: flex;
  justify-content: space-between;
  align-items: center;
}

h4 {
  font-size: 1rem;
  margin: 0.5rem 0;
}
</style>