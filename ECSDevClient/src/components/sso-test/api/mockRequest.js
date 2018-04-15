import axios from 'axios'
import store from '@/store/index'
import router from '@/router/index'
import urlHelper from '@/assets/js/urlHelper.js'

export default {
  submitRegistration: function (username, password, application) {
    // Test SSO Token
    axios({
      method: 'POST',
      url: store.getters.getBaseAppUrl + 'Sso/Registration',
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
  submitLogin (username, password) {
    // Test SSO Token
    axios({
      method: 'POST',
      url: store.getters.getBaseAppUrl + 'Sso/Login',
      headers: store.getters.getRequestHeaders
    })
      .then(response => {
        console.log(response)
        console.log(response.status)
        // Testing with a 200 response to make sure the Partial Registration is working.
        if (response.status === 200) {
          let parsedQuery = urlHelper.parseQuery(response.data)
          console.log(parsedQuery)
          let jwtString = parsedQuery['jwt']
          router.push({
            name: 'PartialRegistration',
            params: {
              jwt: jwtString
            }
          })
        }
        // Should be a 301 response when you figure that out.
        if (response.status === 301) {
          let headers = response.headers
          let headersString = JSON.stringify(headers)
          console.log(headersString)
        }
      })
      .catch(response => {
        console.log(response)
        return response.data
      })
  },
  submitResetPassword: function (username, password) {
    // Test SSO Token
    axios({
      method: 'POST',
      url: store.getters.getBaseAppUrl + 'Sso/ResetPassword',
      headers: store.getters.getRequestHeaders
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
