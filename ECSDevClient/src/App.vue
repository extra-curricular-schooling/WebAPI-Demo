<template>
  <div id="app">
    <router-view/>
  </div>
</template>

<script>
import Bulma from 'bulma'
// eslint-disable-next-line
import Vue from 'vue'

export default {
  name: 'App',
  components: {
    Bulma
  },
  data () {
    return {
      lockedPaths: ['/Home']
    }
  },
  methods: {
    checkCurrentLogin () {
      for (var path in this.lockedPaths) {
        if (!this.$store.getters.isAuth && this.$route.path === this.lockedPaths[path]) {
          this.$router.push('/?redirect=' + this.$route.path)
        }
      }
    }
  },
  created () {
    this.checkCurrentLogin()
  },
  updated () {
    this.checkCurrentLogin()
  }
}
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
