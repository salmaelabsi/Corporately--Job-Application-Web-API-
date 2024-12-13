<template>
  <div  class="container">
<!--    <base-dialog :show="!!error" title="An error occurred" @close="handleError"></base-dialog>-->
<!--    <base-dialog :show="isLoading">-->
<!--      <template #content>Authenticating...</template>-->
<!--    </base-dialog>-->
    <form @submit.prevent="submitForm" v-if="!isAuthenticated">
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
      <p v-if="!formIsValid">Please enter a valid username, email and password. Must be at least 8 characters long.</p>
      <base-button @click="submitForm">{{ submitButtonCaption }}</base-button>
      <base-button type="button" @click="switchAuthMode" mode="flat">{{ switchModeButtonCaption }}</base-button>
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
      error: null,
      isAuthenticated: false,
    };
  },
  methods: {
    async submitForm() {
      this.formIsValid = true;
      if (this.username === '' || this.email === '' || !this.email.includes('@') || this.password.length < 8) {
        this.formIsValid = false;
        return;
      }

      this.isLoading = true;

      try {
        if (this.mode === 'login') {
          await this.$store.dispatch('login', {
            username: this.username,
            password: this.password,
          });
        } else {
          await this.$store.dispatch('signup', {
            username: this.username,
            email: this.email,
            password: this.password,
          });
        }
        this.$emit('authenticated');
        this.isAuthenticated = true;
      }
      catch (err)
      {
        this.error = err.message || 'Failed to authenticate.';
      }
      this.isLoading = false;
    },
    switchAuthMode() {
      if (this.mode === 'login') {
        this.mode = 'signup';
      } else {
        this.mode = 'login';
      }
    }
  },
  computed: {
    submitButtonCaption() {
      if (this.mode === 'login') {
        return 'Login';
      } else {
        return 'Signup';
      }
    },
    switchModeButtonCaption() {
      if (this.mode === 'login') {
        return 'Sign up instead';
      } else {
        return 'Login instead';
      }
    }
  }
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