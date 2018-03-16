import Axios from 'axios'
import passwordSecurity from '../../../assets/js/Hash-N-Salt.js'

export default {
  postCredentials: function (loginURI, headers, username, password) {
    if (username != null) {
      if (password != null) {
        var salt = passwordSecurity.genRandomString(16)
        var passwordHash = passwordSecurity.sha256(password, salt)

        Axios({
          method: 'POST',
          url: loginURI,
          headers: headers,
          data: {
            username: username,
            password: passwordHash.passwordHash,
            salt: passwordHash.salt
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
