export const Request = {
  state: {
    appBaseUrl: 'https://localhost:44311/',
    ssoBaseUrl: 'https://sso.com/',
    requestHeaders: {
      'Access-Control-Allow-Origin': '*',
      'Access-Control-Allow-Credentials': true,
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    }
  },
  getters: {
    getBaseAppUrl: (state) => { return state.appBaseUrl },
    getBaseSsoUrl: (state) => { return state.ssoBaseUrl },
    getRequestHeaders: (state) => { return state.requestHeaders }
  },
  mutations: {
  },
  actions: {
  }
}
