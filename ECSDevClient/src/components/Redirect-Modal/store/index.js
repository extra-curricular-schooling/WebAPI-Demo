export const redirect = {
  state: {
    redirectUri: '',
    errorMessage: '',
    isRedirectModalVisible: false
  },
  getters: {
    getRedirectUri: function (state) {
      return state.redirectUri
    },
    getErrorMessage: function (state) {
      return state.errorMessage
    },
    getRedirectVisiblity: function (state) {
      return state.isRedirectModalVisible
    }
  },
  mutations: {
    setRedirectUri: function (state, uri) {
      state.redirectUri = uri
    },
    setErrorMessage: function (state, msg) {
      state.errorMessage = msg
    },
    setRedirectVisibility: function (state, status) {
      state.isRedirectModalVisible = status
    }
  },
  actions: {
    updateRedirectUri: function ({commit}, payload) {
      commit('setRedirectUri', payload)
    },
    updateErrorMessage: function ({commit}, payload) {
      commit('setErrorMessage', payload)
    },
    updateRedirectVisiblity: function ({commit}, payload) {
      commit('setRedirectVisibility', payload)
    }
  }
}
