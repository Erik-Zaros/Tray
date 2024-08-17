<script setup>
import { ref, onMounted } from 'vue';
import { useRouter } from 'vue-router';
import Progress from './components/Progress.vue'

const user = ref({});
const router = useRouter();

onMounted(() => {
    const userData = JSON.parse(localStorage.getItem('user'));
    if (userData) {
        user.value = userData;
    } else {
        router.push('/login');
    }
});

function formatDate(dateString) {
    const options = { day: '2-digit', month: '2-digit', year: 'numeric' };
    return new Date(dateString).toLocaleDateString('pt-BR', options);
}

</script>

<template>

    <div class="container-fluid d-flex p-0">

        <div class="col-12 col-md-6">

            <div class="content-1 shadow-sm m-3 p-3 rounded-4 d-flex align-items-center">
                <div class="col-3">
                    <img class="perfil shadow-sm rounded-circle" src="/public/image/logoroll.png" alt="">
                </div>
                <div class="col-5">
                    <h4 class="nome">{{ user.username }}</h4>
                    <span class="texto">Por aqui desde {{ formatDate(user.created_at) }}</span>
                </div>
                <div class="col-auto d-flex flex-column align-items-center justify-content-center">
                    <div class="texto">Loja em Implantacao
                        <i class="fa-regular fa-circle-up"></i>
                    </div>
                    <div class="inaugurar">
                        <button class="btn btn-primary mt-2 px-4">Inaugurar Loja</button>
                    </div>
                </div>
            </div>

            <div class="content-2 m-3 p-3 rounded-4">
                <div class="post d-flex justify-content-between">

                    <div class="profile d-flex align-items-center">
                        <img class="perfil-post shadow-sm rounded-circle m-auto" src="/public/image/logoroll.png"
                            alt="">
                        <div class="textos ps-3">
                            <h6 class="titulo mb-0 mt-3">Dicas do Especialista</h6>
                            <p class="texto">Thomas Turbando</p>
                        </div>
                    </div>

                    <div class="d-flex align-items-center">
                        <a class="text-decoration-none" href="">Ver Mais</a>
                    </div>

                </div>

                <div class="post-content p-4">
                    <h5>💡 <strong>Dica do Especialista: Personalize Sua Loja!</strong> 🎨</h5>
                    <p>Quer <strong>aumentar suas vendas</strong>? Experimente a personalização!</p>
                    <ul>
                        <li>🔍 <strong>Analise o Comportamento</strong>: Veja o que seus clientes estão buscando.</li>
                        <li>🛍️ <strong>Recomendações</strong>: Mostre produtos relacionados às suas compras anteriores.
                        </li>
                        <li>🎯 <strong>Ofertas Personalizadas</strong>: Crie promoções específicas para cada perfil de
                            cliente.</li>
                    </ul>
                    <p>Transforme a experiência do seu usuário e veja os resultados! 🚀</p>
                </div>


            </div>

        </div>

        <div class="col-12 col-md-6">

            <div class="content-3 my-3 me-3 px-5 rounded-4">
                <div class="plano d-flex justify-content-between align-items-center">
                    <h3 class="titulo fw-bold">Meu Plano</h3>
                    <a class="text-decoration-none" href="">Gerenciar Plano</a>
                </div>

                <div class="progress w-100">
                    <h5 class="conclusao position-absolute pt-4">Cadastro da Loja</h5>
                    <Progress class="progress-circle m-auto pt-4" />
                </div>

            </div>

        </div>

    </div>


</template>

<style scoped>
.container-fluid {
    height: 92vh;
    background-color: var(--background-secondary);
}

.content-1 {
    height: 30vh;
    background-color: var(--background-primary);
}

.content-2 {
    background-color: var(--background-primary);
    height: 56vh;
}

.content-3 {
    background-color: var(--background-primary);
    height: 88vh;
}

.perfil {
    height: 120px;
    width: 120px;
}

.texto {
    color: var(--text-color-sub);
    font-size: .9rem;
}

.plano {
    border-bottom: 1px solid rgba(200, 200, 200, .3);
    height: 20%;
}

.progress {
    background-color: var(--background-primary);
    height: 80%;
}

.progress-circle {
    transform: scale(2);
}

.post {
    border-bottom: 1px solid rgba(200, 200, 200, .3);
    height: 20%;
}

.perfil-post {
    height: 50px;
}

.post-content {
    height: 80%;

}
</style>