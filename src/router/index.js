import { createRouter, createWebHistory } from 'vue-router';
import Home from '../views/Home.vue';
import Login from '../views/Login.vue';
import Signup from '../views/Signup.vue';
import Dashboard from '../views/Dashboard.vue'; 
import Inicio from '../components/dashboard/Inicio.vue'; 
import Produtos from '../components/dashboard/Produtos.vue'; 
import Configuracao from '../components/dashboard/Configuracao.vue'; 

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
    path: '/signup',
    name: 'Signup',
    component: Signup
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
        path: 'produtos', 
        name: 'Produtos',
        component: Produtos 
      },
      { 
        path: 'configuracao', 
        name: 'Configuracao',
        component: Configuracao 
      },
    ]
  }
];

const router = createRouter({
  history: createWebHistory(),
  routes
});

export default router;
