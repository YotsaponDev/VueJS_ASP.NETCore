import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

import register from './modules/register_store'
import login from './modules/login_store'

export default new Vuex.Store({
  modules: {
    register,
    login
  }
})
