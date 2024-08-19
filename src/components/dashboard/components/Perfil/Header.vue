<script setup>
import { ref, onMounted } from 'vue';
import introJs from 'intro.js';
import 'intro.js/introjs.css';

const startTour = () => {
  introJs().setOptions({
    steps: [
      {
        element: '.save',
        intro: 'Esta é a primeira seção.',
        position: 'bottom'
      },
      {
        element: '.save',
        intro: 'Aqui é onde você pode encontrar mais informações.',
        position: 'top'
      },
      {
        element: '.editar',
        intro: 'Esta é a última parte do tour.',
        position: 'left'
      }
    ]
  }).start();
};

onMounted(() => {
  startTour();
});

const editar = ref(false);

const mudar = () => {
  editar.value = !editar.value;
};

</script>

<template>
  <div class="container-fluid p-0 position-absolute">
    <div class="save shadow w-100 px-5 d-flex align-items-center justify-content-between">
      <div class="edit fw-bold">Usuário</div>
      <div class="usuario" :class="{ 'd-none': editar }">
        <button @click="mudar" class="btn btn-primary py-2 px-3 ms-3 rounded-0">Editar</button>
      </div>
      <div class="editar" :class="{ 'd-block': editar, 'd-none': !editar }">
        <a href="" class="options text-decoration-none">
          <i class="fa-solid fa-ellipsis-vertical me-2"></i> Mais Opções 
        </a>
        <button @click="mudar" class="btn btn-outline-secondary py-2 px-3 ms-5 rounded-0">Cancelar</button>
        <button @click="mudar" class="btn btn-outline-primary py-2 px-3 ms-3 rounded-0">Salvar</button>
      </div>
    </div>
  </div>
</template>


<style scoped>
.d-none {
  display: none;
}

.d-block {
  display: block;
}

.container-fluid {
  z-index: 3;
}

.save {
  height: 8vh;
  background-color: var(--background-primary);
}

.save > .edit {
  font-size: 1.6em;
  color: var(--color-primary);
}
</style>
