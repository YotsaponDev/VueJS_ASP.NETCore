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
      var n = 10
      var a1 = 3
      var d = 2
      var sum = 0
      for(var i = 1;i<=n;i++){
        
        // console.log(a1 = a1 + (d*i))
        Math.pow(i, 2) - (i + 3)
        console.log((Math.pow(i, 2) - i) + 3)
      } 
    },
  }
</script>