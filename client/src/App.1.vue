<template>
  <div id="app">
    <aside id="left-panel" class="left-panel">
      <nav class="navbar navbar-expand-sm navbar-default">
            <div id="main-menu" class="main-menu collapse navbar-collapse">
                <ul class="nav navbar-nav">
        <!-- <router-link to="/">Home</router-link> |
        <router-link to="/about">About</router-link>
      <router-view/> -->
                  
                </ul>
            </div>
      </nav>
    </aside>
    <div id="right-panel" class="right-panel">
        <!-- Header-->
        <header id="header" class="header">
            <div class="top-left">
                <div class="navbar-header">
                    <a class="navbar-brand" href="./">
                    <!-- <img src="images/logo.png" alt="Logo"> -->
                    </a>
                    <a class="navbar-brand hidden" href="./">
                    <!-- <img src="images/logo2.png" alt="Logo"> -->
                    </a>
                    <a id="menuToggle" class="menutoggle"><i class="fa fa-bars"></i></a>
                </div>
            </div>
            <div class="top-right">
                <div class="header-menu">
                    <div class="header-left">
                        <div class="form-inline">
                            <form class="search-form">
                                <input class="form-control mr-sm-2" type="text" placeholder="Search ..." aria-label="Search">
                                <button class="search-close" type="submit"><i class="fa fa-close"></i></button>
                            </form>
                        </div>

                    </div>

                </div>
            </div>
        </header>
        <!-- /#header -->
        <!-- Content -->
        <div class="content">
            <div class="animated fadeIn">

            </div>
        </div>
        <!-- /.content -->
        <!-- Footer -->
        <footer class="site-footer">
            <div class="footer-inner bg-white">
                <div class="row">
                    <div class="col-sm-6">
                        Copyright &copy; 2019 Boss Yotsapon
                    </div>
                </div>
            </div>
        </footer>
        <!-- /.site-footer -->
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
.content{
  background-color: #f1f2f7;
}
body{
  background-color: #f1f2f7;
  /* margin-left: 0px; */
}
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

#nav {
  padding: 30px;
}

#nav a {
  font-weight: bold;
  color: #2c3e50;
}

#nav a.router-link-exact-active {
  color: #42b983;
}
</style>
