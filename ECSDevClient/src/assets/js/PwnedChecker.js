/* eslint-disable */
var crypto = require('crypto-js')

var parseAtChar = 5

export default {
  getHashedPrefix: function (plainPassword) {
    let hashedPassword = crypto.SHA1(plainPassword)
    return hashedPassword.toString().substring(0, parseAtChar).toUpperCase()
  },
  getHashedSuffix: function (plainPassword) {
    let hashedPassword = crypto.SHA1(plainPassword)
    return hashedPassword.toString().substring(parseAtChar, hashedPassword.length).toUpperCase()
  },
  getHits: function (plainPassword, textArea) {
    // store each hash of the string in an array
    let myArray = textArea.split("\n")

    let element
    let pwnedHash
    let passwordSuffix = this.getHashedSuffix(plainPassword)
    let suffixLength = passwordSuffix.length

    for (let i = 0; i < myArray.length; i++) {
      element = myArray[i]

      // extract hash
      pwnedHash = element.substring(0, suffixLength)

      // find match
      if (passwordSuffix == pwnedHash) {
        return Number(element.substring(suffixLength+1, element.length))
      }
    }
    return 0
  }
}
