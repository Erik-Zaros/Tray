<script setup>
import { ref, computed, onMounted } from 'vue';
import { useRouter, RouterLink } from 'vue-router';
import LoginStep1 from '../components/login/LoginStep1.vue';
import LoginStep2 from '../components/login/LoginStep2.vue';

const step = ref(1);
const router = useRouter();

const currentStep = computed(() => (step.value === 1 ? LoginStep1 : LoginStep2));

// Função para ir para o próximo passo ou redirecionar
const proximo = () => {
  if (step.value === 1) {
    step.value = 2;
  } else {
    router.push('/'); // Redireciona para a página inicial
  }
};

// Verificação ao montar o componente
onMounted(() => {
  const token = localStorage.getItem('token'); // Verifica se o token está presente no localStorage
  if (token) {
    router.push('/dashboard/inicio'); // Redireciona para o dashboard se o token existir
  }
});
</script>

<template>
  <div class="login d-flex">
    <div class="coluna-1 col-md-4 col-12 d-flex flex-column align-items-center justify-content-center text-center">
      <RouterLink class="text-decoration-none text-dark" to="/">
        <i class="fa-solid fa-xmark position-absolute top-0 start-0 p-3 fs-3"></i>
      </RouterLink>
      <img class="logo pb-4" src="https://sitetray.s3.amazonaws.com/wp-content/uploads/2024/03/logo_tray_site-1.svg" alt="Logo">
      <p class="texto fw-bold col-10 col-lg-8">Administre sua loja em um único lugar</p>
      <component :is="currentStep" @next="proximo" />
      <span class="forget py-3">Esqueci minha senha</span>
      <p>Ainda não tem uma loja? 
        <RouterLink class="crie text-decoration-none" to="/registrar">Crie uma agora</RouterLink>
      </p>
    </div>
    <div class="coluna-2 col-lg-8 col-0">
      <img class="login-img" src="/image/login-img.png" alt="Imagem de login">
    </div>
  </div>
</template>

<style scoped>
.login {
  height: 100vh;
  width: 100vw;
}

.coluna-1,
.coluna-2 {
  height: 100vh;
}

.coluna-1 {
  background-color: var(--background-primary);
}

.coluna-2 {
  overflow-x: hidden;
}

.logo {
  width: 13rem;
}

.login-img {
  height: 100%;
}

.texto {
  font-size: 2em;
  color: var(--color-title);
}

.forget,
.crie {
  color: var(--text-color-link);
}

@media (max-width: 1024px) {
  .texto {
    font-size: 1.6em;
  }
}
</style>
