<template>
  <div id="app">
    <Loading spinner="line-wave" size="50" :active="loadingActive" :is-full-screen="true" color="#0099ff" />
    <div class="top-nav">
      <div class="icon-bar">
          <span v-show="iconBarValue" v-on:click="ClickIconBar()" class="icon-bar-icon bars">
            <i class="fas fa-times"></i>
          </span>
          <span v-show="!iconBarValue" v-on:click="ClickIconBar()" class="icon-bar-icon bars">
            <i class="fas fa-bars"></i>
          </span>
          <span class="icon-bar-icon user" @click="ClickUserMenu()">
            <i class="fas fa-user"></i>
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
      <div :class="classUserMenu">
        <router-link v-for="v in routerUser" :key="v.name" to="" v-on:click.native="ClickUserMenuAfter(v.link)"
          tag="div" class="linkUserMenu">
          <i :class="v.icon"></i> {{v.name}}
        </router-link>  
      </div>
        <slot/>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      loadingActive: false,
      classLeftSide: 'left-side',
      classContent: 'content',
      classLinkText: 'linkText',
      iconBarValue: false,
      iconUserMenuValue: false,
      classUserMenu: 'user-menu none',
      window: {
        width: 0,
        height: 0
      },
      routerName: [
        {
          name:"หน้าแรก",
          link:"/",
          routeName:"index",
          icon:"fas fa-home"
        },
        {
          name:"จัดการหนังสือ",
          link:"/book",
          routeName:"book",
          icon:"fas fa-book"
        },
        {
          name:"จัดการหมวดหมู่หนังสือ",
          link:"/book_category",
          routeName:"book_category",
          icon:"fas fa-layer-group"
        },
        {
          name:"เกี่ยวกับ",
          link:"/about",
          routeName:"about",
          icon:"fas fa-address-card"
        }
      ],
      routerUser: [
        {
          name:"แก้ไขข้อมูลส่วนตัว",
          link:"user_config",
          icon:"fas fa-user-cog"
        },
        {
          name:"ออกจากระบบ",
          link:"logout",
          icon:"fas fa-sign-out-alt"
        }
      ]
    }
  },
  created() {
    window.addEventListener('resize', this.handleResize)
    this.handleResize();

    // check permission for menu
    let jwt = this.$jwtDecode(localStorage.getItem('jwt'))
    if(jwt){
      if(jwt.permission != "staff"){
        this.$router.options.routes.map(x=>{
          if(typeof x.meta != 'undefined'){
            if(typeof x.meta.permission != 'undefined'){
              if(x.meta.permission == "staff"){
                let index = this.routerName.findIndex(data => data.routeName == x.name)
                this.routerName.splice(index, 1)
              } 
            }
          }
          
        })
      }
    }
    
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
      this.iconUserMenuValue = false
      this.classUserMenu = 'user-menu none'
      
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
    ClickUserMenu(){
      this.iconUserMenuValue = !this.iconUserMenuValue
      if(this.iconUserMenuValue){
        this.classUserMenu = 'user-menu unset'
      }else{
        this.classUserMenu = 'user-menu none'
      }
    },
    ClickUserMenuAfter(name){
      this.iconUserMenuValue = false
      this.classUserMenu = 'user-menu none'
      if(name == "logout"){
        this.loadingActive = true
        localStorage.removeItem('jwt');
        setTimeout(() => {
          this.loadingActive = false
          this.$router.push({
            name: 'login'
          })
        }, 1000);
        
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
        this.iconUserMenuValue = false
        this.classUserMenu = 'user-menu none'
      
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
  font-family: 'Bai Jamjuree', sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

</style>
