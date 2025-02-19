import { createRouter, createWebHistory } from 'vue-router';
import Home from '../views/Home.vue';
import Login from '../views/Login.vue';
import Registrar from '../views/Registrar.vue';
import Dashboard from '../views/Dashboard.vue';
import Inicio from '../components/dashboard/Inicio.vue';
import Perfil from '../components/dashboard/Perfil.vue';
import Loja from '../components/dashboard/Loja.vue';
import Produtos from '../components/dashboard/Produtos.vue';
import Templates from '../components/dashboard/Templates.vue';
import Configuracao from '../components/dashboard/Configuracao.vue';
import Ajuda from '../components/dashboard/Ajuda.vue';
import Confetti from '../components/dashboard/components/Loja/Confetti.vue';

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    path: '/login',
    name: 'Login',
    component: Login
  },
  {
    path: '/registrar',
    name: 'Registrar',
    component: Registrar
  },
  {
    path: '/dashboard',
    name: 'Dashboard',
    component: Dashboard,
    children: [
      {
        path: 'inicio',
        name: 'Inicio',
        component: Inicio
      },
      {
        path: 'confetti',
        name: 'Confetti',
        component: Confetti
      },
      {
        path: 'perfil',
        name: 'Perfil',
        component: Perfil
      },
      {
        path: 'loja',
        name: 'Loja',
        component: Loja
      },
      {
        path: 'produtos',
        name: 'Produtos',
        component: Produtos
      },
      {
        path: 'templates',
        name: 'Templates',
        component: Templates
      },
      {
        path: 'configuracao',
        name: 'Configuracao',
        component: Configuracao
      },
      {
        path: 'ajuda',
        name: 'Ajuda',
        component: Ajuda
      },
    ]
  }
];

const router = createRouter({
  history: createWebHistory(),
  routes
});

export default router;
