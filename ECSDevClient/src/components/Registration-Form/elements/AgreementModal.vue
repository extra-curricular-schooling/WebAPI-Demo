<template>
  <div class="modal" v-bind:class="{ 'is-active' : isActive }">
    <div class="modal-background">
      <div class="modal-card">
        <header class="modal-card-head">
          <p class="modal-card-title">Terms and Conditions</p>
          <button v-on:click.prevent="toggle" class="delete" aria-label="close"></button>
        </header>
        <section class="modal-card-body">
          <p class="body">
            <span v-html="body"></span>
          </p>
        </section>
        <!-- <footer class="modal-card-foot">
        </footer> -->
      </div>
    </div>
  </div>
</template>

<script>
/* eslint-disable */
import content from '!!html-loader!@/assets/raw/agreement-content.html'
export default {
  name: 'AgreementModal',
  data () {
    return {
      // Event properties
      isActive: false,

      // Properties
      body: content
    }
  },
  methods: {
    // ************************* Togglers *************************
    /**
     * @description
     * toggles agreement modal to serve terms and conditions
     */
    toggle: function () {
      this.isActive = !this.isActive
    }
  }
}
</script>

<style scoped>
.body {
  text-align: justify;
}
.delete {
  position: relative;
}
.modal-card {
  top: 20px;
}
</style>
