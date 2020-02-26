<template>
  <div id="app">
      <layout v-if="auth"/>
      <router-view v-if="!auth"/> 
  </div>
</template>

<script>
import layout from './components/layout'
export default {
  components: {
    layout
  },
  data() {
    return {
     auth: false
    }
  },
  created() {
    console.log('xxxxxxx', this)
  },
  methods: {
    
    },
}
</script>

<style>

body{
  background-color: #f1f1f1 !important;
  /* margin-left: 0px; */
  margin: 0;
}
#app {
  font-family: 'Bai Jamjuree', sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

</style>
