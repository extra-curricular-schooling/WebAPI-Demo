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
      'Content-Type': 'application/json',
      'Authorization': 'Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VybmFtZSI6InNjb3R0IiwicGFzc3dvcmQiOiJwYXNzIiwiYXBwbGljYXRpb24iOiJlY3MiLCJyb2xlVHlwZSI6InB1YmxpYyIsIm5iZiI6MTUyMTUzMzg1MywiZXhwIjoxNTIxNTM3NDUzLCJpYXQiOjE1MjE1MzM4NTN9.7WmrroG6SjJGNSZ97lDIgTVedWXKyYblLmapK9XMrMw',
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
    updateToken: function (context, payload) {
      context.commit('setAuthorizationHeader', payload)
    }
  }
}
