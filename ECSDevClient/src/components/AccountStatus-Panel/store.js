export const AccountStatusPanel = {
  state: {
    accountStatus: false,
    requestAccountInfoUri: 'https://localhost:44311/v1/AccountAdmin/SingleScholarAccountInformation',
    updateAccountStatusUri: 'https://localhost:44311/v1/AccountAdmin/ScholarAccountInformation',
    adminSelectedUsername: ''
  },
  getters: {
    getAccountStatus: function (state) {
      return state.accountStatus
    },
    getRequestAccountInfoUri: function (state) {
      return state.requestAccountInfoUri
    },
    getAdminSelectedUsername: function (state) {
      return state.adminSelectedUsername
    },
    getUpdateAccountStatusUri: function (state) {
      return state.updateAccountStatusUri
    }
  },
  mutations: {
    setAccountStatus: function (state, newAccountStatus) {
      state.accountStatus = newAccountStatus
    },
    setAdminSelectedUsername: function (state, username) {
      state.adminSelectedUsername = username
    }
  },
  actions: {
    updateAccountStatus: function ({commit}, payload) {
      commit('setAccountStatus', payload)
    },
    updateAdminSelectedUsername: function ({commit}, payload) {
      commit('setAdminSelectedUsername', payload)
    }
  }
}
