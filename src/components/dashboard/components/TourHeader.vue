<script setup>
import { onMounted } from 'vue';
import introJs from 'intro.js';
import 'intro.js/introjs.css';

const startTour = () => {
  introJs().setOptions({
    steps: [
      {
        element: '#tour-1',
        intro: 'Esta é a primeira seção do conteúdo.',
        position: 'bottom'
      },
      {
        element: '#tour-2',
        intro: 'Aqui você pode ver mais detalhes importantes.',
        position: 'bottom'
      },
      {
        element: '#tour-3',
        intro: 'Esta é a última seção do conteúdo.',
        position: 'bottom'
      },
      {
        element: '#tour-4', 
        intro: 'E aqui está o menu do cabeçalho.',
        position: 'bottom',
      },
      {
        element: '#tour-5',
        intro: 'E aqui está o menu do cabeçalho.',
        position: 'bottom',
      },
      {
        element: '#tour-6',
        intro: 'E aqui está o menu do cabeçalho.',
        position: 'bottom',
      },
      {
        element: '#tour-7',
        intro: 'E aqui está o menu do cabeçalho.',
        position: 'bottom',
      },
      {
        element: '#tour-8',
        intro: 'E aqui está o menu do cabeçalho.',
        position: 'bottom',
      },
      {
        element: '#tour-9',
        intro: 'E aqui está o menu do cabeçalho.',
        position: 'bottom',
      },
      {
        element: '#tour-10',
        intro: 'E aqui está o menu do cabeçalho.',
        position: 'bottom',
      },
      {
        element: '#tour-11',
        intro: 'E aqui está o menu do cabeçalho.',
        position: 'bottom',
      },
      {
        element: '#tour-12',
        intro: 'E aqui está o menu do cabeçalho.',
        position: 'bottom',
      }
      // Adicione outros passos conforme necessário
    ],
    showStepNumbers: true,
    showBullets: true,
    showProgress: true
  }).start();
};

onMounted(() => {
  const tutorial = localStorage.getItem('tutorial');
  if (tutorial === 'true') {
    startTour();
  }
});
</script>

<template>
  <!-- Este componente pode estar vazio se apenas gerenciar o tour -->
</template>

<style scoped>
.highlighted {
  border: 3px solid red;
  background-color: rgba(255, 0, 0, 0.1);
}
</style>