import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

import register from './modules/register_store'
import login from './modules/login_store'
import book from './modules/book_store'
import book_category from './modules/book_category_store'

export default new Vuex.Store({
  modules: {
    register,
    login,
    book,
    book_category
  }
})
