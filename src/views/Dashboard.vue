<script setup>
import { obterDadosUsuario } from '../services/api';
import { ref, onMounted, computed } from 'vue';
import { useRouter } from 'vue-router';
import Header from '../components/dashboard/Header.vue';
import TourComponent from '../components/dashboard/components/Inicio/Tour.vue';

const usuario = ref(null);
const router = useRouter();

onMounted(async () => {
  try {
    const dados = await obterDadosUsuario();
    usuario.value = dados;

    if (mostraTutorial.value) {
      localStorage.removeItem('tutorial');
    }
  } catch (erro) {
    router.push('/login');
  }
});

const mostraTutorial = computed(() => localStorage.getItem('tutorial') === 'true');

</script>

<template>
  <Header />
  <router-view class="conteudo position-absolute bottom-0 end-0" />
  <TourComponent v-if="mostraTutorial" />
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
