/* eslint-disable */
export default {
  shuffleArray: function (oldArray) {
    let newArray = [].concat(oldArray)
    let currentIndex = newArray.length
    let temp
    let randomIndex

    while (currentIndex !== 0) {

      randomIndex = Math.floor(Math.random() * currentIndex)
      currentIndex -= 1

      temp = newArray[currentIndex]
      newArray[currentIndex] = newArray[randomIndex]
      newArray[randomIndex] = temp
    }

    return newArray
  }
}
