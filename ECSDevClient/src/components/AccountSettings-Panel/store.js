export const AccountSettings = {
  state: {
    settingsNotificationMessage: ''
  },
  getters: {
    getSettingsNotificationMessage: function (state) {
      return state.settingsNotificationMessage
    }
  },
  mutations: {
    setSettingsNotificationMessage: function (state, message) {
      state.settingsNotificationMessage = message
    }
  },
  actions: {
    updateSettingsNotificationMessage: function ({commit}, payload) {
      commit('setSettingsNotificationMessage', payload)
    }
  }
}
