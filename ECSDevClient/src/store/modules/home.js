export const home = {
  state: {
    currentArticle: '',
    title: ''
  },
  getters: {
    getCurrentArticle: function (state) {
      return state.currentArticle
    },
    getArticleTitle: function (state) {
      return state.title
    }
  },
  mutations: {
    setCurrentArticle: function (state, article) {
      state.currentArticle = article
    },
    setArticleTitle: function (state, title) {
      state.title = title
    }
  },
  actions: {
    updateArticle: function ({commit}, payload) {
      commit('setCurrentArticle', payload)
    },
    updateTitle: function ({commit}, payload) {
      commit('setArticleTitle', payload)
    }
  }
}
