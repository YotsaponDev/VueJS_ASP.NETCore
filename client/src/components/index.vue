<template>
  <layout>
    <div class="container">
 
    </div>
  </layout>
</template>

<script>
  import { mapActions , mapGetters } from "vuex";
  import layout from '../components/layout'
  export default {
    components: {
      layout
    },
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