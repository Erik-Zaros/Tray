<script setup>
import { ref } from 'vue';
import { useRouter } from 'vue-router';
import { registrarUsuario, loginUsuario } from '../../services/api';

const router = useRouter();

const nome = ref('');
const sobrenome = ref('');
const email = ref('');
const senha = ref('');
const saldo = ref(0);

async function registrar() {
    try {
        const dados = {
            nome: nome.value,
            sobrenome: sobrenome.value,
            email: email.value,
            senha: senha.value,
            saldo: saldo.value,
        };

        await registrarUsuario(dados);

        const dadosLogin = await loginUsuario({
            email: email.value,
            senha: senha.value,
        });

        // Armazena o token no localStorage
        localStorage.setItem('token', dadosLogin.token);

        // Inicie o tutorial e redirecione para o dashboard
        localStorage.setItem('tutorial', 'true');
        router.push('/dashboard/inicio');
        alert('Usuário registrado e autenticado com sucesso!');

        // Limpar os campos após o registro e login
        nome.value = '';
        sobrenome.value = '';
        email.value = '';
        senha.value = '';
        saldo.value = 0;
    } catch (erro) {
        alert(`Erro ao registrar ou fazer login: ${erro.message}`);
    }
}
</script>

<template>
    <div class="criar col-10 col-md-4 m-auto">
      <form class="input-group px-2 px-md-5 row" @submit.prevent="registrar">
        <label class="text-start my-2">Qual seu nome? <span class="text-danger">*</span></label>
        <input class="form-control rounded-5 p-2 px-3 mb-2" type="text" v-model="nome" placeholder="Nome" />

        <label class="text-start my-2">Qual seu sobrenome? <span class="text-danger">*</span></label>
        <input class="form-control rounded-5 p-2 px-3 mb-2" type="text" v-model="sobrenome" placeholder="Sobrenome" />
  
        <label class="text-start my-2">Seu melhor e-mail? <span class="text-danger">*</span></label>
        <input class="form-control rounded-5 p-2 px-3 mb-2" type="email" v-model="email" placeholder="E-mail" />
  
        <label class="text-start my-2">Crie uma senha <span class="text-danger">*</span></label>
        <input class="form-control rounded-5 p-2 px-3 mb-4" type="password" v-model="senha" placeholder="Senha" />

        <label class="text-start my-2 d-none">Saldo <span class="text-danger">*</span></label>
        <input class="form-control rounded-5 p-2 px-3 mb-4" v-model.number="saldo" placeholder="Saldo" hidden/>
  
        <div class="row">
          <button class="btn btn-success m-auto col-10 col-md-6 rounded-5 fs-4 fw-bold" type="submit">Continuar</button>
        </div>
        <span class="termos pt-3">Clicando no botão, você concorda com nossos termos de <span class=termo>política</span> e
          <span class=termo>privacidade</span></span>
      </form>
    </div>
</template>
