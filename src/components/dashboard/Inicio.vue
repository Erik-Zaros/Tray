<script setup>
import { obterDadosUsuario } from '../../services/api';
import { ref, onMounted } from 'vue';
import { useRouter } from 'vue-router';
import Progress from './components/Inicio/Progress.vue'

const usuario = ref(null);
const router = useRouter();
const iniciado = ref(false);

onMounted(async () => {
  try {
    const dados = await obterDadosUsuario();
    usuario.value = dados;
    localStorage.setItem('usuarioId', dados.id);
  } catch (erro) {
    router.push('/login');
  }
});
</script>

<template>

    <div class="container-fluid d-flex p-0" v-if="usuario">

        <div class="col-12 col-md-6">

            <div id="tour-10"
                class="content-1 shadow-sm m-3 p-3 rounded-4 d-flex align-items-center justify-content-between">
                <div class="d-flex align-items-center">
                    <img class="perfil ms-2 ms-md-5 shadow-sm rounded-circle" src="/image/logoroll.png" alt="">
                    <div class="dados ms-2 ms-md-4">
                        <h3 class="nome">{{ usuario.nome }}</h3>
                        <span class="texto">{{ usuario.email }}</span> <!-- alterar para data de criacao conta -->
                    </div>
                </div>
                <div class="implantacao pe-2 pe-md-4 d-flex flex-column align-items-center justify-content-center">
                    <div class="texto text-center"><span>Loja em Implantação
                            <i class="fa-regular fa-circle-up"></i></span>
                    </div>
                    <div class="inaugurar">
                        <button class="mt-1 px-1 mt-sm-3 px-sm-4" :class="iniciado ? 'btn btn-danger' : 'btn btn-primary'" @click="iniciado = !iniciado">
                            {{ iniciado ? 'Parar' : 'Iniciar' }}
                        </button>
                    </div>
                </div>
            </div>

            <div id="tour-11" class="content-2 m-3 p-3 rounded-4">

                <div class="post m-0 px-4 d-flex justify-content-between">

                    <div class="profile m-0 d-flex align-items-center">
                        <img class="perfil-post shadow-sm rounded-circle m-auto" src="/image/logoroll.png" alt="">
                        <div class="textos ps-3">
                            <h4 class="titulo mb-0 mt-2">Dicas do Especialista</h4>
                            <p class="texto">Thiago Sarraf</p>
                        </div>
                    </div>

                    <div class="ver d-flex m-0 ps-1 align-items-center">
                        <a class="text-decoration-none text-center" href="https://br.linkedin.com/in/thiagosarraf" target="_blank">Ver Mais</a>
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

            <div id="tour-12" class="content-3 ms-1 my-sm-3 me-3 px-5 rounded-4">
                <div class="plano d-flex justify-content-between align-items-center">
                    <h3 class="titulo fw-bold">Meu Plano</h3>
                    <a class="text-decoration-none" href="https://tray.com.br/planos-precos/">Gerenciar Plano</a>
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
    width: 30%;
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

    .dados>.nome {
        font-size: 1em;
    }

    .texto {
        font-size: .5em;
    }

    .textos>.titulo {
        font-size: 13px;
    }

    .ver>a {
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