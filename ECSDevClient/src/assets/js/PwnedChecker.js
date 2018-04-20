/* eslint-disable */
var crypto = require('crypto-js')

export default {
  sha1: function (cleanPassword) {
    return crypto.SHA1(cleanPassword)
  },
  parseAtChar: function (hashedString, length) {
    return hashedString.toString().substring(0, length)
  },
  getPwnedParameter: function (cleanPassword) {
    return this.parseAtChar(this.sha1(cleanPassword), 5)
  }
}
