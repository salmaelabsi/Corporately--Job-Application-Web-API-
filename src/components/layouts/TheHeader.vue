<template>
  <header class="flex">
    <div class="logo">
      <router-link :to="`/jobs`">
        <img src="../../assets/Corporately.-cropped.png" alt="Corporately."/>
      </router-link>
    </div>
    <div class="login-signup">
      <button v-if="!isLoggedIn" type="button" @click="loginPopUp" >
        <i class="fa fa-user-circle-o fa-3x" aria-hidden="true"></i></button>
      <button v-else type="button" @click="logout" >
        <i class="fa fa-sign-out fa-3x" aria-hidden="true"></i></button>
    </div>
  </header>

  <base-dialog v-if="popUpIsOpen" title="Login Or Sign Up" @close="closePopUp">
    <template #content>
      <user-auth @authenticated="closePopUp"></user-auth>
    </template>
    <template #actions>
      <base-button @click="closePopUp">Close</base-button>
    </template>
  </base-dialog>

  <base-dialog v-if="showSuccessDialog" title="Success">
    <template #content>
      <p>Login successful!</p>
    </template>
  </base-dialog>
</template>

<script>
import UserAuth from "../auth/UserAuth.vue";

export default {
  components: {UserAuth},
  data() {
    return {
      popUpIsOpen: false,
      showSuccessDialog: false,
    };
  },
  methods: {
    loginPopUp() {
      this.popUpIsOpen = true;
    },
    closePopUp(){
      this.popUpIsOpen = false;

      this.showSuccessDialog = true;

      setTimeout(() => {
        this.showSuccessDialog = false;
      }, 700);
    },
    logout(){
      this.$store.dispatch('logout');
      this.$router.replace('/jobs');
    }
  },
  computed: {
    isLoggedIn(){
      return this.$store.getters.isAuthenticated;
    }
  }
}
</script>

<style scoped>
@import url('https://fonts.googleapis.com/css2?family=EB+Garamond:ital,wght@1,400..800&family=M+PLUS+Rounded+1c:wght@100;300;400;500;700;800;900&display=swap');
@import url('https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css');

header {
  width: 100%;
  height: 8rem;
  background-color: #11120D;
  display: flex;
  justify-content: space-between;
  align-items: center;
}

.logo {
  display: block;
  align-items: center;
}

.login-signup {
  display: flex;
  color: #FFFBF4;
  width: 50%;
  justify-content: flex-end;
  align-items: center;
  margin-right: 4rem;
}

img{
  width: 24rem;
  height: auto;
  margin-left: 2rem;
}

</style>