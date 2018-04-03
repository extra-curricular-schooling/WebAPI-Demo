export const auth = {
  state: {
    authToken: '',
    isAuthenticated: false,
    role: '',
    validIssuers: ['https://localhost:44311/', 'https://sso.com/']
  },
  getters: {
    getAuthToken: function (state) {
      return state.authToken
    },
    isAuth: function (state) {
      return state.isAuthenticated
    },
    getRole: function (state) {
      return state.role
    },
    getValidIssuers: (state) => {
      return state.validIssuers
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
      state.role = ''
    },
    setRole: function (state, payload) {
      state.role = payload
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
    },
    updateRole: function ({commit}, payload) {
      commit('setRole', payload)
    }
  }
}
