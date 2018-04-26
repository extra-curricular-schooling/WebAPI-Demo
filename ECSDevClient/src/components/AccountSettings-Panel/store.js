export const AccountSettings = {
  state: {
    settingsNotificationMessage: '',
    zipCodeId: '',
    address: '',
    city: '',
    state: '',
    zipCode: ''
  },
  getters: {
    getSettingsNotificationMessage: function (state) {
      return state.settingsNotificationMessage
    },
    getZipCodeId: function (state) {
      return state.zipCodeId
    },
    getAddress: function (state) {
      return state.address
    },
    getCity: function (state) {
      return state.city
    },
    getState: function (state) {
      return state.state
    },
    getZipCode: function (state) {
      return state.zipCode
    }
  },
  mutations: {
    setSettingsNotificationMessage: function (state, message) {
      state.settingsNotificationMessage = message
    },
    setZipCodeId: function (state, zipCodeId) {
      state.zipCodeId = zipCodeId
    },
    setAddress: function (state, address) {
      state.address = address
    },
    setCity: function (state, city) {
      state.city = city
    },
    setState: function (state, stateVal) {
      state.state = stateVal
    },
    setZipCode: function (state, zipCode) {
      state.zipCode = zipCode
    }
  },
  actions: {
    updateSettingsNotificationMessage: function ({commit}, payload) {
      commit('setSettingsNotificationMessage', payload)
    },
    updateZipCodeId: function ({commit}, payload) {
      commit('setZipCodeId', payload)
    },
    updateAddress: function ({commit}, payload) {
      commit('setAddress', payload)
    },
    updateCity: function ({commit}, payload) {
      commit('setCity', payload)
    },
    updateState: function ({commit}, payload) {
      commit('setState', payload)
    },
    updateZipCode: function ({commit}, payload) {
      commit('setZipCode', payload)
    }
  }
}
