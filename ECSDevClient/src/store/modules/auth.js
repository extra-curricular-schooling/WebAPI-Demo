export const auth = {
  state: {
    authToken: '',
    isAuthenticated: false
  },
  getters: {
    getAuthToken: function (state) {
      return state.authToken
    },
    isAuth: function (state) {
      return state.isAuthenticated
    }
  },
  mutations: {
    signIn: function (state, payload) {
      state.isAuthenticated = true
      state.authToken = payload
    },
    signOut: function (state) {
      state.isAuthenticated = false
      state.authToken = ''
    }
  },
  actions: {
    signIn: function ({commit}, payload) {
      // Commit = Call this method in the mutations.
      commit('signIn', payload)
    },
    signOut: function ({commit}) {
      // Commit = Call this method in the mutations.
      commit('signOut')
    }
  }
}
