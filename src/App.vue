<template>
  <the-header></the-header>
  <router-view/>
  <the-footer></the-footer>
</template>

<script>
import TheHeader from './components/layouts/TheHeader.vue';
import TheFooter from './components/layouts/TheFooter.vue';
import SearchBar from "./components/UI/SearchBar.vue";
import TheAdmin from "./components/pages/TheAdmin.vue";
import AdminJobView from "./components/admin/AdminJobView.vue";

export default {
  components: {SearchBar,  TheHeader, TheFooter, TheAdmin, AdminJobView}
}
</script>

<style>
@import url('https://fonts.googleapis.com/css2?family=EB+Garamond:ital,wght@1,400..800&family=Lato:ital,wght@0,100;0,300;0,400;0,700;0,900;1,100;1,300;1,400;1,700;1,900&family=M+PLUS+Rounded+1c:wght@100;300;400;500;700;800;900&display=swap');

* {
  box-sizing: border-box;
}

html {
  height: 100%;
  box-sizing: border-box;
  font-family: "Lato", sans-serif;
  font-weight: 300;
  font-style: normal;
}

body {
  position: relative;
  margin: 0;
  min-height: 100%;
  box-sizing: inherit;
  padding-bottom: 12rem;
}

</style>
