<template>
<!-- Slideout menu created by slideout plug-in. It is toggled via the toggle-button on the home page. -->
    <Slideout id="slider" menu="#sidebar" panel="#EmbedContent" :toggleSelectors="['.toggle-button']">
        <nav id="sidebar">
          <div>Interests</div>
          <div class="container vue" id="Interests">
              <div class="column">
                <!-- If groups is instantiated with data from the server, display groups and articles. -->
                <div v-if='groups'>
                  <div id ="groups"  v-for="group in groups" :key="group.articles[0].interestTag">
                      <a id="groupName" v-text="group.name"  @click="collapse(group)" ></a>
                      <!-- Collapsable menus when interest tag is clicked. -->
                      <ul v-if="group.open">
                          <ul class="button" id="articles" v-for="article in group.articles" :key="article.title" v-text="article.title" v-on:click="target(group.name, article.title, article.url)">
                          </ul>
                      </ul>
                  </div>
                </div>
                <!-- If groups is not instantiated, tell user to add interest tags from account tab. -->
                <div v-else>Navigate to Account and select your Interests</div>
              </div>
          </div>
        </nav>
    </Slideout>
</template>

<script>
import EventBus from '@/assets/js/EventBus.js'
import Slideout from 'vue-slideout'
import Axios from 'axios'
// var groups = {}

export default {
  name: 'SideBar-Menu',
  components: {
    Slideout
  },
  methods: {
    // Run an axios request to get the articles based on the interest tag of a user.
    retieveArticles: function (username) {
      Axios({
        method: 'GET',
        url: this.$store.getters.getBaseAppUrl + 'Home/' + username + '/GetUserArticles',
        headers: this.$store.getters.getRequestHeaders
      })
      // Create groups based on interest tags and the articles. Each Interest Tag Group has many articles.
        .then((response) => {
          this.groups = {}
          response.data.$values.forEach(group => {
            this.groups[group.$values[0].interestTag] = {
              'name': group.$values[0].interestTag,
              'open': false,
              'articles': []
            }
            group.$values.forEach(article => {
              this.groups[article.interestTag].articles.push(
                {
                  'title': article.articleTitle,
                  'description': article.articleDescription,
                  'url': article.articleLink
                }
              )
            })
          })
        })
        .catch(e => {
          console.log(e)
          return e
        })
    },
    // Transfer article information for linked-in modal.
    target: function (tag, title, link) {
      document.getElementById('FrameResult').src = link
      this.$store.dispatch('updateInterestTag', tag)
      this.$store.dispatch('updateArticle', link)
      this.$store.dispatch('updateTitle', title)
      EventBus.$emit('articleChosen')
    },
    // Collapse function for groups.
    collapse: function (group) {
      group.open = !group.open
      this.$forceUpdate()
    }
  },
  // On Vue create, retrieve user articles.
  created () {
    this.retieveArticles(this.username)
  },
  data () {
    return {
      groups: null,
      username: this.$store.getters.getUsername,
      headers: this.$store.getters.getRequestHeaders
    }
  }
}
</script>
<style scoped>
   .slideout-menu {
    position: absolute;
    top:0;
    bottom: 0;
    width: 276px;
    height: 850px;
    z-index: 0;
    display: none;
    color: white;
    background-image: url('https://c.pxhere.com/photos/31/57/structure_texture_concrete_wall_concrete_wall_grain_background_grey-959987.jpg!d');
    overflow: hidden;
    box-shadow: 0px 0px 5px #fff;
  }
  /* display slide menu when slideout-open is true */
  .slideout-open .slideout-menu {
    display: block;
    overflow-y: scroll;
  }
  #Interests{
    width: 270px;
  }

  #articles{
    display: block;
    border: .3px solid;
    font-size:8pt;
  }
  #articles:active{
    color:brown;
  }

  #groups{
    display: block;
    border: .5px solid;
    cursor: pointer;
    padding: 5px;
    color: white;
  }
  #groups:active{
    color: #FFD1AA;
    box-shadow: 0 0 5px -1px rgba(0,0,0,0.6);
  }
  #groupName{
    color:white;
  }
  #groupName:active{
    color: #FFD1AA;
  }
</style>
