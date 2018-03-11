// Nice to have a central location to update information. (Single Source of truth)
import Vue from 'vue'
import Vuex from 'vuex'
import { request } from './modules/request'
import { auth } from './modules/auth'

Vue.use(Vuex)

const debug = process.env.NODE_ENV !== 'production'

// This is the universal in memory data storage for the client side.
export default new Vuex.Store({
  // If we want to expand the store to hold different objects/abstractions,
  // we could use modules to organize them.
  modules: {
    auth,
    request
  },

  // State is passed into any of your getters.
  state: {
    username: ''
  },
  // Any function that retrieves data.
  getters: {
    getUsername: function (state) {
      return state.username
    }
  },
  // Any function that changes data.
  mutations: {
    setUsername: function (state, username) {
      state.username = username
    }
  },
  // The exposed methods that the system uses to work with the store.
  actions: {
  },

  // If strict should be enabled during development.
  strict: debug
})
