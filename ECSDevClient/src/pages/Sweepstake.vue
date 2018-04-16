<template>
  <div>
    <!-- GET POINTS FIRST FROM USER ACCOUNT AND SOLVE THE ISSUE OF GETTING SCHOLAR POINTS -->
    <!-- thinking of changing the cost to the ticket number, which i can use to get the max number of tickets -->
    <h1>Welcome to Sweepstake Entry. Buy A Ticket To Enter Into The Sweepstake.</h1>
    <h1>Time Left</h1>
    <Countdown deadline="April 22, 2018"></Countdown>
    <!-- or
    <Countdown end="August 22, 2022"></Countdown> -->
    <button v-on:click="fetchUserInfo(username,Points)">Display Your Points First</button>
    <!-- <button v-on:click="fetchUserInfo(username,Points),ticketBought(Points,Cost)">Buy A Ticket</button> -->
    <button v-on:click="ticketBought(Points,Cost)">Buy A Ticket</button>
  </div>
</template>
<script>
import Vue from 'vue'
import moment from 'moment'
import Countdown from 'vuejs-countdown'
// import store from '@/store/index'
import axios from 'axios'
Vue.use(require('vue-moment'))
export default {
  name: 'prizes',
  data () {
    return {
      Points: '', // Points i get from the user account
      Cost: 0, // it is the Price of ticket from sweepstake admin
      username: this.$store.getters.getUsername,
      timeDateStamp: moment().utc('dddd, MMMM Do YYYY , hh:mm:ss').format() // the time date stamp is right in utc format
      // SweepStakesID: '7',
      // OpenDateTime: moment().utc('dddd, MMMM Do YYYY , hh:mm:ss').format()
    }
  },
  components: { Countdown },
  methods: {
    fetchUserInfo: function (username, Points) {
      axios({
        method: 'GET',
        url: this.$store.getters.getBaseAppUrl + 'v1/Sweepstake/ScholarPoints/' + username,
        headers: this.$store.getters.getRequestHeaders
      })
        .then(response => {
          console.log(response.data)
          this.Points = response.data
          alert('Points are ' + this.Points)
          // return Points
          // JSON.parse(response.data)
          // this.$data.points = JSON.parse(response.data)
          // console.log('Points', response.data)
          // response.data.Points
          // console.log(response.Points)
        })
        .catch(error => {
          console.log(error.response)
          this.$data.error = JSON.parse(error.response.data)
          if (error.response.status === 500) {
            alert('We apologize.  We are unable to process your request at this time.')
          }
        })
    },
    ticketBought: function (Points, Cost) {
      if (Points >= Cost) {
        alert('Congragulations! One ticket bought for ' + Cost + ' points! Your Points are ' + Points)
        Points = Points - Cost
        alert('Points left = ' + Points)
        // axios({
        //   // get request for sweepstake id and open date time from the sweepstake admin database table
        //   method: 'POST',
        //   // url: this.$store.getters.getBaseAppUrl + 'v1/SweepstakeAdmin/submitSweepstake',
        //   url: 'https://localhost:44311/v1/Sweepstake/submitSweepstake',
        //   headers: store.getters.getRequestHeaders,
        //   data: {
        //     // 'SweepstakesID': this.$data.SweepStakesID,
        //     // 'OpenDateTime': this.$data.timeDateStamp, // change it later to open date time
        //     'PurchaseDateTime': this.$data.timeDateStamp,
        //     'Cost': this.$data.Cost
        //     // 'Price': this.$data.Price,
        //     // 'username': this.$data.username
        //   }
        // })
        //   .then(response => {
        //     console.log(response)
        //     this.$router.push({
        //       name: 'Sweepstake'
        //       // params: { isSuccess: true }
        //     })
        //   })
        //   .catch(error => {
        //     console.log(error.response)
        //     this.$data.error = JSON.parse(error.response.data)
        //     if (error.response.status === 500) {
        //       alert('We apologize.  We are unable to process your request at this time.')
        //     }
        //   })
      } else {
        alert('Sorry! You have Insufficient Points!')
      }
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
