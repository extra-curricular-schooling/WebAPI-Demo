export const login = {
  state: {
    loginPortal: 'https://localhost:44311/v1/Login/Submit'
  },
  getters: {
    getLoginPortal: function (state) {
      return state.loginPortal
    }
  }
}
