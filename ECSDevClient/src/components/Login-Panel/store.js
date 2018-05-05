export const login = {
  state: {
    loginPortal: 'Login/Submit'
  },
  getters: {
    getLoginPortal: function (state) {
      return state.loginPortal
    }
  }
}
