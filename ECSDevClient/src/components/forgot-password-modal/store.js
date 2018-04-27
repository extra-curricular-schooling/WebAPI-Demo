export const forgotPassword = {
  state: {
    wrongAnswersCount: 0,
    maxWrong: 3
  },
  getters: {
    getWrongAnswersCount: function (state) {
      return state.wrongAnswersCount
    },
    getMaxWrong: function (state) {
      return state.maxWrong
    }
  },
  mutations: {
    incrementWrongAnswersCount: function (state) {
      state.wrongAnswersCount++
    }
  },
  actions: {
    incrementWrongAnswersCount: function ({ commit }) {
      commit('incrementWrongAnswersCount')
    }
  }
}
