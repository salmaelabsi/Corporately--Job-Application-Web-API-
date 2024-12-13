<template>
  <li>
    <base-card v-for="app in applicationsList" :key="app.id">
      <header>
        <ul>
          <li><h4><strong>Job ID: </strong>{{ app.jobId }}</h4></li>
          <li><h4><strong>Application ID: </strong>{{ app.id }}</h4></li>
        </ul>
        <base-button @click="app.visible =! app.visible">{{ app.visible ? 'Hide' : 'Show' }} Details</base-button>
      </header>
      <ul v-if="app.visible">
        <li><strong>Name: </strong>{{ app.name }}</li>
        <li><strong>Title: </strong>{{ app.title }}</li>
        <li><strong>Address: </strong>{{ app.address }}</li>
        <li><strong>Email: </strong>{{ app.email }}</li>
        <li><strong>Phone: </strong>{{ app.phone }}</li>
        <li><strong>Summary: </strong>{{ app.summary }}</li>
        <li><strong>Experience: </strong>{{ app.experience }}</li>
        <li><strong>Education: </strong>{{ app.education }}</li>
        <li><strong>Hard Skills: </strong>{{ app.hardSkills }}</li>
        <li><strong>Soft Skills: </strong>{{ app.softSkills }}</li>
        <li><strong>Communities & Awards: </strong>{{ app.communitiesAndAwards }}</li>
        <li><strong>Projects: </strong>{{ app.projects }}</li>
        <li><strong>References: </strong>{{ app.references }}</li>
        <li><strong>Hyperlinks: </strong>{{ app.hyperlinks }}</li>
        <li><strong>CV: </strong>{{ app.cv }}</li>
      </ul>
    </base-card>
  </li>
</template>

<script>
import BaseButton from "../UI/BaseButton.vue";

export default {
  components: {BaseButton, },
  props:{
    applicationsList:{
      type:Array
    }
  },
  data() {
    return {
      dataVisible: false,
      application: {}
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