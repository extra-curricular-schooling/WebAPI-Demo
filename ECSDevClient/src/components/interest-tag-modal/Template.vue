<template>
  <form>
      <fieldset v-if='tags' class='checklist'>
          <h1 id='Title'>Select Your Interests</h1>
          <div v-for='tag in tags' v-bind:key='tag.name'>
              <input type='checkbox' v-model='tag.checked' >
              <label :for='tag.name'> {{tag.name}}</label><br>
          </div>
           <p class="control">
            <button class="button is-primary submit-button" v-on:click.prevent="submit">
            Save
            </button>
          </p>
      </fieldset>
      <fieldset v-else>Something is wrong, please refresh. If issue persists, contact Scott Roberts.</fieldset>
  </form>
</template>

<script>
import Axios from 'axios'
export default {
  name: 'interestTags',
  created () {
    window.onload = this.retrieveInterestTags()
  },
  methods: {
    retrieveInterestTags: function () {
      Axios({
        method: 'GET',
        url: this.$store.getters.getBaseAppUrl + 'Account/RetrieveInterestTags',
        headers: this.$store.getters.getRequestHeaders
      })
        .then((response) => {
          this.tags = {}
          response.data.$values.forEach(tag => {
            this.tags[tag] = {
              'name': tag,
              'checked': false
            }
          })
        })
        .then(() => {
          this.getUserInterestTags()
        })
        .catch(e => {
          console.log(e)
          return e
        })
    },
    getUserInterestTags: function () {
      Axios({
        method: 'GET',
        url: this.$store.getters.getBaseAppUrl + 'Account/' + this.username + '/GetInterests',
        headers: this.$store.getters.getRequestHeaders
      })
        .then((response) => {
          response.data.$values.forEach(tag => {
            this.tags[tag] = {
              'name': tag,
              'checked': true
            }
          })
          this.$forceUpdate()
        })
    },
    submit: function () {
      if (!this.isInterestChecked()) {
        alert('You must select at least one interest.')
      } else {
        this.updateInterestTags()
      }
    },
    isInterestChecked: function () {
      var checked = false
      for (var tag in this.tags) {
        if (this.tags[tag].checked) {
          this.checkedTags.push(tag)
          checked = true
        }
      }
      if (checked) {
        return true
      } else {
        return false
      }
    },
    updateInterestTags: function () {
      Axios({
        method: 'POST',
        url: this.$store.getters.getBaseAppUrl + 'Account/' + this.username + '/UpdateInterests',
        headers: this.$store.getters.getRequestHeaders,
        data: {
          'Account': this.$store.getters.getUsername,
          'interestTags': this.checkedTags
        }
      })
        .then((response) => {
          alert(response.data)
        })
        .catch(e => {
          alert(e)
          return e
        })
    }
  },
  data () {
    return {
      tags: [],
      checkedTags: [],
      username: this.$store.getters.getUsername
    }
  }
}
</script>

<style scoped>
button {
  width: 175px;
  position: relative;
}
/* input {
  width: 20px;
  position: relative;
  left: 200px;
  vertical-align: middle;
} */

label {
  width:100px;
  position:relative;
  display:inline-block;
  vertical-align:middle;
}

p {
  left: 44%;
}
</style>
