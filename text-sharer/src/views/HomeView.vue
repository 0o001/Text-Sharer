<template>
  <form ref="shareForm" id="shareForm" @submit.prevent="share">
    <TextArea />
    <div class="container">
      <div class="captcha">
        <vue-recaptcha ref="recaptcha" @verify="handleSuccess" sitekey="6LdBkNMiAAAAAMNgrhp1A1PEvZo1funohovlt9D5" />
      </div>
      <button ref="submit" type="submit" class="btn" :disabled="isCaptchaVerified">Share</button>
    </div>
  </form>
</template>

<style scoped>
.container {
  text-align: center;
  padding-bottom: 20px;
}
.btn {
  background: hsl(48deg 89% 50%);
  color: var(--color-background);
  padding: 10px;
  padding-left: 25px;
  padding-right: 25px;
  border-color: var(--color-border);
  border-radius: 3px;
  cursor: pointer;
}
.btn:disabled {
  background: rgb(98, 98, 98);
  cursor: no-drop;
}
.captcha {
  margin: 15px auto !important;
  width: auto !important;
  height: auto !important;
  text-align: -webkit-center;
  text-align: -moz-center;
  text-align: -o-center;
  text-align: -ms-center;
}
</style>

<script lang="ts">
  import TextArea from '../components/TextArea.vue'
  import { VueRecaptcha } from 'vue-recaptcha'
  import { getCurrentInstance } from 'vue'

  export default {
    data() {
      return {
        isCaptchaVerified: false,
        captchaResponse: '',
        API_URL: getCurrentInstance()?.appContext.config.globalProperties.API_URL
      }
    },
    components: {
      TextArea,
      VueRecaptcha
    },
    methods: {
      handleSuccess(response: string): void {
        this.captchaResponse = response
        this.isCaptchaVerified = true
      },
      share(): void {
        this.isCaptchaVerified = false
        const shareForm: any = this.$refs.shareForm
        const formData = new FormData(shareForm)
        const text: string = formData.get('shareText') as string

        if(text.trim().length === 0) {
          return
        }

        if(text.length > 1000) {
          return
        }

        let url = new URL(this.API_URL)
        url.searchParams.set('text', text)
        url.searchParams.set('captchaResponse', this.captchaResponse)

        fetch(url, { method: 'POST' })
        .then((data) => data.json())
        .then((data) => {
          if(data.code) {
            this.$router.push({ path: data.code })
          } else {
            throw Error()
          }
        })
        .catch(() => {
          alert('Error! Something went wrong. Please try again.')
          this.isCaptchaVerified = true
        })
      }
    },
    computed: {
      isCaptchaVerified(): boolean {
        return !this.isCaptchaVerified
      }
    }
  }
</script>