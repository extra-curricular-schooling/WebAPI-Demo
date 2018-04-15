export default {
  parseQuery: function (str) {
    if (typeof str !== 'string' || str.length === 0) {
      return {}
    }
    let qString = str.split('?')
    let s = qString[1].split('&')
    console.log(s)
    let sLength = s.length
    let bit = null
    let query = {}
    let first = null
    let second = null
    for (let i = 0; i < sLength; i++) {
      bit = s[i].split('=')
      first = decodeURIComponent(bit[0])
      if (first.length === 0) {
        continue
      }
      second = decodeURIComponent(bit[1])
      if (typeof query[first] === 'undefined') {
        query[first] = second
      } else if (query[first] instanceof Array) {
        query[first].push(second)
      } else {
        query[first] = [query[first], second]
      }
    }
    return query
  }
}
