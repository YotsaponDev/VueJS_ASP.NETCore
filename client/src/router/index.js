import Vue from 'vue'
import VueRouter from 'vue-router'

var jwtDecode = require('jwt-decode');

Vue.use(VueRouter)

const routes = [
  {
    path: '*',
    name: 'page-not-found',
    component: () => import(/* webpackChunkName: "page-not-found" */ '../components/404.vue'),
  },
  {
    path: '/',
    name: 'index',
    component: () => import(/* webpackChunkName: "index" */ '../components/index.vue'),
    meta: {
      requiresAuth: true
    }
  },
  {
    path: '/about',
    name: 'about',
    component: () => import(/* webpackChunkName: "about" */ '../views/About.vue'),
    meta: {
      requiresAuth: true
    }
  },
  {
    path: '/register',
    name: 'register',
    component: () => import(/* webpackChunkName: "register" */ '../components/register.vue')
  },
  {
    path: '/login',
    name: 'login',
    component: () => import(/* webpackChunkName: "login" */ '../components/login.vue')
  },
  {
    path: '/book',
    name: 'book',
    component: () => import(/* webpackChunkName: "about" */ '../components/book.vue'),
    meta: {
      requiresAuth: true,
      permission: "staff"
    }
  },
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

router.beforeEach((to, from, next) => {
  const jwt = localStorage.getItem('jwt');
  var decoded = jwt == null ? null : jwtDecode(jwt);
  
  if (to.matched.some(record => record.meta.requiresAuth)) {
    if (jwt) {
      if(new Date().getTime() / 1000 > decoded.exp){
        localStorage.removeItem('jwt');
        next('/login')
      }
      if(to.matched.map(a=>a.meta.permission) == "staff"){
        if(decoded.permission == "staff"){
          next()
        }else{
          next('404')
        }
        
      }
      next()
      return
    }
    next('/login')
  } else {
    next()
  }
})

export default router
