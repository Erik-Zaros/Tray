<script setup>
import { ref, defineEmits } from 'vue';
import introJs from 'intro.js';
import 'intro.js/introjs.css';

const emit = defineEmits(['toggleEdit']);
const isEditing = ref(false);

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

const toggleEditing = () => {
  isEditing.value = !isEditing.value;
  emit('toggleEdit', isEditing.value);
};

startTour();
</script>

<template>
  <div class="container-fluid p-0">
    <div class="save shadow w-100 px-5 d-flex align-items-center justify-content-between">
      <div class="edit fw-bold">Usuário</div>
      <div class="usuario" :class="{ 'd-none': isEditing }">
        <button @click="toggleEditing" class="btn btn-primary py-2 px-3 ms-3 rounded-0">Editar</button>
      </div>
      <div class="editar" :class="{ 'd-block': isEditing, 'd-none': !isEditing }">
        <a href="" class="options text-decoration-none">
          <i class="fa-solid fa-ellipsis-vertical me-2"></i> Mais Opções 
        </a>
        <button @click="toggleEditing" class="btn btn-outline-secondary py-2 px-3 ms-5 rounded-0">Cancelar</button>
        <button @click="toggleEditing" class="btn btn-outline-primary py-2 px-3 ms-3 rounded-0">Salvar</button>
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
  background-color: var(--background-navbar);
}

.save > .edit {
  font-size: 1.6em;
  color: var(--color-primary);
}



</style>
