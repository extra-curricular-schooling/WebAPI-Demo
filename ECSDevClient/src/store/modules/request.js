// Axios call is better left in the component that implements it
// By the time the developer inserts all of the fields for a call,
// they might as well use it in their component.

export const request = {
  state: {
    appBaseUrl: 'https://localhost:44311/',
    ssoBaseUrl: 'https://sso.com/',
    headers: {
      'Access-Control-Allow-Origin': 'http://localhost:8080',
      'Access-Control-Allow-Credentials': true,
      'Accept': 'application/json',
      'Authorization': '',
      'Content-Type': 'application/json',
      'X-Requested-With': 'XMLHttpRequest'
    }
  },
  getters: {
    getBaseAppUrl: (state) => { return state.appBaseUrl },
    getBaseSsoUrl: (state) => { return state.ssoBaseUrl },
    getRequestHeaders: (state) => { return state.headers }
  },
  mutations: {
    setAuthorizationHeader: function (state, token) {
      state.headers.Authorization = 'Bearer ' + token
    }
  },
  actions: {
    updateToken: function (context, token) {
      context.commit('setAuthorizationHeader', token)
    }
  }
}
