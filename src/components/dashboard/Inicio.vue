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

            <div id="tour-10" class="content-1 shadow-sm m-3 p-3 rounded-4 d-flex align-items-center">
                <div class="col-3">
                    <img class="perfil shadow-sm rounded-circle" src="/image/logoroll.png" alt="">
                </div>
                <div class="col-5 dados">
                    <h3 class="nome">{{ user.username }}</h3>
                    <span class="texto">Por aqui desde {{ formatDate(user.created_at) }}</span>
                </div>
                <div class="implantacao col-auto d-flex flex-column align-items-center justify-content-center">
                    <div class="texto">Loja em Implantacao
                        <i class="fa-regular fa-circle-up"></i>
                    </div>
                    <div class="inaugurar">
                        <button class="btn btn-primary mt-1 px-1 mt-sm-2 px-sm-4">iniciar</button>
                    </div>
                </div>
            </div>

            <div id="tour-11" class="content-2 m-3 p-3 rounded-4">

                <div class="post m-0 px-4 d-flex justify-content-between">

                    <div class="profile m-0 d-flex align-items-center">
                        <img class="perfil-post shadow-sm rounded-circle m-auto" src="/image/logoroll.png" alt="">
                        <div class="textos ps-3">
                            <h4 class="titulo mb-0 mt-2">Dicas do Especialista</h4>
                            <p class="texto">Thomas Turbando</p>
                        </div>
                    </div>

                    <div class="ver d-flex m-0 ps-1 align-items-center">
                        <a class="text-decoration-none text-center" href="">Ver Mais</a>
                    </div>

                </div>

                <div class="post-content p-4">
                    <h6>💡 <strong>Dica do Especialista: Personalize Sua Loja!</strong> 🎨</h6>
                    <p class="text-post">Quer <strong>aumentar suas vendas</strong>? Experimente a personalização!</p>
                    <ul>
                        <p class="text-post">🔍 <strong>Analise o Comportamento</strong>: Veja o que seus clientes estão
                            buscando.</p>
                        <p class="text-post">🛍️ <strong>Recomendações</strong>: Mostre produtos relacionados às suas
                            compras anteriores.
                        </p>
                        <p class="text-post">🎯 <strong>Ofertas Personalizadas</strong>: Crie promoções específicas para
                            cada perfil de
                            cliente.</p>
                    </ul>
                    <p class="text-post">Transforme a experiência do seu usuário e veja os resultados! 🚀</p>
                </div>


            </div>

        </div>

        <div class="col-12 col-md-6">

            <div id="tour-12" class="content-3 mx-3 my-sm-3 me-sm-3 px-5 rounded-4">
                <div class="plano d-flex justify-content-between align-items-center">
                    <h3 class="titulo fw-bold">Meu Plano</h3>
                    <a class="text-decoration-none" href="">Gerenciar Plano</a>
                </div>

                <div class="progress w-100">
                    <h5 class="conclusao position-absolute pt-4">Cadastro da Loja</h5>
                    <Progress class="progress-circle m-auto pt-5" />
                </div>

            </div>

        </div>

    </div>


</template>

<style scoped>
.html {
    overflow-x: hidden;
}

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
    height: 10%;
    width: 80%;
}

.texto {
    color: var(--text-color-sub);
    font-size: 1em;
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
    transform: scale(2.5);
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
    font-size: 1.9vh;
}

@media (max-width: 724px) {

    .container-fluid {
        height: 150vh;
        background-color: var(--background-secondary);
    }

    .container-fluid {
        flex-direction: column;
    }

    .content-1 {
        height: 20vh;
        background-color: var(--background-primary);
    }

    .content-2 {
        background-color: var(--background-primary);
        height: 66vh;
    }

    .content-3 {
        background-color: var(--background-primary);
        height: 57vh;
    }

    .dados > .nome {
        font-size: 1em;
    }

    .texto {
        font-size: .5em;
    }

    .textos > .titulo {
        font-size: 13px;
    }

    .ver > a {
        font-size: .8rem;
    }

    .perfil-post {
        height: 35px;
    }

    .post-content {
        height: 0%;
        font-size: 1.5vh;
    }

    .plano {
        height: 20%;
    }

    .plano>.titulo {
        font-size: 20px;
    }

    .plano>a {
        font-size: 14px;
    }

    .progress {
        background-color: var(--background-primary);
    }

    .progress-circle {
        transform: scale(1.2);
    }
}
</style>