<template>
    <div>
      <!-- Elementos que você quer destacar -->
      <div id="step1" class="tour-step">Seção 1</div>
      <div id="step2" class="tour-step">Seção 2</div>
      <div id="step3" class="tour-step">Seção 3</div>
      
      <!-- Botão para iniciar o tour (opcional, pode ser removido se o tour iniciar automaticamente) -->
      <button @click="startTour">Iniciar Tour</button>
    </div>
  </template>
  
  <script>
  import { onMounted } from 'vue';
  import introJs from 'intro.js';
  import 'intro.js/introjs.css'; // Importa o CSS do Intro.js
  
  export default {
    name: 'TourComponent',
    
    setup() {
      // Função para iniciar o tour
      const startTour = () => {
        introJs().setOptions({
          steps: [
            {
              element: '#step1',
              intro: 'Esta é a primeira seção.',
              position: 'bottom'
            },
            {
              element: '#step2',
              intro: 'Aqui é onde você pode encontrar mais informações.',
              position: 'top'
            },
            {
              element: '#step3',
              intro: 'Esta é a última parte do tour.',
              position: 'left'
            }
          ]
        }).start();
      };
  
      // Iniciar o tour automaticamente quando o componente for montado
      onMounted(() => {
        startTour();
      });
  
      return {
        startTour
      };
    }
  };
  </script>
  
  <style>
  .tour-step {
    border: 2px solid red;
    padding: 10px;
    margin: 10px;
  }
  </style>
  