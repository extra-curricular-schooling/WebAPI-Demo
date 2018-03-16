export const login = {
  state: {
    loginPortal: 'https://localhost:44311/Login/SubmitLogin'
  },
  getters: {
    getLoginPortal: function (state) {
      return state.loginPortal
    }
  }
}
