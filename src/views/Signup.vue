<script setup>
import Signup from '../components/login/Signup.vue';
</script>

<template>

  <div class="container-fluid vh-100 d-flex align-items-center justify-content-center">
    <RouterLink class="text-decoration-none text-dark" to="/"><i
        class="fa-solid fa-xmark position-absolute top-0 start-0 p-3 fs-3"></i></RouterLink>

    <div class="signup text-center">
      <img class="logo" src="https://sitetray.s3.amazonaws.com/wp-content/uploads/2024/03/logo_tray_site-1.svg"
        width="150px">
      <h1 class="titulo fw-bold pt-3">Vamos Começar!</h1>
      <p class="texto fw-bold">Informe os dados abaixo para prosseguir</p>
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
  font-size: 1.5em;
  color: var(--text-color-link);
}

@media (max-width: 1024px) {
  .titulo {
    font-size: 2.5em;
  }

  .texto {
    font-size: 1em;
  }
}
</style>