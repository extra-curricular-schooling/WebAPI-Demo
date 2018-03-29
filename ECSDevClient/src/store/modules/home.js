export const home = {
  state: {
    currentArticle: '',
    interestTag: '',
    title: ''
  },
  getters: {
    getCurrentArticle: function (state) {
      return state.currentArticle
    },
    getInterestTag: function (state) {
      return state.interestTag
    },
    getArticleTitle: function (state) {
      return state.title
    }
  },
  mutations: {
    setCurrentArticle: function (state, article) {
      state.currentArticle = article
    },
    setInterestTag: function (state, tag) {
      state.interestTag = tag
    },
    setArticleTitle: function (state, title) {
      state.title = title
    }
  },
  actions: {
    updateArticle: function ({commit}, payload) {
      commit('setCurrentArticle', payload)
    },
    updateInterestTag: function ({commit}, payload) {
      commit('setInterestTag', payload)
    },
    updateTitle: function ({commit}, payload) {
      commit('setArticleTitle', payload)
    }
  }
}
