<template>
  <footer>
    <div class="left">
      <a href="https://sites.google.com/view/corporately-privacy-policy/home"
         target="_blank" rel="noopener noreferrer">Privacy Policy</a>
      <a href="https://forms.gle/77H5pUWhuEjUHFqw8"
         target="_blank" rel="noopener noreferrer">Review Our Site</a>
      <a href="https://docs.google.com/document/d/1iNxGjAkgqJHMwbJnrsNTGx4gb6J3T309UqFjSapbmZU/edit?usp=sharing"
         target="_blank" rel="noopener noreferrer">Documentation</a>
      <a href="https://github.com/salmaelabsi/Corporately--Job-Application-Web-API-"
         target="_blank" rel="noopener noreferrer">Source Code</a>
      <a href="https://sites.google.com/view/corporately-resources/home"
         target="_blank" rel="noopener noreferrer">Resources</a>
    </div>
    <div class="right">
      <button @click="loginPopUp">Log in as admin</button>
    </div>
  </footer>
  <base-dialog v-if="popUpIsOpen" title="Login As Admin" @close="closePopUp">
    <template #content>
      <admin-auth></admin-auth>
    </template>
    <template #actions>
      <base-button @click="closePopUp">Close</base-button>
    </template>
  </base-dialog>
</template>

<script>

import {defineComponent} from "vue";
import AdminAuth from "../auth/AdminAuth.vue";

export default defineComponent({
  components: {AdminAuth},
  data() {
    return {
      popUpIsOpen: false,
    };
  },
  methods: {
    loginPopUp() {
      this.popUpIsOpen = true;
    },
    closePopUp() {
      this.popUpIsOpen = false;
    },
  }
})
</script>

<style scoped>
@import url('https://fonts.googleapis.com/css2?family=EB+Garamond:ital,wght@1,400..800&family=M+PLUS+Rounded+1c:wght@100;300;400;500;700;800;900&display=swap');

footer {
  width: 100%;
  height: 12rem;
  background-color: #11120D;
  display: flex;
  justify-content: left;
  align-items: center;
  margin-top: auto;
  position: absolute;
  bottom: 0;
  left: 0;
  right: 0;
}

.right {
  display: flex;
  justify-content: flex-end;
  margin-left: auto;
  margin-right: 0;
}

.left a {
  display: block;
  justify-content: flex-start;
  color: #FFFBF4;
  margin-left: 5rem;
  margin-right: auto;
  margin-bottom: 0.25rem;
}

button {
  color: #FFFBF4;
  margin-top: 6rem;
  margin-bottom: 1rem;
  margin-right: 2rem;
}

</style>