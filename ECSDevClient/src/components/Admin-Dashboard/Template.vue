<template>
  <div class="container is-fullhd">
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
                    <li><a v-on:click="currentComponent = 'not-implemented'">Dashboard</a></li>
                    <li><a v-on:click="currentComponent = 'not-implemented'">Users</a></li>
                  </ul>
                  <p class="menu-label">
                    Administration
                  </p>
                  <ul class="menu-list">
                    <li><a>App Settings</a></li>
                    <li>
                      <a class="is-active">Manage Users</a>
                      <ul>
                        <li><a v-on:click="currentComponent = 'not-implemented'">Add a member</a></li>
                        <li><a v-on:click="currentComponent = 'not-implemented'">Add an admin</a></li>
                        <li><a v-on:click="currentComponent = 'account-status-panel'">Edit members</a></li>
                      </ul>
                    </li>
                    <li><a v-on:click="currentComponent = 'not-implemented'">Invitations</a></li>
                    <li><a v-on:click="currentComponent = 'not-implemented'">Cloud Storage Environment Settings</a></li>
                    <li><a v-on:click="currentComponent = 'not-implemented'">Authentication</a></li>
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
import RegistrationForm from '../registration-form/Template'
import AccountStatusPanel from '../AccountStatus-Panel/Template'
import NotImplemented from './elements/NotImplemented/Template'

export default {
  name: 'AdminDashboard',
  components: {
    'RegistrationForm': RegistrationForm,
    'AccountStatusPanel': AccountStatusPanel,
    'NotImplemented': NotImplemented
  },
  data () {
    return {
      currentComponent: 'not-implemented'
    }
  }
}
</script>
