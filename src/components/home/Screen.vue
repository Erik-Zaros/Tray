<script setup>
</script>

<template>
    <div class="container-fluid d-flex p-0">
        <div class="col-12 col-md-6 d-flex align-items-center justify-content-end">
            <div class="textos col-8">
                <h1 class="titulo fw-bolder col-10">A plataforma para vender de verdade</h1>
                <p class="texto col-11 my-4">Tudo o que você precisa para vender na internet, integrado em um único painel: recursos para vender, gerenciar e escalar a sua loja virtual</p>
                <button class="btn btn-primary rounded-5 px-4">
                    <RouterLink class="text-decoration-none text-light fs-4" to="/signup">Começar agora</RouterLink>
                </button>
            </div>
        </div>

        <div class="col-12 col-md-6 position-relative d-flex align-items-center justify-content-center">
            <div class="content col-10 d-flex z-1">
                <img class="roll m-auto fa-spin" src="/public/image/roll.png" alt="">
                <img class="logo position-absolute" src="/public/image/logoroll.png" height="160px" alt="">
            </div>
            <div class="position-absolute z-0 col-10 overflow-hidden" style="height: 92vh; overflow: hidden;">
                <div class="carousel-container">
                    <img class="bussines" src="/public/image/bussines.png" alt="">
                    <img class="bussines" src="/public/image/bussines.png" alt="">
                </div>
            </div>
        </div>
    </div>
</template>

<style setup>
.container-fluid {
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
    color: var(--title-color);
}

.texto {
    font-size: 1.1em;
    color: var(--text-color-sub);
}

.roll {
    filter: drop-shadow(0px 0px 15px rgba(0, 0, 0, .15))
}

.logo {
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
    filter: drop-shadow(0px 0px 15px rgba(0, 0, 0, .15))
}

.fa-spin {
    animation-duration: 28s !important;
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
        transform: translateY(-100%);
    }
}
</style>
