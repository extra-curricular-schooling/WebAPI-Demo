<template>
  <div class="container is-fullhd">
    <div v-if="isVisibleNotification" v-on:click="isVisibleNotification = false" class="notification is-danger">
      <button v-on:click="isVisibleNotification = false" class="delete"></button>
      {{notificationMessage}}
    </div>
    <section class="hero is-info">
      <div class="hero-body">
        <section class="columns is-gapless is-multiline is-mobile">
            <div class="column is-one-quarter">
              <div class="box" style="height: 100%;border-radius:0px;">
                <aside class="menu">
                  <p class="menu-label">
                    General
                  </p>
                  <ul class="menu-list">
                    <li><a v-on:click="currentComponent = 'not-implemented'">General Information</a></li>
                    <li><a v-on:click="currentComponent = 'change-password-panel'">Change Password</a></li>
                    <li><a v-on:click="currentComponent = 'interests'">Change Interest Tags</a></li>
                  </ul>
                </aside>
              </div>
            </div>
            <div class="column">
              <div class="box" style="height: 100%;border-radius:0px;background-color:#d8d8d8;">
                <keep-alive>
                  <component v-bind:is="currentComponent"></component>
                </keep-alive>
              </div>
            </div>
          </section>
      </div>
    </section>
  </div>
</template>

<script>
import ChangePasswordPanel from './elements/ChangePassword-Panel/Template'
import EventBus from '../../assets/js/EventBus'
import Interests from '@/components/interest-tag/Template'

export default {
  name: 'AccountSettingsPanel',
  components: {
    ChangePasswordPanel,
    Interests
  },
  created () {
    EventBus.$on('showSettingsNotification', () => {
      this.toggleNotification()
    })
  },
  data () {
    return {
      currentComponent: 'not-implemented',
      notificationMessage: '',
      isVisibleNotification: false
    }
  },
  methods: {
    toggleNotification: function () {
      this.notificationMessage = this.$store.getters.getSettingsNotificationMessage
      this.isVisibleNotification = true
    }
  }
}
</script>
