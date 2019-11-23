<template>
  <div id="app">
    <div class="top-nav">
      <div class="icon-bar">
        <span v-show="iconBarValue" v-on:click="ClickIconBar()" style="font-size: 20px; color: #99abb4 !important; cursor:pointer;">
          <i class="fas fa-times"></i>
        </span>
        <span v-show="!iconBarValue" v-on:click="ClickIconBar()" style="font-size: 20px; color: #99abb4 !important; cursor:pointer;">
          <i class="fas fa-bars"></i>
        </span>
      </div>
    </div>
    <div :class="classLeftSide">
       <!-- <router-link to="/">Home</router-link> |
        <router-link to="/about">About</router-link> -->
      
    </div>
    <div :class="classContent">
      <router-view/> 
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      classLeftSide: 'left-side',
      classContent: 'content',
      iconBarValue: false,
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
    ClickIconBar(){
      this.iconBarValue = this.iconBarValue == true ? false : true
      if(this.window.width >= 992){
        if(this.iconBarValue){
          this.classLeftSide = 'left-side clickToMD'
          this.classContent = 'content clickToMD'
        }else{
          this.classLeftSide = 'left-side'
          this.classContent = 'content'
        }
      }else if(this.window.width >= 768){
        if(this.iconBarValue){
          this.classLeftSide = 'left-side clickToLG'
          this.classContent = 'content'
        }else{
          this.classLeftSide = 'left-side'
          this.classContent = 'content'
        }
      }else{
        if(this.iconBarValue){
          this.classLeftSide = 'left-side clickToLG'
          this.classContent = 'content'
        }else{
          this.classLeftSide = 'left-side'
          this.classContent = 'content'
        }
      }
    },
    handleResize() {
      this.iconBarValue = false
      this.window.width = window.innerWidth;
      this.window.height = window.innerHeight;

      var body = document.body;

        this.classLeftSide = 'left-side'
        this.classContent = 'content'
      
      
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
