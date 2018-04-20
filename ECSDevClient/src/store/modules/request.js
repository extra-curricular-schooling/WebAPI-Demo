// Axios call is better left in the component that implements it
// By the time the developer inserts all of the fields for a call,
// they might as well use it in their component.

export const request = {
  state: {
    // Since we are a web application, we will target the latest version in our api calls.
    appBaseUrl: 'https://localhost:44311/v1/',
    ssoBaseUrl: 'https://sso.com/',
    pwnedBaseUrl: 'https://api.pwnedpasswords.com/range/',
    headers: {
      'Access-Control-Allow-Origin': 'http://localhost:8080',
      'Access-Control-Allow-Credentials': true,
      'Accept': 'application/json',
      'Content-Type': 'application/json',
      'Authorization': 'null',
      'X-Requested-With': 'XMLHttpRequest'
    }
  },
  getters: {
    getBaseAppUrl: (state) => { return state.appBaseUrl },
    getBaseSsoUrl: (state) => { return state.ssoBaseUrl },
    getBasePwnedUrl: (state) => { return state.pwnedBaseUrl },
    getRequestHeaders: (state) => { return state.headers }
  },
  mutations: {
    setAuthorizationHeader: function (state, token) {
      state.headers.Authorization = 'Bearer ' + token
    },
    setAppBaseUrl: function (state, baseUrl) {
      state.appBaseUrl = baseUrl
    },
    setSsoBaseUrl: function (state, baseUrl) {
      state.ssoBaseUrl = baseUrl
    }
  },
  actions: {
    updateToken: function (context, token) {
      context.commit('setAuthorizationHeader', token)
    }
  }
}
