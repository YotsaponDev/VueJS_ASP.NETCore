<template>
  <div class="hello">
      Overview

  </div>
</template>

<script>
  import { mapActions , mapGetters } from "vuex";
  export default {
    data() {
        return {
               
        }
      },
    mounted(){
      console.log(this.$axios);
      
     this.$axios.get('/api/Member')
        .then((resp) => {
            console.log(resp);
        })
        .catch(() => {
            console.log('err:' , err);
        });
    },
  }
</script>