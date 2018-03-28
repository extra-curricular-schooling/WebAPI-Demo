<template>
  <div class="modal" v-bind:class="{ 'is-active' : isActive }">
    <div class="modal-background"></div>
    <div class="modal-content">
      <div class="box">

        <span class="header">
          <h1>Forgot Password</h1><br>
        </span>

        <div class="body" v-if="body==='firstStep'">
          <p>Forgot your password?  No worries.</p>
          <p>We just need information you used to register.</p><br>
          <div class="field username">
            <label class="label field-element is-required">Username</label>
            <div class="control has-icons-left has-icons-right">
              <!-- <input v-model="username" id="username" class="input" type="text" @keyup="validateUsername" autocomplete="username" placeholder="Username" required> -->
              <input class="input" type="text" placeholder="Username">
              <span class="icon is-small is-left">
                <i class="fas fa-user"></i>
              </span>
            </div>
          </div>
          <!-- <forgot-username ref="username"/>
          <a class="no-username" @click.prevent="getUsername">I don't remember my username.</a><br> -->
        </div>

        <div class="body" v-if="body==='secondStep'">
          <!-- BEGIN required security questions -->
          <div class="is-field-group">
            <div class="field security-questions">
              <label class="label field-element is-required">Security Questions</label>
              <div class="control">
                <!-- <input v-model="question1" class="input" type="number" placeholder="Question 1" required> -->
                <span class="select">
                  <select v-model="question1">
                    <option disabled value="">--select--</option>
                  </select>
                  <!-- <select @change="getSelectionID(0, question1)" v-model="question1">
                    <option disabled value="">--select--</option>
                    <option v-for="question in questions" v-bind:key="question.SecurityQuestionID"> {{ question.SecQuestion }} </option>
                  </select> -->
                </span>
              </div>
            </div>
            <div class="field security-questions-answers">
              <div class="control">
                <!-- <input id="answer1" class="input" type="text" @keyup="validateAnswers" placeholder="Answer 1" required> -->
                <input id="answer1" class="input" type="text" placeholder="Answer 1" required>
              </div>
            </div>

            <div class="field security-questions">
              <div class="control">
                <!-- <input v-model="question2" class="input" type="number" placeholder="Question 2" required> -->
                <span class="select">
                  <select v-model="question1">
                    <option disabled value="">--select--</option>
                  </select>
                  <!-- <select @change="getSelectionID(1, question2)" v-model="question2">
                    <option disabled value="">--select--</option>
                    <option v-for="question in questions" v-bind:key="question.SecurityQuestionID"> {{ question.SecQuestion }} </option>
                  </select> -->
                </span>
              </div>
            </div>
            <div class="field security-questions-answers">
              <div class="control">
                <!-- <input id="answer2" class="input" type="text" @keyup="validateAnswers" placeholder="Answer 2" required> -->
                <input id="answer1" class="input" type="text" placeholder="Answer 2" required>
              </div>
            </div>

            <div class="field security-questions">
              <div class="control">
                <!-- <input v-model="question3" class="input" type="number" placeholder="Question 1" required> -->
                <span class="select">
                  <select v-model="question1">
                    <option disabled value="">--select--</option>
                  </select>
                  <!-- <select @change="getSelectionID(2, question3)" v-model="question3">
                    <option disabled value="">--select--</option>
                    <option v-for="question in questions" v-bind:key="question.SecurityQuestionID"> {{ question.SecQuestion }} </option>
                  </select> -->
                </span>
              </div>
            </div>
            <div class="field security-questions-answers">
              <div class="control">
                <!-- <input id="answer3" class="input" type="text" @keyup="validateAnswers" placeholder="Answer 3" required> -->
                <input id="answer1" class="input" type="text" placeholder="Answer 3" required>
              </div>
            </div>
            <!-- <p id="answersControl" class="help">{{ answersMessage }}</p> -->
          </div>
          <!-- END security questions -->
        </div>

        <div class="body" v-if="body==='thirdStep'">
          <p>Please enter a <strong>new password</strong><p>
          <div class="field password">
            <label class="label field-element is-required">New Password</label>
            <div class="control has-icons-left">
              <!-- <input id="password" class="input" type="password"  @keyup="validatePassword" autocomplete="new-password" placeholder="************" required> -->
              <input id="password" class="input" type="password" placeholder="************" required>
              <span class="icon is-small is-left">
                <i class="fas fa-lock"></i>
              </span>
            </div>
            <!-- <p id="passwordControl" class="help">{{ passwordMessage }}</p> -->
          </div>

          <div class="field confirm-password">
            <label class="label field-element is-required">Confirm New Password</label>
            <div class="control has-icons-left">
              <!-- <input id="confirmPassword" class="input" type="password" @keyup="validateConfirmPassword" autocomplete="new-password" placeholder="************" required> -->
              <input id="confirmPassword" class="input" type="password" placeholder="************" required>
              <span class="icon is-small is-left">
                <i class="fas fa-lock"></i>
              </span>
            </div>
            <!-- <p id="confirmPasswordControl" class="help">{{ confirmPasswordMessage }}</p> -->
          </div>
        </div>

        <div class="body" v-if="body==='success'">
          <p>Congratulations!  You have successfully changed your password.</p>
        </div>

        <br>
        <div class="field is-grouped is-grouped-centered form-buttons">
          <p class="control" v-if="body!=='success'">
            <button class="button is-link cancel-button" v-on:click.prevent="cancel">
            Cancel
            </button>
          </p>

          <p class="control" v-if="body==='firstStep'">
            <button class="button is-primary submit-button" v-on:click.prevent="next">
            Next
            </button>
          </p>

          <p class="control" v-if="body==='secondStep'">
            <button class="button is-primary submit-button" v-on:click.prevent="submit">
            Submit
            </button>
          </p>

          <p class="control" v-if="body==='thirdStep'">
            <button class="button is-primary submit-button" v-on:click.prevent="complete">
            Complete
            </button>
          </p>

          <p class="control" v-if="body==='success'">
            <button class="button is-primary submit-button" v-on:click.prevent="close">
            Awesome!
            </button>
          </p>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
// import forgotUsername from '@/components/Forgot-Username-Modal/index'
export default {
  name: 'ForgotPassword',
  // components: {
  //   'forgot-username': forgotUsername
  // },
  data () {
    return {
      isActive: false,
      body: 'firstStep',
      question1: '',
      question2: '',
      question3: ''
    }
  },
  methods: {
    toggle () {
      this.isActive = !this.isActive
    },
    next () {
      this.body = 'secondStep'
    },
    cancel () {
      this.toggle()
      this.body = 'firstStep'
    },
    submit () {
      this.body = 'thirdStep'
    },
    complete () {
      this.body = 'success'
    },
    close () {
      this.toggle()
      this.body = 'firstStep'
    }
    // getUsername () {
    //   this.close()
    //   this.$refs.username.toggle()
    // }
  }
}
</script>

<style scoped>
.field-element {
  text-align: left;
}

.no-username {
  float: left;
}
</style>
