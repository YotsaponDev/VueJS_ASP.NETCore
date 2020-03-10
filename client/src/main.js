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
import jwt from 'jwt-decode';

import VueElementLoading from 'vue-element-loading' //https://biigpongsatorn.github.io/#/vue-element-loading
Vue.component('Loading', VueElementLoading)

Vue.use(BootstrapVue)
Vue.use(Vuex)
Vue.config.productionTip = false
Vue.component('ValidationProvider', ValidationProvider);
Vue.component('ValidationObserver', ValidationObserver);
Vue.prototype.$axios = axios;
Vue.prototype.$jwtDecode = jwt;

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
