<template>
  <div class="container" style="height: 650px;">
    <div class="box" style="background-color: hsl(0, 0%, 96%); position: relative; top: 10%">
      <h1>Welcome to Sweepstake Entry.</h1>
      <h1> Buy A Ticket To Enter Into The Sweepstake.</h1>
      <h2> Just Follow These Steps To Enter Sweepstake</h2>
      <h2> * Check Whether a Sweepstake is Open *<br> * Buy Your Ticket *</h2>
      <h3> The more tickets you buy, the more chances you have to <b>WIN!</b> </h3>
      <template v-if="this.Points !== null">
        <h1> You have <b>{{this.Points}}</b> points!</h1>
      </template>
      <template v-else>
        <h1> We seem to have an issue retreiving your points. </h1>
      </template>
      <button v-if="this.collapsed === false" v-on:click="fetchValidSweepstakeInfo(Price, SweepStakesID, OpenDateTime, Prize, ClosedDateTime, collapsed)">Check SweepStake Availability</button>
      <template v-if="this.collapsed === true">
        <div>
          <h2>Current Sweepstake:</h2>
          <h3>Prize: {{this.Prize}} </h3>
          <h3>Closes: {{this.ClosedDateTime}} </h3>
          <h3>Points to Enter: {{this.Price}} </h3>
        </div>
         <button v-on:click="ticketBought(Points,Price,username,timeDateStamp)">Buy A Ticket for a Chance to Win!</button>
      </template>
    </div>
    <div style="height: 1px ;"/>
  </div>
</template>
<script>
import Vue from 'vue'
import moment from 'moment'
import Countdown from 'vuejs-countdown'
import Store from '@/store/index'
import Axios from 'axios'
import Swal from 'sweetalert2'
Vue.use(require('vue-moment'))
export default {
  name: 'prizes',
  data () {
    return {
      Points: null, // Points from the scholar account
      Price: '', // it is the Price of ticket for sweepstake that is set by admin
      username: this.$store.getters.getUsername,
      timeDateStamp: '', // the time date stamp is right in utc format
      SweepStakesID: '', // the ID of the sweepstake that is open
      OpenDateTime: '', // the opening date of the sweepstake
      Prize: '',
      ClosedDateTime: '', // the closing date of the sweepstake
      UserNameWinner: '',
      collapsed: false
    }
  },
  components: {
    Countdown
  },
  created () {
    this.fetchUserInfo(this.username, this.Points)
  },
  methods: {
    fetchUserInfo: function (username, Points) {
      Axios({
        // REQUEST TO GET THE SCHOLAR POINTS
        method: 'GET',
        url: Store.getters.getBaseAppUrl + 'Sweepstake/ScholarPoints/' + username,
        headers: Store.getters.getRequestHeaders
      })
        .then(response => {
          this.Points = response.data
        })
        .catch(error => {
          console.log(error.response)
          this.$data.error = JSON.parse(error.response.data)
          if (error.response.status === 500) {
            Swal('We apologize.  We are unable to process your request at this time.')
          }
        })
    },
    fetchValidSweepstakeInfo: function (Price, SweepStakesID, OpenDateTime, Prize, collapsed) {
      Axios({
        // REQUEST TO GET THAT WHETHER THE SWEEPSTAKE IS OPEN
        method: 'GET',
        url: Store.getters.getBaseAppUrl + 'SweepstakeAdmin/ValidSweepstakeInfo',
        headers: Store.getters.getRequestHeaders
      })
        .then(response => {
          console.log(response.data)
          if (response.data === 'Sweepstake Not Open') {
            Swal({
              text: 'No Sweepstakes are currently running. Check back later!',
              imageUrl: 'http://lasalleyachtclub.com/wp-content/uploads/2015/02/Please-Check-Back-Later.jpg'
            })
          } else {
            this.collapsed = true
            this.Price = response.data.price
            this.SweepStakesID = response.data.sweepStakesID
            this.OpenDateTime = moment(new Date(response.data.openDateTime)).utc().format('MM-DD-YYYY HH:mm')
            this.Prize = response.data.prize
            this.ClosedDateTime = moment(new Date(response.data.closedDateTime)).utc().format('MMMM DD, YYYY')
          }
        })
        .catch(error => {
          console.log(error.response)
          this.$data.error = JSON.parse(error.response.data)
          if (error.response.status === 500) {
            Swal('We apologize.  We are unable to process your request at this time.')
          }
        })
    },
    // REQUEST TO POST A SWEEPSTAKE TICKET TO A SWEEPSTAKE
    ticketBought: function (Points, Price, username, timeDateStamp, OpenDateTime, SweepStakesID) {
      if (this.Points >= this.Price & this.Points !== 0) {
        // remember the points should not be negative
        this.Points = this.Points - this.Price
        Axios({
          method: 'POST',
          url: Store.getters.getBaseAppUrl + 'Sweepstake/ScholarTicket/' + username,
          headers: Store.getters.getRequestHeaders,
          data: {
            'SweepstakesID': this.SweepStakesID,
            'OpenDateTime': this.OpenDateTime,
            'PurchaseDateTime': this.timeDateStamp,
            'Cost': this.Price, // this is the 'COST' the user has PAID for entering one sweepstake
            'username': this.username,
            'UpdatedPoints': this.Points
          }
        })
          .then(response => {
            console.log(response)
            if (response.data === 'Another Ticket Added') {
              Swal('Another Milestone Added Towards Your Win')
              Swal('Congragulations! \nOne ticket bought for ' + this.Price + ' points!\n You have ' + this.Points + ' Points remaining!')
            } else {
              Swal('Successfully Bought First Ticket')
              Swal('Congragulations! \nOne ticket bought for ' + this.Price + ' points!\n You have ' + this.Points + ' Points remaining!')
            }
          })
          .catch(error => {
            console.log(error.response)
            this.$data.error = JSON.parse(error.response.data)
            if (error.response.status === 500) {
              Swal('We apologize.  We are unable to process your request at this time.')
            }
          })
      } else {
        Swal({
          title: 'Sorry! You have Insufficient Points!',
          type: 'info'
        })
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
