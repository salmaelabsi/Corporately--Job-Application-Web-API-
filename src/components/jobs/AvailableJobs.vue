<template>
  <ul>
    <job-posting
        v-for="j in jobs"
        :key="j.id"
        :id="j.id"
        :job-title="j.jobTitle"
        :company-title="j.companyTitle"
        :location="j.location"
        :job-status="j.jobStatus"
        :job-type="j.jobType"
        :work-mode="j.workMode"
        :experience-level="j.experienceLevel"
        :industry="j.industry"
        :about-company="j.aboutCompany"
        :job-description="j.jobDescription"
        :posted-on="j.postedOn">
    </job-posting>
  </ul>
</template>

<script>
import JobPosting from './JobPosting.vue';
import JobApplication from "../pages/JobApplication.vue";

export default {
  props: ['jobs',
    'application',
  ],
  components: {
    JobPosting,
    JobApplication,
  },
}
</script>

<style scoped>
ul {
  list-style: none;
  padding: 0;
  margin: auto;
  max-width: 40rem;
}

</style>