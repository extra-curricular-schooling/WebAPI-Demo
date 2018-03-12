<template>
  <div id="app">
    <router-view/>
  </div>
</template>

<script>
/* eslint-disable */
import Bulma from 'bulma';
import Vue from "vue";
import FontAwesomeIcon from "@fortawesome/vue-fontawesome";

export default {
  // eslint-disable-next-line
  name: "App",
  // eslint-disable-next-line
  components: {
    'FontAwesomeIcon': FontAwesomeIcon
  }
};
</script>

<style>
#app {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #000000;
  margin-top: 10px;
}
h1 {
  font-family: "Days One";
  font-size: 24px;
  font-style: normal;
  font-variant: normal;
  font-weight: 500;
  line-height: 26.4px;
}

.registration-button {
  background-color: #209cee;
  padding: 15px 35px;
  color: white;
  font-size: 15px;
}
</style>
