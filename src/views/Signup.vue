<script setup>
import Signup from '../components/login/Signup.vue';
</script>

<template>

  <div class="container-fluid vh-100 d-flex align-items-center justify-content-center">

    <div class="signup text-center">
      <img class="logo" src="https://sitetray.s3.amazonaws.com/wp-content/uploads/2024/03/logo_tray_site-1.svg" width="150px">
      <h1 class="titulo fw-bold pt-3">Vamos Começar!</h1>
      <p class="texto fw-bold fs-4">Informe os dados abaixo para prosseguir</p>
      <div class="criar d-flex">
        <Signup />
      </div>
    </div>

  </div>





</template>

<style scoped>

.container-fluid {
  background-color: var(--background-primary);
}

.titulo {
  font-size: 3.5em;
  color: var(--color-title);
}

.texto {
  color: var(--text-color-link);
}


</style>