<script setup>
import { ref, onMounted, watch } from 'vue';

const defaultColor = '#424242';

const selectedColor = ref(defaultColor);

const atualizarCorNavbar = (cor) => {
  document.documentElement.style.setProperty('--navbar-color', cor);
  localStorage.setItem('navbarColor', cor);
};

onMounted(() => {
  const storedColor = localStorage.getItem('navbarColor');
  
  if (storedColor) {
    selectedColor.value = storedColor;
    atualizarCorNavbar(storedColor);
  } else {
    selectedColor.value = defaultColor;  
    atualizarCorNavbar(defaultColor);
  }
});

watch(selectedColor, (novaCor) => {
  atualizarCorNavbar(novaCor);
});
</script>

<template>
  <div class="container">
    <h1>Escolha a cor da Navbar e Sidebar</h1>
    <input type="color" v-model="selectedColor" /> 

    <div class="selected-color-info">
      <p>Cor selecionada: {{ selectedColor }}</p> 
    </div>
  </div>
</template>

<style scoped>
.container {
  padding: 20px;
}

.selected-color-info {
  margin-top: 20px;
}
</style>
