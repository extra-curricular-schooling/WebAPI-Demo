export const auth = {
  state: {
    authToken: '',
    isAuthenticated: false,
    role: '',
    username: '',
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
    getUsername: function (state) {
      return state.username
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
    },
    setUsername: function (state, username) {
      state.username = username
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
    },
    updateUsername: function ({commit}, payload) {
      commit('setUsername', payload)
    }
  }
}
