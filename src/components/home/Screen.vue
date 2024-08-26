<script setup>
import { ref, onMounted, onUnmounted } from 'vue';
import Score from './Score.vue';

const showScore = ref(window.innerWidth < 1000);

const checkWindowSize = () => {
    showScore.value = window.innerWidth < 1000;
};

onMounted(() => {
    window.addEventListener('resize', checkWindowSize);
});

onUnmounted(() => {
    window.removeEventListener('resize', checkWindowSize);
});
</script>

<template>
    <div class="container-fluid d-flex p-0">
        <div class="content-1 col-12 col-md-6 d-flex align-items-center justify-content-end">
            <div class="textos col-md-8 col-11">
                <h1 class="titulo fw-bolder col-10">A plataforma para vender de verdade</h1>
                <p class="texto col-11 my-4">Tudo o que você precisa para vender na internet, integrado em um único
                    painel: recursos para vender, gerenciar e escalar a sua loja virtual</p>
                <button class="btn btn-primary rounded-5 px-4">
                    <RouterLink class="text-decoration-none text-light fs-4" to="/registrar">Começar agora</RouterLink>
                </button>
            </div>
        </div>

        <Score class="vw-100" v-if="showScore" />

        <div class="content-2 col-12 col-md-6 position-relative d-flex align-items-center justify-content-center">
            <div class="content me-4 me-md-0 col-10 d-flex z-1">
                <img class="roll m-auto fa-spin" src="/image/roll.png" alt="">
                <img class="logo position-absolute" src="/image/logoroll.png" alt="">
            </div>
            <div class="carrossel position-absolute z-0 col-10 overflow-hidden">
                <div class="carousel-container">
                    <img class="bussines" src="/image/bussines.png" alt="">
                    <img class="bussines" src="/image/bussines.png" alt="">
                </div>
            </div>
        </div>
    </div>
</template>

<style scoped>

.container-fluid {
    overflow: hidden;
    height: 92vh;
    background: linear-gradient(300deg, #fdfdff, #dcf3ff, #b9e3f1);
    background-size: 180% 180%;
    animation: gradient-animation 15s ease infinite;
}

@keyframes gradient-animation {
    0% {
        background-position: 0% 50%;
    }

    50% {
        background-position: 100% 50%;
    }

    100% {
        background-position: 0% 50%;
    }
}

.titulo {
    font-size: 3.5em;
    color: var(--color-title);
}

.texto {
    font-size: 1.1em;
    color: var(--text-color-sub);
}

.roll {
    filter: drop-shadow(0px 0px 15px rgba(0, 0, 0, .15))
}

.logo {
    height: 160px;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
    filter: drop-shadow(0px 0px 15px rgba(0, 0, 0, .15))
}

.fa-spin {
    animation-duration: 28s !important;
}

.carrossel {
    height: 92vh;
    overflow: hidden;
}

.carousel-container {
    display: flex;
    flex-direction: column;
    height: 100vh;
    animation: carousel 18s linear infinite;
}

.bussines {
    height: 200vh;
}

@keyframes carousel {
    0% {
        transform: translateY(0);
    }

    100% {
        transform: translateY(-200%);
    }
}

@media (max-width: 1024px) {
    .container-fluid {
        height: auto;
        flex-direction: column;
    }

    .titulo {
        font-size: 2.5em;
    }

    .texto {
        font-size: 1em;
    }

    .content-1 {
        height: 70vh;
    }

    .content-2 {
        height: 100vh;
    }

    .logo {
        height: 120px;
    }

    .roll {
        width: 90%;
    }

    .carousel-container {
        animation: carousel 28s linear infinite;
    }

    .carrossel {
        height: 100vh;
    }

}
</style>
