import axios from 'axios'
import store from '@/store/index'

export default {
  submitRegistration: function (username, password, application) {
    // Test SSO Token
    store.dispatch('updateToken', 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VybmFtZSI6InVzZXJuYW1lMDEiLCJwYXNzd29yZCI6InBhc3N3b3JkMDEiLCJhcHBsaWNhdGlvbiI6IkdldFVzR3J1YiIsInJvbGVUeXBlIjoicHVibGljIiwiaWF0IjoxNTE2MjM5MDIyfQ.kNOwv3BKRkVXoJz4NSuOo_qxsPC9ltQw1oX_RBPrqgU')
    axios({
      method: 'POST',
      url: store.getters.getBaseAppUrl + 'Sso/Registration',
      headers: store.getters.getRequestHeaders,
      data: {
        'username': username,
        'password': password,
        'securityQuestions': application
      }
    })
      .then(function (response) {
        console.log(response)
        return response.data
      })
      .catch(function (response) {
        console.log(response)
        return response.data
      })
  },
  submitLogin (username, password) {
    // Test SSO Token
    store.dispatch('updateToken', 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VybmFtZSI6InVzZXJuYW1lMDEiLCJwYXNzd29yZCI6InBhc3N3b3JkMDEiLCJhcHBsaWNhdGlvbiI6IkdldFVzR3J1YiIsInJvbGVUeXBlIjoicHVibGljIiwiaWF0IjoxNTE2MjM5MDIyfQ.kNOwv3BKRkVXoJz4NSuOo_qxsPC9ltQw1oX_RBPrqgU')
    axios({
      method: 'POST',
      url: store.getters.getBaseAppUrl + 'Sso/Login',
      headers: store.getters.getRequestHeaders
    })
      .then(function (response) {
        console.log(response)
        return response.data
      })
      .catch(function (response) {
        console.log(response)
        return response.data
      })
  },
  submitResetPassword: function (username, password) {
    // Test SSO Token
    store.dispatch('updateToken', 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VybmFtZSI6InVzZXJuYW1lMDEiLCJwYXNzd29yZCI6InBhc3N3b3JkMDEiLCJhcHBsaWNhdGlvbiI6IkdldFVzR3J1YiIsInJvbGVUeXBlIjoicHVibGljIiwiaWF0IjoxNTE2MjM5MDIyfQ.kNOwv3BKRkVXoJz4NSuOo_qxsPC9ltQw1oX_RBPrqgU')
    axios({
      method: 'POST',
      url: store.getters.getBaseAppUrl + 'Sso/ResetPassword',
      headers: store.getters.getRequestHeaders,
      data: {
        'username': username,
        'password': password
      }
    })
      .then(function (response) {
        return response.data
      })
      .catch(function (error) {
        console.log(error)
        return error
      })
  }
}
