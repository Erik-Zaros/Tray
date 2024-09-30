<script setup>
import { ref, onMounted, watch } from 'vue';
import { useRouter } from 'vue-router';
import { logout } from '../../services/api';

const router = useRouter();
const menu = ref(false);
const navbarColor = ref('#424242');

onMounted(() => {
  const storedColor = localStorage.getItem('navbarColor');
  if (storedColor) {
    navbarColor.value = storedColor;
    atualizarCorNavbar(navbarColor.value);
  }
});

const atualizarCorNavbar = (cor) => {
  document.documentElement.style.setProperty('--navbar-color', cor);
  localStorage.setItem('navbarColor', cor);
};

watch(navbarColor, (novaCor) => {
  atualizarCorNavbar(novaCor);
});

function mudarMenu() {
  menu.value = !menu.value;
}

const deslogar = async () => {
  try {
    await logout();
    router.push('/login');
  } catch (error) {
    console.error('Erro ao fazer logout:', error);
    alert('Erro ao fazer logout. Tente novamente.');
  }
};
</script>

<template>
  <div>
    <div class="horizontal d-flex vw-100 justify-content-between px-4">
      <div class="menu d-flex align-items-center">
        <i id="tour-1" class="menu-icon fa-solid rounded fa-bars fs-1" @click="mudarMenu"></i>
      </div>

      <div class="d-flex align-items-center">
        <router-link to="/dashboard/ajuda">
          <i class="fa-regular fa-circle-question fs-3 px-2 px-md-3"></i>
        </router-link>

        <router-link to="/dashboard/perfil">
          <i class="bi bi-person-fill fs-2 px-2 px-md-3"></i>
        </router-link>
      </div>
    </div>

    <div
      :class="['vertical', 'd-flex', 'flex-column', 'align-items-between', 'justify-content-between', 'text-center', { expanded: menu }]">

      <div class="content">
        <label class="icon-wrapper my-2">
          <router-link to="/dashboard/inicio">
            <i id="tour-2" class="fa-regular icon-menu fa-flag py-3 px-4 rounded"></i>
            <span class="text-icon">Início</span>
          </router-link>
        </label>

        <label class="icon-wrapper my-2">
          <router-link to="/dashboard/perfil">
            <i id="tour-3" class="fa-regular icon-menu fa-user py-3 px-4 rounded"></i>
            <span class="text-icon">Perfil</span>
          </router-link>
        </label>

        <label class="icon-wrapper my-2">
          <router-link to="/dashboard/loja">
            <i id="tour-4" class="fa-solid icon-menu fa-store py-3 px-4 rounded"></i>
            <span class="text-icon">Sua Loja</span>
          </router-link>
        </label>

        <label class="icon-wrapper my-2">
          <router-link to="/dashboard/produtos">
            <i id="tour-5" class="fa-solid icon-menu fa-tag py-3 px-4 rounded"></i>
            <span class="text-icon">Produtos</span>
          </router-link>
        </label>

        <label class="icon-wrapper my-2">
          <router-link to="/dashboard/templates">
            <i id="tour-6" class="fa-solid icon-menu fa-tv py-3 px-4 rounded"></i>
            <span class="text-icon">Templates</span>
          </router-link>
        </label>

        <label class="icon-wrapper my-2">
          <router-link to="/dashboard/configuracao">
            <i id="tour-7" class="fa-solid icon-menu fa-gear py-3 px-4 rounded"></i>
            <span class="text-icon">Definições</span>
          </router-link>
        </label>

        <label class="icon-wrapper my-2">
          <router-link to="/dashboard/ajuda">
            <i id="tour-8" class="fa-regular icon-menu fa-circle-question py-3 px-4 rounded"></i>
            <span class="text-icon">Ajuda</span>
          </router-link>
        </label>
      </div>

      <label class="icon-wrapper my-2" @click="deslogar">
          <i id="tour-9" class="fa-solid icon-menu fa-right-from-bracket py-3 px-4 rounded"></i>
          <span class="text-icon">Logout</span>
        </label>

    </div>
  </div>
</template>

<style scoped>
:root {
  --navbar-color: #424242; /* Cor padrão */
}

* {
  color: white;
  box-sizing: border-box;
}

html,
body {
  margin: 0;
  padding: 0;
  height: 100%;
}

.content {
  display: flex;
  flex-direction: column;
  height: 100vh;
  overflow: hidden;
}

.horizontal {
  background-color: var(--navbar-color);
  height: 8vh;
  width: 100%;
  position: fixed;
  top: 0;
  left: 0;
  z-index: 1000;
}

.vertical {
  background-color: var(--navbar-color);
  height: 92vh;
  width: 80px;
  position: fixed;
  top: 8vh;
  left: 0;
  z-index: 999;
  transition: width 0.3s;
}

.vertical:hover {
 width: 120px; 
}

.vertical.expanded {
  width: 200px;
}

.menu-icon {
  transition: .2s;
}

.menu-icon:hover {
  transform: scale(1.08);
  transition: .2s;
  cursor: pointer;
}

.icon-menu {
  cursor: pointer;
}

.text-icon {
  display: none;
  margin-left: 10px;
}

.vertical.expanded .text-icon {
  display: inline-block;
}

.icon-wrapper {
  display: flex;
  align-items: center;
  justify-content: center;
  transition: .3s;
}

.icon-wrapper:hover {
  background-color: rgba(0, 110, 255, 0.2);
  border-radius: 10px;
}

.icon-menu {
  font-size: 1.5rem;
  color: white;
  transition: .2s;
}

.icon-wrapper:hover .icon-menu {
  transform: scale(1.1);
}

@media (max-width: 1024px) {
  .search-input {
    display: none;
  }
}

.text-icon {
  display: none;
  margin-left: 0px;
  margin-right: 24px; 
}

</style>
