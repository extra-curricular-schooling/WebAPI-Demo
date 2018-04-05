<template>
  <div class="container is-fullhd">
    <section class="hero is-light">
      <div class="hero-body">
        <section class="columns is-gapless is-multiline is-mobile">
            <div class="column is-one-quarter">
              <div class="box">
                <aside class="menu">
                  <p class="menu-label">
                    General
                  </p>
                  <ul class="menu-list">
                    <li><a>Dashboard</a></li>
                    <li><a>Users</a></li>
                  </ul>
                  <p class="menu-label">
                    Administration
                  </p>
                  <ul class="menu-list">
                    <li><a>App Settings</a></li>
                    <li>
                      <a class="is-active">Manage Users</a>
                      <ul>
                        <li><a>Add a member</a></li>
                        <li><a>Add an admin</a></li>
                        <li><a>Edit members</a></li>
                      </ul>
                    </li>
                    <li><a>Invitations</a></li>
                    <li><a>Cloud Storage Environment Settings</a></li>
                    <li><a>Authentication</a></li>
                  </ul>
                </aside>
              </div>
            </div>
            <div class="column">
              <div class="box" style="height: 100%;">
              </div>
            </div>
          </section>
      </div>
    </section>
  </div>
</template>

<script>
export default {
  name: 'AccountAdmin'
}
</script>

<style scoped>

</style>
