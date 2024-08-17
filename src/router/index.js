import { createRouter, createWebHistory } from 'vue-router';
import Home from '../views/Home.vue';
import Login from '../views/Login.vue';
import Signup from '../views/Signup.vue';
import Dashboard from '../views/Dashboard.vue'; 
import Inicio from '../components/dashboard/Inicio.vue'; 
import Perfil from '../components/dashboard/Perfil.vue'; 
import Loja from '../components/dashboard/Loja.vue'; 
import Produtos from '../components/dashboard/Produtos.vue';
import Templates from '../components/dashboard/Templates.vue'; 
import Configuracao from '../components/dashboard/Configuracao.vue'; 
import Ajuda from '../components/dashboard/Ajuda.vue'; 

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
