<template>
  <div>
    <h1>Welcome to Sweepstake Entry. Buy A Ticket To Enter Into The Sweepstake.</h1>
    <h1>Time Left</h1>
    <Countdown deadline="April 22, 2018"></Countdown>
    <!-- or
    <Countdown end="August 22, 2022"></Countdown> -->
    <button v-on:click="ticketBought(totalPoints,ticketPrice),timeStamp(timeDateStamp)">Buy A Ticket</button>
    <div class="timeStamp">
    <!-- <h2>{{new Date() | moment("dddd, MMMM Do YYYY , hh:mm:ss a")}}</h2> -->
    <!-- <button v-on:click="timeStamp(timeDateStamp)">Create Time Stamp in UTC</button> -->
    </div>
  </div>
</template>
<script>
import Vue from 'vue'
import moment from 'moment'
// timestamp pattern 2018-03-06 16:46:08.433 use the UTC only
// sweepstake main in which we have sweepstake id, date open and close, prize, username who wins.
// now we have a seperate sweepstake entry in which we have a ticket purchase timestamp, the cost, the username of who bought the ticket,
// sweepstake open date like when a sweepstake ticket can be bought the date open and close. we need an isActive flag too.
import Countdown from 'vuejs-countdown'
Vue.use(require('vue-moment'))
export default {
  name: 'prizes',
  data () {
    return {
      totalPoints: 10,
      ticketPrice: 5,
      timeDateStamp: ' '
    }
  },
  components: { Countdown },
  methods: {
    ticketBought: function (totalPoints, ticketPrice) {
      if (totalPoints >= ticketPrice) {
        alert('Congragulations! One ticket bought for ' + ticketPrice + ' points!')
        totalPoints = totalPoints - ticketPrice
        alert('Points left = ' + totalPoints)
        return totalPoints
      } else {
        alert('Sorry! You have Insufficient Points!')
      }
    },
    timeStamp: function (timeDateStamp) {
      timeDateStamp = moment().utc('dddd, MMMM Do YYYY , hh:mm:ss').format()
      alert(timeDateStamp)
      return timeDateStamp
    }
  }
}
</script>
<style scoped>
button {
  background-color: #E8E9E4;
  color: black;
  padding: 14px 20px;
  margin: 8px 0;
  border: none;
  cursor: pointer;
  width: 270px;
  opacity: 0.9;
}

button:hover {
    opacity:1;
}
</style>
