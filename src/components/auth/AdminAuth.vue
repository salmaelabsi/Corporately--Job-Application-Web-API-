<template>
  <div class="container">
    <form @submit.prevent="submitForm">
      <div class="form-control">
        <label for="username">Username: </label>
        <input class="border" type="text" id="username" v-model.trim="username"/>
      </div>
      <div class="form-control">
        <label for="email">Email: </label>
        <input class="border" type="email" id="email" v-model.trim="email"/>
      </div>
      <div class="form-control">
        <label for="password">Password: </label>
        <input class="border" type="password" id="password" v-model="password"/>
      </div>
      <p v-if="!formIsValid">Please enter valid credentials.</p>
      <base-button>Login</base-button>
    </form>
  </div>
</template>

<script>

import {defineComponent} from "vue";
import BaseButton from "../UI/BaseButton.vue";
import BaseDialog from "../UI/BaseDialog.vue";

export default defineComponent({
  components: {BaseDialog, BaseButton},
  data() {
    return {
      username: '',
      email: '',
      password: '',
      formIsValid: true,
      mode: 'login',
      isLoading: false,
      error: null
    };
  },
  methods: {
    submitForm() {
      this.formIsValid = true;
      if (this.username === '' || this.email === '' || !this.email.includes('@') || this.password.length < 8) {
        this.formIsValid = false;
        return;
      }
      this.isLoading = true;
      this.$router.push('/admin');
    }
  },
})
</script>

<style scoped>
form {
  margin: 1rem 2rem;
  max-width: 30rem;
}

.form-control {
  margin: 0.5rem 0;
}

input {
  border-color: #565449;
  border-radius: 0.2rem;
  width: 10rem;
}

.container {
  width: 500px;
  clear: both;
}

.container input {
  width: 100%;
  clear: both;
}
</style>