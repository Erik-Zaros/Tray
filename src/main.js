import './assets/global.css';
import './assets/dark.css';
import './assets/light.css';
import 'intro.js/introjs.css';
import 'vue-toastification/dist/index.css';
import store from './store'; // Importe o store

import { createApp } from 'vue';
import App from './App.vue';
import router from './router';
import Toast from 'vue-toastification';
import introJs from 'intro.js';

const options = {
    position: "top-right",
    timeout: 5000,
    closeOnClick: true,
    pauseOnFocusLoss: true,
    pauseOnHover: true,
    draggable: true,
    draggablePercent: 0.6,
    showCloseButtonOnHover: false,
    hideProgressBar: true,
    closeButton: "button",
    icon: true,
    rtl: false
};

const app = createApp(App);

// Registrar o Vue Toastification
app.use(Toast, options);

// Registrar o Vue Router
app.use(router);

// Adicione o Vuex ao Vue
app.use(store); 

// Montar a aplicação
app.mount('#app');


