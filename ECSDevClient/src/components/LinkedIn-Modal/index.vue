<template>
  <div>
    <button v-if="isButtonVisible" v-on:click="modalActions" class="button is-primary">Share on LinkedIn!</button>
    <div class="modal" v-bind:class="{ 'is-active' : isActive }">
      <div v-on:click="toggleLinkedInModal" class="modal-background"></div>
      <div id="linkedin-modal" class="modal-card">
        <header class="modal-card-head">
          <p class="modal-card-title">Share this article on LinkedIn!</p>
          <button class="delete" aria-label="close" v-on:click="toggleLinkedInModal"></button>
        </header>
        <section id="linkedin-modal-body" class="modal-card-body">
          <p class="warning field-element">* indicates a required field</p>
          <div class="is-field-group">
            <div class="field comment">
              <label class="label field-element is-required">Comment</label>
              <div class="control">
                <input v-model="postData.comment" class="input" type="text" placeholder="Comment" required>
              </div>
            </div>
            <div class="field comment">
              <label class="label field-element is-required">Privacy Settings</label>
              <input type="radio" id="public" value="public" v-model="postData.code">
              <label for="public">Public</label>
              <br>
              <input type="radio" id="connections-only" value="connections-only" v-model="postData.code">
              <label for="connections-only">Connections Only</label>
            </div>
          </div>
        </section>
        <section id="linkedin-preview" class="hero is-info">
          <div class="hero-body">
            <a>Preview</a>
            <div class="box">
              <article class="media">
              <figure class="media-left">
                <p class="image is-64x64">
                  <img src="https://bulma.io/images/placeholders/128x128.png">
                </p>
              </figure>
                <div class="media-content">
                  <div class="content">
                    <p>
                      <strong>John Smith</strong><br>
                      <small>Occupation here.</small><br>
                      <small>{{currentDateTime.toString()}}</small><br>
                      <br>
                      {{postData.comment}}
                    </p>
                  </div>
                  <div class="container is-fluid">
                    <div class="card is-fluid">
                      <div class="card-image">
                        <figure class="image is-square">
                          <img src="https://media.licdn.com/media/AAMABABqAAIAAQAAAAAAAA7yAAAAJGU1OTQ2NGFlLTNjNzEtNGZjOS04NjVkLWIxNjQ4NTY5ZjNlYw.png" alt="Placeholder image">
                        </figure>
                      </div>
                      <footer class="card-footer">
                        <span class="card-footer-item">
                          <span class="content">
                            {{postData.title}}
                            <br>
                            <small>{{postData.submittedurl}}</small>
                          </span>
                        </span>
                      </footer>
                    </div>
                  </div>
                  <hr class="dropdown-divider">
                  <nav class="level is-mobile">
                    <div class="level-left">
                      <a class="level-item">
                        <span class="icon is-small"><i class="fas fa-reply"></i></span>
                      </a>
                      <a class="level-item">
                        <span class="icon is-small"><i class="fas fa-retweet"></i></span>
                      </a>
                      <a class="level-item">
                        <span class="icon is-small"><i class="fas fa-heart"></i></span>
                      </a>
                    </div>
                  </nav>
                </div>
                <div class="media-right">
                  <button class="delete"></button>
                </div>
              </article>
            </div>
          </div>
        </section>
        <footer class="modal-card-foot">
          <button id="linkedin-submit-button" class="button is-success" v-on:click="shareToLinkedIn">Post on LinkedIn</button>
          <button class="button" v-on:click="toggleLinkedInModal">Cancel</button>
        </footer>
      </div>
    </div>
    <div class="modal" v-bind:class="{ 'is-active' : isConfirm }">
      <div class="modal-background"></div>
      <div id="linkedin-modal" class="modal-card">
        <header class="modal-card-head">
          <p class="modal-card-title">Article has been shared on LinkedIn!</p>
          <button class="delete" aria-label="close" v-on:click="toggleConfirmModal"></button>
        </header>
        <section id="linkedin-modal-body" class="modal-card-body">
          <p>View the article </p><a id="post-url" href="">here</a>
        </section>
        <footer class="modal-card-foot">
          <button id="linkedin-submit-button" class="button is-success" v-on:click="toggleConfirmModal">Close</button>
        </footer>
      </div>
    </div>
  </div>
</template>

<script>
import Axios from 'axios'
import EventBus from '../../assets/js/EventBus.js'

export default {
  name: 'LinkedInPostModal',
  data() {
    return {
      isActive: false,
      isButtonVisible: true,
      isConfirm: false,
      isRedirect: false,
      postData: {
        comment: 'Check this article I found on ECS!',
        title: '',
        description: '',
        submittedurl: '',
        code: 'connections-only'
      },
      currentDateTime: new Date()
    }
  },
  methods: {
    updateArticleInfo: function () {
      this.postData.title = this.$store.getters.getArticleTitle
      this.postData.submittedurl = this.$store.getters.getCurrentArticle
      this.currentDateTime = new Date()
    },
    toggleLinkedInModal: function() {
      this.isActive = !this.isActive;
    },
    modalActions: function () {
      this.updateArticleInfo()
      this.toggleLinkedInModal()
    },
    toggleConfirmModal: function() {
      this.isConfirm = !this.isConfirm;
    },
    toggleRedirectModal: function () {
      this.$store.dispatch('updateRedirectUri', 'https://localhost:44311/OAuth/RedirectToLinkedIn?authtoken=' +
          this.$store.getters.getAuthToken + '&returnuri=' + window.location.href)
      this.$store.dispatch('updateErrorMessage', 'Your LinkedIn session has expired, do you wish to renew it?')
      this.$store.dispatch('updateRedirectVisiblity', true)
      EventBus.$emit('redirect')
    },
    redirectToLinkedIn: function () {
      window.location.assign(
        'https://localhost:44311/OAuth/RedirectToLinkedIn?authtoken=' +
          this.$store.getters.getAuthToken + '&returnuri=' + window.location.href
      )
    },
    shareToLinkedIn: function() {
      Axios({
        method: 'POST',
        url: this.$store.getters.getLinkedInPostURI,
        headers: this.$store.getters.getRequestHeaders,
        data: {
          comment: this.postData.comment,
          title: this.postData.title,
          description: this.postData.description,
          submittedurl: this.postData.submittedurl,
          code: this.postData.code
        }
      })
        .then(function(response) {
          toggleLinkedInModal();
          var myNode = document.getElementById("post-url");
          myNode.href = response.data.UpdateUrl;
          toggleConfirmModal();
        })
        .catch( (error) => {
          if(error.response.data.message === 'ERR7') {
            this.toggleLinkedInModal()
            this.toggleRedirectModal()
          }
        })
    }
  }
}
</script>

<style scoped>
.field-element {
  text-align: left;
}

.is-field-group:after {
  content: "\A";
  white-space: pre;
}

.is-field-group:before {
  content: "\A";
  white-space: pre;
}

.is-required:after {
  content: " *";
  color: red;
}

.modal-content {
  padding-top: 100px;
}

.warning {
  color: red;
  font-size: 12px;
}
</style>
