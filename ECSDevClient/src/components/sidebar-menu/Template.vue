<template>
    <Slideout id="slider" menu="#sidebar" panel="#EmbedContent" :toggleSelectors="['.toggle-button']">
        <nav id="sidebar">
        <div>Interests</div>
            <div class="container vue" id="Interests">
                <div class="column">
                    <div id ="groups"  v-for="group in groups" :key="group.articles[0].interestTag">
                        <a id="groupName" v-text="group.name"  @click="collapse(group)" ></a>
                        <ul v-if="group.open">
                            <ul class="button is-link" id="articles" v-for="article in group.articles" :key="article.title" v-text="article.title" v-on:click="target(group.name, article.title, article.url)">
                            </ul>
                        </ul>
                    </div>
                </div>
            </div>
        </nav>
    </Slideout>
</template>

<script>
import EventBus from '@/assets/js/EventBus.js'
import Slideout from 'vue-slideout'
import Axios from 'axios'
var groups = {}

export default {
  name: 'SideBar-Menu',
  components: {
    Slideout
  },
  methods: {
    retieveArticles: function (username) {
      Axios({
        method: 'GET',
        url: this.$store.getters.getBaseAppUrl + 'Home/' + username + '/GetUserArticles',
        headers: this.$store.getters.getRequestHeaders
      })
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
    target: function (tag, title, link) {
      document.getElementById('FrameResult').src = link
      this.$store.dispatch('updateInterestTag', tag)
      this.$store.dispatch('updateArticle', link)
      this.$store.dispatch('updateTitle', title)
      EventBus.$emit('articleChosen')
    },
    collapse: function (group) {
      group.open = !group.open
      this.$forceUpdate()
    }
  },
  created () {
    this.retieveArticles(this.username)
  },
  data () {
    return {
      groups: groups,
      username: this.$store.getters.getUsername,
      headers: this.$store.getters.getRequestHeaders
    }
  }
}
</script>
<style scoped>
   .slideout-menu {
    position: fixed;
    top: 0;
    bottom: 0;
    width: 276px;
    height: 100vh;
    z-index: 0;
    display: none;
    background-color: #1D1F20;
    color: white;
  }
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
    font-size:8pt
  }
  #articles:active{
    color:white;
  }

  #groups{
    display: block;
    border: .5px solid;
    cursor: pointer;
    padding: 5px;
    color: white;
  }
  #groups:active{
    color: blue;
    box-shadow: 0 0 5px -1px rgba(0,0,0,0.6);
  }
  #groupName{
    color:white;
  }
  #groupName:active{
    color:blue;
  }
</style>
