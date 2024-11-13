<template>
  <div class="d-none flex-column justify-content-center align-items-center"
    :class="{ 'd-flex': isCounting, darkened: isDarkened }">
    <p class="counter text-white" v-if="isCounting">
      {{ countMessage }}
    </p>
    <div v-if="showReady" class="ready-message">Loja Iniciada!</div>
  </div>
</template>

<script setup>
import { ref } from 'vue';

// Define as variáveis reativas
const countMessage = ref('');       // Mostra o número da contagem ou "Pronto!"
const showReady = ref(false);       // Controla a exibição de "Pronto!"
const isDarkened = ref(false);      // Controla o escurecimento da tela
const isCounting = ref(false);      // Controla se a contagem está em andamento

// Função para iniciar a contagem
const startCountdown = () => {
  isCounting.value = true;          // Impede múltiplas contagens simultâneas
  isDarkened.value = true;          // Inicia o escurecimento

  let count = 3;                    // Início da contagem
  countMessage.value = count;       // Exibe o número inicial

  // Configura o intervalo de contagem
  const interval = setInterval(() => {
    count--;
    countMessage.value = count > 0 ? count : '';  // Atualiza a contagem, esvazia quando chega em 0

    if (count === 0) {
      clearInterval(interval);      // Para a contagem quando chega a zero
      showReady.value = true;       // Exibe "Pronto!"

      // Após exibir "Pronto!" por 1 segundo, reseta o estado
      setTimeout(() => {
        isDarkened.value = false;
        isCounting.value = false;
        showReady.value = false;
      }, 1000);
    }
  }, 1000);
};

// Expõe a função para ser acessada pelo componente pai
defineExpose({
  startCountdown
});
</script>

<style scoped>
.counter-container {
  transition: background-color 1s ease;
}

.darkened {
  background-color: rgba(0, 0, 0, 0.8);
  /* Escurece a tela */
}

.counter,
.ready-message {
  font-size: 8em;
  color: #fff;
}
</style>
