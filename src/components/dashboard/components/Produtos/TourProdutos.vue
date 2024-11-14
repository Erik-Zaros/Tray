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
        intro: 'Aqui e onde importa seus produtos.</strong>',
        position: 'bottom'
      },
      {
        element: '#tour-produtos-2',
        intro: 'Aqui é onde cadastra produtos unitariamente.',
        position: 'bottom'
      },
      {
        element: '#tour-produtos-3',
        intro: 'Onde voce filtra e pesquisa seus produtos.',
        position: 'bottom'
      },
      {
        element: '#tour-produtos-4', 
        intro: 'Busca pela referencia ou codigo.',
        position: 'bottom',
      },
      {
        element: '#tour-produtos-5',
        intro: 'Busca pelo nome.',
        position: 'bottom',
      },
      {
        element: '#tour-produtos-6',
        intro: 'Busca por categoria.',
        position: 'bottom',
      },
      {
        element: '#tour-produtos-7',
        intro: 'busca por faixa de preco.',
        position: 'bottom',
      },
      {
        element: '#tour-produtos-8',
        intro: 'Menu de selecao e opcoes.',
        position: 'bottom',
      },
      {
        element: '#tour-produtos-9',
        intro: 'Selecao de todos os itens.',
        position: 'bottom',
      },
      {
        element: '#tour-produtos-10',
        intro: 'Ordena por ondem alfabetica/numerica.',
        position: 'bottom',
      },
      {
        element: '#tour-produtos-11',
        intro: 'Remove os filtros de pesquisa.',
        position: 'bottom',
      },
      {
        element: '#tour-produtos-12',
        intro: 'Logout</strong></br>Exclui produtos selecionados.',
        position: 'bottom',
      },
      {
        element: '#tour-produtos-13',
        intro: 'Logout</strong></br>Aqui ficam todos seus produtos.',
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
