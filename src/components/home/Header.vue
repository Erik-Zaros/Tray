<script setup>
import { RouterLink } from 'vue-router';

</script>

<template>
    <nav class="navbar navbar-expand-lg">
        <div class="container">
            <a class="navbar-brand me-5" href="#"><img src="/public/image/tray.png" alt="" height="40px"></a>
            <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarText"
                aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarText">
                <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                    <li class="nav-item">
                        <a class="nav-link" href="#">Planos</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="#">Dropshipping</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="#">Live Shop</a>
                    </li>
                    <li class="nav-item dropdown">
                        <a class="nav-link dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown"
                            aria-expanded="false">
                            Recursos
                        </a>
                        <ul class="dropdown-menu">
                            <li><a class="dropdown-item" href="#">Canais de Venda</a></li>
                            <li><a class="dropdown-item" href="#">Redes Sociais</a></li>
                            <li><a class="dropdown-item" href="#">Ecossistemas</a></li>
                            <li><a class="dropdown-item" href="#">Operação</a></li>
                            <li><a class="dropdown-item" href="#">Segmentos</a></li>
                        </ul>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="#">Integrações</a>
                    </li>
                    <li class="nav-item dropdown">
                        <a class="nav-link dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown"
                            aria-expanded="false">
                            Parceiros
                        </a>
                        <ul class="dropdown-menu">
                            <li><a class="dropdown-item" href="#">Parceiros Certificados</a></li>
                            <li><a class="dropdown-item" href="#">Quero ser Parceiro</a></li>
                            <li><a class="dropdown-item" href="#">Loja de Temas</a></li>
                            <li><a class="dropdown-item" href="#">Loja de Serviços</a></li>
                        </ul>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="#">Aprenda</a>
                    </li>
                </ul>
                <span class="navbar-text d-flex align-items-center">
                    <div class="mx-3">|</div>
                    <i class="fa-regular fa-circle-user fs-5"></i>
                    <routerLink class="dropdown-item text-decoration-none mx-3" to="/login">Login</routerLink>
                    <button class="btn btn-success col-6 rounded-5 mx-4"><routerLink class="text-decoration-none text-light" to="/signup">Criar loja agora</routerLink></button>
                </span>
            </div>
        </div>
    </nav>
</template>


<style>

.navbar {
    height: 8vh;
    background-color: var(--background-navbar) !important;
    border-bottom: 1px solid rgba(200, 200, 200, .7);
}

.container,
.navbar-collapse {
    background-color: var(--background-navbar) !important;
}

a {
    font-size: 1.1em!important;
    padding: 0px 5px 0px 5px;
}
</style>