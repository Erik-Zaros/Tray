<script setup>
import { ref } from 'vue';
import { useRouter } from 'vue-router';
import { registrarUsuario, loginUsuario } from '../../services/api';
import { useToast } from 'vue-toastification';

const toast = useToast();
const router = useRouter();

const nome = ref('');
const sobrenome = ref('');
const email = ref('');
const senha = ref('');
const saldo = ref(0);
const image = ref('');

const emailError = ref('');
const senhaError = ref('');
const store = ref(false);

async function registrar() {
    senhaError.value = '';

    // Validações
    if (senha.value.length < 8) {
        senhaError.value = 'A senha deve ter no mínimo 8 caracteres.';
        return;
    }

    try {
        const dados = {
            nome: nome.value,
            sobrenome: sobrenome.value,
            email: email.value,
            senha: senha.value,
            saldo: saldo.value,
            image: image.value,
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
        localStorage.setItem('tutorialProduto', 'true');
        localStorage.setItem('store', store.value); // Armazena 'store' como booleano

        
        toast.success('Usuário registrado com sucesso!');
        setTimeout(() => {
            router.push('/dashboard/inicio');
        }, 2000);

        // Limpar os campos após o registro e login
        nome.value = '';
        sobrenome.value = '';
        email.value = '';
        senha.value = '';
        saldo.value = 0;
        image.value = '';
    } catch (erro) {
        toast.error(`Erro ao registrar: ${erro.message}`);
    }
}
</script>

<template>
    <div class="criar col-10 col-md-4 m-auto">
        <form class="input-group px-2 px-md-5 row" @submit.prevent="registrar">
            <label class="text-start my-2">Qual seu nome? <span class="text-danger">*</span></label>
            <input class="form-control rounded-5 p-2 px-3 mb-2" type="text" v-model="nome" placeholder="Nome"
                required />

            <label class="text-start my-2">Qual seu sobrenome? <span class="text-danger">*</span></label>
            <input class="form-control rounded-5 p-2 px-3 mb-2" type="text" v-model="sobrenome" placeholder="Sobrenome"
                required />

            <label class="text-start my-2">Seu melhor e-mail? <span class="text-danger">*</span></label>
            <input class="form-control rounded-5 p-2 px-3 mb-2" type="email" v-model="email" placeholder="E-mail"
                required />

            <label class="text-start my-2">Crie uma senha <span class="text-danger">*</span></label>
            <input class="form-control rounded-5 p-2 px-3 mb-2" type="password" v-model="senha" placeholder="Senha"
                required />
            <div v-if="senhaError" class="text-danger ">{{ senhaError }}</div>

            <label class="text-start my-2 d-none">Saldo <span class="text-danger">*</span></label>
            <input class="form-control rounded-5 p-2 px-3 mb-4" v-model.number="saldo" placeholder="Saldo" hidden />

            <label class="text-start my-2 d-none">Imagem <span class="text-danger">*</span></label>
            <input class="form-control rounded-5 p-2 px-3 mb-4" type="image" v-model="image" placeholder="Imagem"
                hidden />

            <div class="row mt-3">
                <button class="btn btn-success m-auto col-10 col-md-6 rounded-5 fs-4 fw-bold"
                    type="submit">Continuar</button>
            </div>
            <span class="termos pt-3">Clicando no botão, você concorda com nossos termos de <span
                    class=termo>política</span> e
                <span class=termo>privacidade</span></span>
        </form>
    </div>
</template>
