import jsonwebtoken from 'jsonwebtoken'

export default {
  decode: (token) => {
    let decodedToken = jsonwebtoken.decode(token)
    return decodedToken
  }
}
