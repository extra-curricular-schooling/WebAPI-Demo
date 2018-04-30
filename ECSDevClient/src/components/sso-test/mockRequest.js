import Axios from 'axios'
import Store from '@/store/index'
import Router from '@/router/index'
import UrlHelper from '@/assets/js/urlHelper'
import JwtService from '@/assets/js/jwtService'
import Swal from 'sweetalert2'

export default {
  submitRegistration: function () {
    // Test SSO Token
    Axios({
      method: 'POST',
      url: Store.getters.getBaseAppUrl + 'Sso/Registration',
      headers: Store.getters.getRequestHeaders
    })
      .catch(error => {
        if (error.response) {
          // The request was made and the server responded with a status code
          // that falls out of the range of 2xx
          console.log('An error occured')
          console.log('Data:', error.response.data)
          console.log('Status:', error.response.status)
          console.log('Headers:', error.response.headers)
        } else if (error.request) {
          // The request was made but no response was received
          // `error.request` is an instance of XMLHttpRequest in the browser and an instance of
          // http.ClientRequest in node.js
          console.log(error.request)
        } else {
          // Something happened in setting up the request that triggered an Error
          console.log('Error', error.message)
        }
        Swal({
          type: 'error',
          title: 'We Apologize',
          text: 'We are unable to process your request at this time.'})
        console.log(error.config)
      })
  },
  submitLogin () {
    // Test SSO Token
    Axios({
      method: 'POST',
      url: Store.getters.getBaseAppUrl + 'Sso/Login',
      headers: Store.getters.getRequestHeaders
    })
      .then(response => {
        // Testing with a 200 response to make sure the Partial Registration is working.
        if (response.status === 200) {
          let url = response.data
          let parsedQuery = UrlHelper.parseUrlQuery(response.data)
          let token = parsedQuery['jwt']
          return {
            'url': url,
            'token': token
          }
        } else {
          Swal({
            type: 'warning',
            title: 'Response Not Accepted'
          })
        }
      })
      .then((loginInfo) => {
        console.log(loginInfo)
        console.log(loginInfo.url)
        let claims = JwtService.myDecode(loginInfo.token)
        console.log(loginInfo.claims)
        if (UrlHelper.getUrlPath(loginInfo.url) === 'partial-registration') {
          Store.dispatch('updateRole', claims['roleType'])
          Store.dispatch('updateUsername', claims['username'])
          Store.commit('setAuthToken', loginInfo.token)
          Router.push({
            name: 'PartialRegistration',
            params: {
              jwt: loginInfo.token
            }
          })
        }
        if (UrlHelper.getUrlPath(loginInfo.url) === 'home') {
          Store.dispatch('updateRole', claims['role'])
          Store.dispatch('updateUsername', claims['unique_name'])
          Store.commit('signIn', loginInfo.token)
          Router.push({
            name: 'Home'
          })
        }
      })
      .catch(error => {
        if (error.response) {
          // The request was made and the server responded with a status code
          // that falls out of the range of 2xx
          // console.log('An error occured')
          // console.log(error.response.data)
          // console.log(error.response.status)
          // console.log(error.response.headers)
        } else if (error.request) {
          // The request was made but no response was received
          // `error.request` is an instance of XMLHttpRequest in the browser and an instance of
          // http.ClientRequest in node.js
          // console.log(error.request)
        } else {
          // Something happened in setting up the request that triggered an Error
          // console.log('Error', error.message)
        }
        Router.push({name: 'Main'})
        Swal({
          type: 'error',
          title: 'We Apologize',
          text: 'We are unable to process your request at this time. Please try to login through our application.'})
        console.log(error.config)
      })
  },
  submitResetPassword: function () {
    // Test SSO Token
    Axios({
      method: 'POST',
      url: Store.getters.getBaseAppUrl + 'Sso/ResetPassword',
      headers: Store.getters.getRequestHeaders
    })
      .catch(function (error) {
        if (error.response) {
          // The request was made and the server responded with a status code
          // that falls out of the range of 2xx
        } else if (error.request) {
          console.log(error.request)
        } else {
          // Something happened in setting up the request that triggered an Error
          // console.log('Error', error.message)
        }
        Router.push({name: 'Main'})
        Swal({
          type: 'error',
          title: 'We Apologize',
          text: 'We are unable to process your request at this time.'})
        console.log(error.config)
      })
  }
}
