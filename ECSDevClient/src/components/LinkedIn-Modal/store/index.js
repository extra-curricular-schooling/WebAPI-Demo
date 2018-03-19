export const linkedin = {
  state: {
    linkedInAccessToken: '',
    linkedInPostURI: 'https://localhost:44311/LinkedIn/SharePost'
  },
  getters: {
    getLinkedInAccessToken: function (state) {
      return state.linkedInAccessToken
    },
    getLinkedInPostURI: function (state) {
      return state.linkedInPostURI
    }
  },
  mutations: {
    setLinkedInAccessToken: function (state, newToken) {
      state.linkedInAccessToken = newToken
    }
  },
  actions: {
    updateLinkedInAccessToken: function ({ commit }, payload) {
      commit('setLinkedInAccessToken', payload)
    }
  }
}
