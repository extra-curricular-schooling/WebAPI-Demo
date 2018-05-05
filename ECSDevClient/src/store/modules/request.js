/**
 * Base Ajax request module.
 */
export const request = {
  state: {
    // Since we are a web application, we will target the latest version in our api calls.
    appBaseUrl: 'https://ecschooling.org/v1/',
    ssoBaseUrl: 'http://localhost:8085/',
    pwnedBaseUrl: 'https://api.pwnedpasswords.com/range/',
    headers: {
      'Access-Control-Allow-Origin': 'https://ecschooling.org',
      'Access-Control-Allow-Credentials': true,
      'Accept': 'application/json',
      'Content-Type': 'application/json',
      'Authorization': 'null',
      'X-Requested-With': 'XMLHttpRequest'
    },
    formTimeout: 90000, // 90 seconds
    defaultTimeout: 40000 // 40 seconds
  },
  getters: {
    getBaseAppUrl: (state) => { return state.appBaseUrl },
    getBaseSsoUrl: (state) => { return state.ssoBaseUrl },
    getBasePwnedUrl: (state) => { return state.pwnedBaseUrl },
    getRequestHeaders: (state) => { return state.headers },
    getDefaultTimeout: (state) => { return state.defaultTimeout },
    getFormTimeout: (state) => { return state.formTimeout }
  },
  mutations: {
    setAuthorizationHeader: function (state, token) {
      state.headers.Authorization = 'Bearer ' + token
    },
    clearAuthorizationHeader: function (state) {
      state.headers.Authorization = 'null'
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
