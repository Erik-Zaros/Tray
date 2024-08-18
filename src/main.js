import './assets/global.css'
import './assets/dark.css'
import './assets/light.css'
import 'intro.js/introjs.css';

import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import introJs from 'intro.js';

const app = createApp(App)

app.use(router)

app.mount('#app')
