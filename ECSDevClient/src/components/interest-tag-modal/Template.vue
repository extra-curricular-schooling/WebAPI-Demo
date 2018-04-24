<template>
  <form class="box">
      <fieldset v-if='tags' class='checklist'>
          <h1 id='Title'>Select Your Interests</h1>
          <div v-for='tag in tags' v-bind:key='tag.name'>
              <input type='checkbox' class='cb' v-model='tag.checked' >
              <label :for='tag.name'> {{tag.name}}</label><br>
          </div>
           <div class="container is-fluid">
            <button class="button is-primary submit-button" v-on:click.prevent="submit">
            Save
            </button>
          </div>
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
  position: 50%;
}
label {
  top: -4px;
  width:150px;
  position:relative;
  display:inline-block;
  vertical-align:middle;
}
 .cb {
  -webkit-appearance: none;
  background-color: #fafafa;
  border: 1px solid #cacece;
  box-shadow: 0 1px 2px rgba(0,0,0,0.05), inset 0px -15px 10px -12px rgba(0,0,0,0.05);
  padding: 9px;
  border-radius: 3px;
  display: inline-block;
  position: relative;
}
.cb:active, .cb:checked:active {
  box-shadow: 0 1px 2px rgba(0,0,0,0.05), inset 0px 1px 3px rgba(0,0,0,0.1);
}
.cb:checked {
  background-color:turquoise ;
  border: 1px solid #adb8c0;
  box-shadow: 0 1px 2px rgba(0,0,0,0.05), inset 0px -15px 10px -12px rgba(0,0,0,0.05), inset 15px 10px -12px rgba(255,255,255,0.1);
}
.cb:checked:after {
  content: '\2714';
  font-size: 14px;
  position: absolute;
  top: 0px;
  left: 3px;
  color: #fff;
}
.cb:checked+label {
  position: relative;
  width: 150px;
  top: -4px;
  cursor: pointer;
  display:inline-block;
  vertical-align:middle;
  border: turquoise;
}

</style>
