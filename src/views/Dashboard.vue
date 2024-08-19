<script setup>
import { ref, onMounted } from 'vue';
import { useRouter } from 'vue-router';
import Header from '../components/dashboard/components/Inicio/Header.vue';
import TourComponent from '../components/dashboard/components/Inicio/Tour.vue'; // Atualizado o nome do componente para o correto

const user = ref({});
const router = useRouter();

onMounted(() => {
  const userData = JSON.parse(localStorage.getItem('user'));
  if (userData) {
    user.value = userData;

    const tutorial = localStorage.getItem('tutorial');
    if (tutorial === 'true') {
      localStorage.removeItem('tutorial'); // Remove a flag após o primeiro acesso
    } else {
      // Não faz nada se o tutorial não deve ser exibido
      return;
    }
  } else {
    router.push('/login');
  }
});
</script>

<template class="vh-100 vw-100">
  <Header />
  <router-view class="conteudo position-absolute bottom-0 end-0" />
  <TourComponent /> <!-- Exibe o tutorial se a flag estiver definida -->
</template>

<style>
.conteudo {
  top: 8vh;
  left: 80px;
  width: calc(100vw - 80px);
  transition: left 0.3s, width 0.3s;
  background-color: var(--background-secondary);
}
</style>
