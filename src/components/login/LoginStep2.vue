<script setup>
import { ref } from 'vue';
import { useRouter } from 'vue-router';
import { loginUsuario } from '../../services/api';

const password = ref('');
const router = useRouter();

const login = async () => {
  const email = sessionStorage.getItem('email');

  if (!email || !password.value) {
    alert('Por favor, preencha todos os campos.');
    return;
  }

  try {
    const resposta = await loginUsuario({ email, senha: password.value });

    // Armazena o usuário no localStorage e redireciona para o dashboard
    localStorage.setItem('user', JSON.stringify(resposta));
    router.push('/dashboard/inicio');
  } catch (erro) {
    alert(`Erro ao fazer login: ${erro.message}`);
  }
};
</script>

<template>
  <div class="input-group px-2 px-md-5 row">
    <label class="text-start my-2">Senha <span class="text-danger">*</span></label>
    <input class="form-control rounded-5 p-3 mb-3" type="password" v-model="password" placeholder="Senha" />
    <button class="btn btn-success col-12 rounded-5 fs-4 fw-bold" @click="login">Login</button>
  </div>
</template>
