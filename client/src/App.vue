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
      <div class="mb-2"></div>
      <router-link v-on:click.native="ClickLink()" v-for="v in routerName" :key="v.name" :to="v.link" tag="div" class="link">
        <i :class="v.icon"></i><b :class="['ml-2',classLinkText]">{{v.name}}</b>
      </router-link>  
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
      classLinkText: 'linkText',
      iconBarValue: false,
      window: {
        width: 0,
        height: 0
      },
      routerName: [
        {
          name:"หน้าแรก",
          link:"/",
          icon:"fas fa-home"
        },
        {
          name:"เกี่ยวกับ",
          link:"/about",
          icon:"fas fa-address-card"
        }
      ]
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
    ClickLink(){
      if(this.window.width < 768){
        this.classLeftSide = 'left-side'
        this.iconBarValue = this.iconBarValue == true ? false : true
      }
    },
    ClickIconBar(){
      this.iconBarValue = this.iconBarValue == true ? false : true
      if(this.window.width >= 992){
        if(this.iconBarValue){
          this.classLeftSide = 'left-side clickToMD'
          this.classContent = 'content clickToMD'
          this.classLinkText = 'linkText none'
        }else{
          this.classLeftSide = 'left-side'
          this.classContent = 'content'
          this.classLinkText = 'linkText unset'
        }
      }else if(this.window.width >= 768){
        if(this.iconBarValue){
          this.classLeftSide = 'left-side clickToLG'
          this.classContent = 'content'
          this.classLinkText = 'linkText unset'
        }else{
          this.classLeftSide = 'left-side'
          this.classContent = 'content'
          this.classLinkText = 'linkText'
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
        this.classLinkText = 'linkText'
      
    }
  }
}
</script>

<style>

body{
  background-color: #f1f1f1 !important;
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
