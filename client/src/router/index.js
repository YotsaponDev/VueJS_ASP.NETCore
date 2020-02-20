import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'
import overview from '../components/overview.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'overview',
    component: overview
  },
  {
    path: '/about',
    name: 'about',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../views/About.vue')
  },
  {
    path: '/register',
    name: 'register',
    component: () => import(/* webpackChunkName: "register" */ '../components/register.vue')
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
