<script setup>
import { ref } from 'vue';
import { useRouter } from 'vue-router';

const username = ref('');
const email = ref('');
const password = ref('');
const router = useRouter();

const signup = async () => {
  const response = await fetch(`${import.meta.env.BASE_URL}users.json`);
  const users = await response.json();

  const newUser = {
    id: users.length + 1,
    username: username.value,
    email: email.value,
    password: password.value,
    created_at: new Date().toISOString(),
    status: 'active'
  };

  localStorage.setItem('user', JSON.stringify(newUser));
  router.push('/dashboard');
};
</script>

<template>
  <div class="criar col-10 col-md-4 m-auto">
    <div class="input-group px-2 px-md-5 row">
      <label class="text-start my-2">Qual seu nome? <span class="text-danger">*</span></label>
      <input class="form-control rounded-5 p-2 px-3 mb-2" type="text" v-model="username" placeholder="Nome" />

      <label class="text-start my-2">Seu melhor e-mail? <span class="text-danger">*</span></label>
      <input class="form-control rounded-5 p-2 px-3 mb-2" type="email" v-model="email" placeholder="E-mail" />

      <label class="text-start my-2">Senha*</label>
      <input class="form-control rounded-5 p-2 px-3 mb-4" type="password" v-model="password" placeholder="Senha" />

      <div class="row">
        <button class="btn btn-success m-auto col-10 col-md-6 rounded-5 fs-4 fw-bold" @click="signup">Continuar</button>
      </div>
      <span class="termos pt-3">Clicando no botão, você concorda com nossos termos de <span class=termo>política</span> e
        <span class=termo>privacidade</span></span>

    </div>
  </div>
</template>



<style scoped>
.termos {
  font-size: .8em;
}

.termo {
  color: var(--text-color-link);
}

</style>