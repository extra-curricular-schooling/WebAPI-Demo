// Nice to have a central location to update information. (Single Source of truth)
import Vue from 'vue'
import Vuex from 'vuex'
import { redirect } from '@/components/redirect-modal/store'
import { request } from './modules/request'
import { auth } from './modules/auth'
import { home } from './modules/home'
import { validation } from './modules/validation'
import { linkedin } from '../components/LinkedIn-Modal/store'
import { login } from '../components/Login-Panel/store'
import { AccountStatusPanel } from '../components/AccountStatus-Panel/store'
import { AccountSettings } from '../components/AccountSettings-Panel/store'
import VuexPersist from 'vuex-persist'

const vuexLocalStorage = new VuexPersist({
  key: 'ECSStore', // The key to store the state on in the storage provider.
  storage: window.localStorage, // or window.sessionStorage or localForage
  // Function that passes the state and returns the state with only the objects you want to store.
  reducer: state => ({
    auth: state.auth,
    request: state.request
  })
  // Function that passes a mutation and lets you decide if it should update the state in localStorage.
  // filter: mutation => (true)
})

Vue.use(Vuex)

const debug = process.env.NODE_ENV !== 'production'

// This is the universal in memory data storage for the client side.
export default new Vuex.Store({
  // If we want to expand the store to hold different objects/abstractions,
  // we could use modules to organize them.
  modules: {
    auth,
    home,
    request,
    validation,
    redirect,
    linkedin,
    login,
    AccountStatusPanel,
    AccountSettings
  },
  // If strict should be enabled during development.
  strict: debug,
  plugins: [vuexLocalStorage.plugin]
})
