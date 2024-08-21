<script setup>
import { onMounted } from 'vue';
import introJs from 'intro.js';
import 'intro.js/introjs.css';

const startTour = () => {
  introJs().setOptions({
    steps: [
      {
        element: '.save',
        intro: '<strong class="text-center">Menu de Ediçao</strong>',
        position: 'bottom'
      },
      {
        element: '#tour-2',
        intro: '<strong class="text-center">Início</strong></br>Aqui onde ficam as metricas da sua loja.',
        position: 'bottom'
      },
      {
        element: '#tour-3',
        intro: '<strong class="text-center">Perfil</strong></br>Aqui onde voce acessa e atualiza sua conta.',
        position: 'bottom'
      },
      {
        element: '#tour-4', 
        intro: '<strong class="text-center">Sua Loja</strong></br>Aqui onde voce acessa e atualiza sua loja online.',
        position: 'bottom',
      },
      {
        element: '#tour-5',
        intro: '<strong class="text-center">Produtos</strong></br>Aqui onde voce acessa e administra seus produtos.',
        position: 'bottom',
      },
      {
        element: '#tour-6',
        intro: '<strong class="text-center">Templates</strong></br>Aqui voce define o layout do seu site.',
        position: 'bottom',
      },
      {
        element: '#tour-7',
        intro: '<strong class="text-center">Configuraçoes</strong></br>Aqui voce ajusta as definiçoes do seu site.',
        position: 'bottom',
      },
      {
        element: '#tour-8',
        intro: '<strong class="text-center">Ajuda</strong></br>Aqui voce encontra topicos de suporte sobre o site.',
        position: 'bottom',
      },
      {
        element: '#tour-9',
        intro: '<strong class="text-center">Logout</strong></br>Saia da sua sessao aqui.',
        position: 'bottom',
      },
      {
        element: '#tour-10',
        intro: 'O acesso inicial, onde ativa e desativa sua loja.',
        position: 'bottom',
      },
      {
        element: '#tour-11',
        intro: 'Dicas para ecommerce, vendas e muito mais.',
        position: 'bottom',
      },
      {
        element: '#tour-12',
        intro: 'Cadastro da loja, aqui mostra a porcentagem de conclusao do seu cadastro.',
        position: 'bottom',
      }
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
</template>

<style scoped>
</style>