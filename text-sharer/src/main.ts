import { createApp } from 'vue'
import App from './App.vue'
import router from './router'

import './assets/main.css'

const app = createApp(App)

app.use(router)
app.config.globalProperties.API_URL = 'https://localhost:44369/api/TextSharer'

app.mount('#app')
