import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import Vuex from 'vuex'
require('./assets/css/style.css')
import '@fortawesome/fontawesome-free/css/all.css'
import '@fortawesome/fontawesome-free/js/all.js'
import BootstrapVue from 'bootstrap-vue'
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
import { ValidationProvider, extend, ValidationObserver  } from 'vee-validate';
import * as rules from 'vee-validate/dist/rules';
import { messages } from 'vee-validate/dist/locale/th.json';
import axios from './service/index';
// var jwtDecode = require('jwt-decode');
// console.log("jwtDecode",jwtDecode);
// var decoded = jwtDecode("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJqdGkiOiIwOGQ3Yjg3YS1iYTVmLTg2YjItZmU3ZS02ODExNDBhMGZlNmIiLCJleHAiOjE1ODI3NDA1NjZ9.TlgZnoTPLaH4bZEvH9fgRF6cJ5ZUboEan-A4Aij98is");
// console.log(decoded);

import VueElementLoading from 'vue-element-loading' //https://biigpongsatorn.github.io/#/vue-element-loading
Vue.component('Loading', VueElementLoading)

Vue.use(BootstrapVue)
Vue.use(Vuex)
Vue.config.productionTip = false
Vue.component('ValidationProvider', ValidationProvider);
Vue.component('ValidationObserver', ValidationObserver);
Vue.prototype.$axios = axios;

Object.keys(rules).forEach(rule => {
  extend(rule, {
    
    ...rules[rule], // copies rule configuration
    message: messages[rule] // assign message
  });
});

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')
