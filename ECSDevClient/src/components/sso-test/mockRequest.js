import Axios from 'axios'
import Store from '@/store/index'
import Router from '@/router/index'
import UrlHelper from '@/assets/js/urlHelper'
import JwtService from '@/assets/js/jwtService'

export default {
  submitRegistration: function (username, password, application) {
    // Test SSO Token
    Axios({
      method: 'POST',
      url: Store.getters.getBaseAppUrl + 'Sso/Registration',
      headers: Store.getters.getRequestHeaders
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
    Axios({
      method: 'POST',
      url: Store.getters.getBaseAppUrl + 'Sso/Login',
      headers: Store.getters.getRequestHeaders
    })
      .then(response => {
        console.log(response)
        console.log(response.status)
        // Testing with a 200 response to make sure the Partial Registration is working.
        if (response.status === 200) {
          let parsedQuery = UrlHelper.parseUrlQuery(response.data)
          let token = parsedQuery['jwt']
          // let claims = jwtService.transform(token)
          let claims = JwtService.myDecode(token)
          JwtService.setClaims(claims)
          console.log(claims)
          Router.push({
            name: 'PartialRegistration',
            params: {
              jwt: token
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
    Axios({
      method: 'POST',
      url: Store.getters.getBaseAppUrl + 'Sso/ResetPassword',
      headers: Store.getters.getRequestHeaders
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
