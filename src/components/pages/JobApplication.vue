<template>
  <div>
    <the-form :jobId="jobId"></the-form>
  </div>
</template>

<script>
import TheForm from '../application/TheForm.vue';
import BaseDialog from "../UI/BaseDialog.vue";

export default {
  components: { BaseDialog, TheForm },
  data(){
    return{
      jobId:null
    };
  },
  mounted(){
    this.jobId=this.$route.params.jobId;
}
}
</script>

<style scoped>
* {
  box-sizing: border-box;
}

html {
  font-family: inherit;
}

body {
  margin: 0;
  background-color: #FFFBF4;
}
</style>