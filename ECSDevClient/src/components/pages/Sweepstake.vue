<template>
  <div>
    <h1>Welcome to Sweepstakes.</h1>
    <h1>Time Left</h1>
    <Countdown deadline="March 22, 2018"></Countdown>
    <!-- or
    <Countdown end="August 22, 2022"></Countdown> -->
    <button v-on:click="ticket_bought">Buy A Ticket</button>
  </div>
</template>
<script>
// import Vue from 'vue'
import Countdown from 'vuejs-countdown'
export default {
  data: function () {
    return {
      points: 5
    }
  },
  components: { Countdown },
  methods: {
    ticket_bought: function () {
      alert('One Ticket Bought for ' + this.points)
    }
    // hehe: function () {
    //   alert('you are stupid')
    // }put if statements for points if points greater than 5 do this or else do that
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
