<template>
<div class="SweepstakeAdminPage">
    <h1>Admin Page to Set Sweepstake Settings</h1>
    <h2>Admin Can Set Sweepstake Open/Close Date, Sweepstake ID, Ticket Price, & Prize.</h2>
    <div class="dates">
      <!-- date in utc -->
      <!-- v2-datepicker license MIT -->
      <v2-datepicker v-model="OpenDateTime" lang="en" format="MM/DD/YYYY" placeholder="Opening Date"></v2-datepicker>
      <p>Admin Selected Opening Date: {{OpenDateTime}}</p>
      <v2-datepicker v-model="ClosedDateTime" lang="en" format="MM/DD/YYYY" placeholder="Closing Date"></v2-datepicker>
      <p>Admin Selected Closing Date: {{ClosedDateTime}}</p>
      <p v-if="OpenDateTime>ClosedDateTime">Wrong Close Date Entered</p>
    </div>
    <div class="settings">
      <input type="number" v-model.lazy="Price" placeholder="Ticket Price">
      <p>Admin Selected Ticket Price: {{ Price }}</p>
      <input type="text" v-model.lazy="Prize" placeholder="Prize Sweepstake">
      <p>Admin Selected Prize: {{ Prize }}</p>
      <button v-on:click.prevent="submitSweepstake(OpenDateTime,ClosedDateTime,Prize,UsernameWinner,SweepStakesID,Price)">Submit Sweepstake</button>
    </div>
    <!-- button to POST SWEEPSTAKE to the database -->
    <div class ="submission">
      <button v-on:click="CloseSweepstake(winningTicket)">Close Sweepstake/Select the Winner</button>
    </div>
</div>
</template>

<script>
import Vue from 'vue'
import V2Datepicker from 'v2-datepicker'
import 'v2-datepicker/lib/index.css'
import Axios from 'axios'
import Store from '@/store/index'
import Swal from 'sweetalert2'
Vue.use(V2Datepicker)

export default {
  name: 'sweepstake',
  data () {
    return {
      OpenDateTime: '',
      ClosedDateTime: '',
      Prize: '',
      UsernameWinner: 'No Winner',
      SweepStakesID: '',
      winningTicket: '',
      Price: '',
      username: this.$store.getters.getUsername
    }
  },
  methods: {
    submitSweepstake: function (OpenDateTime, ClosedDateTime, Prize, UsernameWinner, SweepStakesID, Price, username) {
      Axios({
        method: 'POST',
        url: Store.getters.getBaseAppUrl + 'SweepstakeAdmin/SubmitSweepstake/' + this.username,
        headers: Store.getters.getRequestHeaders,
        data: {
          'SweepStakesID': this.SweepStakesID, // ID DOESN't GO
          'OpenDateTime': this.OpenDateTime,
          'ClosedDateTime': this.ClosedDateTime,
          'Prize': this.Prize,
          'Price': this.Price,
          'UsernameWinner': this.UsernameWinner
        }
      })
        .then(response => {
          console.log(response)
          if (response.data === 'Wrong Sweepstakes Dates') {
            Swal('Wrong Sweepstakes Dates')
          } else { Swal('Sweepstake Set') }
          this.$router.push({
            name: 'SweepstakeAdmin'
          })
        })
        .catch(error => {
          console.log(error.response)
          this.$data.error = JSON.parse(error.response.data)
          if (error.response.status === 500) {
            Swal('We apologize.  We are unable to process your request at this time.')
          }
        })
    },
    CloseSweepstake: function () {
      // look at the corresponding username and notify that user
      Axios({
        method: 'GET',
        url: Store.getters.getBaseAppUrl + 'SweepstakeAdmin/CloseSweepstake',
        headers: Store.getters.getRequestHeaders
      })
        .then(response => {
          console.log(response)
          if (response.data === 'No Winner') {
            Swal('No Winner.')
          } else { Swal('Winner: ' + response.data + '! Sweepstake Closed') }
          this.$router.push({
            name: 'SweepstakeAdmin'
          })
        })
        .catch(error => {
          console.log(error.response)
          this.$data.error = JSON.parse(error.response.data)
          if (error.response.status === 500) {
            Swal('We apologize.  We are unable to process your request at this time.')
          }
        })
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
input {
    width: 200px;
    height: 40px;
}
v2-datepicker {
  size: 30cm;
  padding: 30px
}
.dates:after {
  content: "\A";
  white-space: pre;
  size: 30cm;
}

.dates:before {
  content: "\A";
  white-space: pre;
}
.prize:after {
  content: "\A";
  white-space: pre;
  size: 30cm;
}

.prize:before {
  content: "\A";
  white-space: pre;
}
.submission:after {
  content: "\A";
  white-space: pre;
  size: 30cm;
}

.submission:before {
  content: "\A";
  white-space: pre;
  size: 30cm;
}
</style>
