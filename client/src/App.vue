<template>
  <div id="app">
    <div class="top-nav">
      <div class="icon-bar">
        <span style="font-size: 20px; color: #99abb4 !important;">
          <i class="fas fa-bars"></i>
        </span>
      </div>
    </div>
    <div class="left-side">
       <!-- <router-link to="/">Home</router-link> |
        <router-link to="/about">About</router-link> -->
      
    </div>
    <div class="content">
      <router-view/> 
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      window: {
        width: 0,
        height: 0
      }
    }
  },
  created() {
    window.addEventListener('resize', this.handleResize)
    this.handleResize();
  },
  destroyed() {
    window.removeEventListener('resize', this.handleResize)
  },
  methods: {
    handleResize() {
      this.window.width = window.innerWidth;
      this.window.height = window.innerHeight;

      var body = document.body;
      
      console.log(this.window.width);
      if(this.window.width > 1009){
        body.classList.remove("small-device");
      }else{
        body.classList.add("small-device");
      }
      
    }
  }
}
</script>

<style>

body{
  background-color: #f1f2f7;
  /* margin-left: 0px; */
  margin: 0;
}
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

</style>
