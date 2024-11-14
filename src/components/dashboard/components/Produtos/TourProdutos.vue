<script setup>
import { onMounted } from 'vue';
import introJs from 'intro.js';
import 'intro.js/introjs.css';

const startTour = () => {
  setTimeout(() => {
    introJs().setOptions({
      steps: [
      {
        element: '#tour-produtos-0',
        intro: 'Este é o menu de produtos.</strong>',
        position: 'bottom'
      },
      {
        element: '#tour-produtos-1',
        intro: 'Aqui é onde você importa seus produtos.</strong>',
        position: 'bottom'
      },
      {
        element: '#tour-produtos-2',
        intro: 'Aqui é onde você cadastra o seus produtos.',
        position: 'bottom'
      },
      {
        element: '#tour-produtos-3',
        intro: 'Onde você filtra e pesquisa seus produtos.',
        position: 'bottom'
      },
      {
        element: '#tour-produtos-4', 
        intro: 'Aqui você consegue consultar pela referência ou código.',
        position: 'bottom',
      },
      {
        element: '#tour-produtos-5',
        intro: 'Aqui você consegue buscar o produto pelo nome.',
        position: 'bottom',
      },
      {
        element: '#tour-produtos-6',
        intro: 'Aqui você consegue buscar o produto pela categoria.',
        position: 'bottom',
      },
      {
        element: '#tour-produtos-7',
        intro: 'Aqui você consegue buscar produtos por faixa de preço.',
        position: 'bottom',
      },
      {
        element: '#tour-produtos-8',
        intro: 'Aqui é o menu de seleções e opções.',
        position: 'bottom',
      },
      {
        element: '#tour-produtos-9',
        intro: 'Aqui você consegue selecionar todos os produtos.',
        position: 'bottom',
      },
      {
        element: '#tour-produtos-10',
        intro: 'Aqui você consegue ordenar os seus produtos.',
        position: 'bottom',
      },
      {
        element: '#tour-produtos-11',
        intro: 'Aqui você consegue remover os filtros.',
        position: 'bottom',
      },
      {
        element: '#tour-produtos-12',
        intro: 'Logout</strong></br>Aqui você consgue excluir os produto selecionados.',
        position: 'bottom',
      },
      {
        element: '#tour-produtos-13',
        intro: 'Logout</strong></br>Aqui é onde você consegue visualizar todos os produtos cadastrados.',
        position: 'bottom',
      }
    ],
      showStepNumbers: true,
      showBullets: true,
      showProgress: true
    }).start();
  }, 100); 
};

onMounted(() => {
  const tutorial = localStorage.getItem('tutorialProduto');
  if (tutorial === 'true') {
    startTour();
  }
});

</script>

<template>
</template>
