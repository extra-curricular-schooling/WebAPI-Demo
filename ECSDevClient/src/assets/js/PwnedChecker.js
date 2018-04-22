/* eslint-disable */
var crypto = require('crypto-js')

var parseAtChar = 5

export default {
  // hasher
  sha1: function (cleanPassword) {
    return crypto.SHA1(cleanPassword)
  },
  // get prefix
  getHashedPrefix: function (cleanPassword) {
    var hashedPassword = this.sha1(cleanPassword)
    return hashedPassword.toString().substring(0, parseAtChar).toUpperCase()
  },
  getHashedSuffix: function (cleanPassword) {
    var hashedPassword = this.sha1(cleanPassword)
    return hashedPassword.toString().substring(parseAtChar, hashedPassword.length).toUpperCase()
  },
  stringToArray: function (textArea) {
    return textArea.split("\n")
  },
  getHits: function (cleanPassword, textArea) {
    let myArray = this.stringToArray(textArea)

    let i
    let element
    let pwnedHash
    let passwordSuffix = this.getHashedSuffix(cleanPassword)
    let suffixLength = this.getHashedSuffix(cleanPassword).length

    for (i = 0; i < myArray.length; i++) {
      element = myArray[i]

      // get just hash of the array element
      pwnedHash = element.substring(0, suffixLength)

      // find match
      if (passwordSuffix == pwnedHash) {
        return Number(element.substring(suffixLength+1, element.length))
      }
    }
    return 0
  }
}
