import Axios from 'axios'

export default {
  postCredentials: function (loginURI, headers, username, password) {
    if (username != null) {
      if (password != null) {
        Axios({
          method: 'POST',
          url: loginURI,
          headers: headers,
          data: {
            username: username,
            password: password
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
  }
}
