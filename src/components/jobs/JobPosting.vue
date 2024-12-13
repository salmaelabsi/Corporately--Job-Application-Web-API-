<template>
  <base-dialog title="Unauthorised" v-if="!isAuthenticated && popUpOpen" @close="closePopUp">
    <template #content>
      <h6>You need to log in or sign up to perform this action.</h6>
    </template>
    <template #actions>
      <base-button @click="closePopUp">Okay</base-button>
    </template>
  </base-dialog>
  <li>
    <base-card>
      <header>
        <h3>{{ jobTitle }}</h3>
        <router-link :to="jobsLink" @click="toggleDetails">{{ dataVisible ? 'Hide' : 'Show' }} Details</router-link>
      </header>
      <p><strong>{{ companyTitle }} • {{ location }}</strong></p>
      <p><strong>{{ jobType }} • {{ workMode }} • <span v-if="jobStatus === 'Recruiting'"><span
          class="recruiting">{{ jobStatus }}</span></span>
        <span v-else><span class="application--closed">{{ jobStatus }}</span></span>
      </strong></p>
      <ul v-if="dataVisible">
        <li><strong>Industry: </strong>{{ industry }}</li>
        <li><strong>Experience Level: </strong>{{ experienceLevel }}</li>
        <li><strong>Job Description: </strong>{{ jobDescription }}</li>
        <li><strong>About Company: </strong>{{ aboutCompany }}</li>
        <li><strong>Posted On: </strong>{{ postedOn }}</li>
        <base-button @click="handleApply">Apply</base-button>
      </ul>
    </base-card>
  </li>
</template>

<script>
import BaseButton from "../UI/BaseButton.vue";
import BaseDialog from "../UI/BaseDialog.vue";
import {mapGetters} from "vuex";

export default {
  components: {BaseDialog, BaseButton},
  props: ['id', 'jobTitle', 'companyTitle', 'location', 'jobType', 'workMode', 'industry', 'experienceLevel',
    'jobDescription', 'aboutCompany', 'jobStatus', 'postedOn'],
  data() {
    return {
      dataVisible: false,
      popUpOpen: false,
    };
  },
  methods: {
    toggleDetails() {
      this.dataVisible = !this.dataVisible;
    },
    closePopUp(){
      this.popUpOpen = false;
    },
    handleApply(){
      if (this.isAuthenticated) {
        this.$router.push({
          name: 'ApplyForm',
          params: { jobId: this.id }
        });
      } else {
        this.popUpOpen = true;
      }
    }
  },
  computed: {
    ...mapGetters(['isAuthenticated']),
    jobsLink() {
      return '/jobs/' + this.id;
    }
  }
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

h3 {
  font-size: 1.25rem;
  margin: 0.5rem 0;
}

p {
  margin: 0.5rem 0;
}

.application--closed {
  color: darkred;
}

.recruiting {
  color: darkgreen;
}


nav {
  height: 100%;
}

a {
  text-decoration: none;
  background: transparent;
  border: 1px solid #565449;
  cursor: pointer;
  color: #565449;
  padding: 0.5rem 1.5rem;
  display: inline-block;
  border-radius: 0.4rem;
}

a:hover,
a:active {
  color: #6D685D;
  background-color: #D8CFBC;
  border-color: #D8CFBC;
}
</style>