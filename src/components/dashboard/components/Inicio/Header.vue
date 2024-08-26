<script setup>
import { ref } from 'vue';
import { useRouter } from 'vue-router';
import { logout } from '../../../../services/api';
 
const router = useRouter();
const menu = ref(false);

function mudarMenu() {
    menu.value = !menu.value;
}

const deslogar = async () => {
    try {
        await logout(); // Chama a função de logout da api.js
        router.push('/login');
    } catch (error) {
        console.error('Erro ao fazer logout:', error);
        alert('Erro ao fazer logout. Tente novamente.');
    }
};

</script>


<template>

    <div>

        <div class="horizontal d-flex vw-100 justify-content-between px-4">
            <div class="menu d-flex align-items-center">
                <i id="tour-1" class="menu-icon fa-solid rounded fa-bars fs-1" @click="mudarMenu">
                </i>
            </div>

            <div class="d-flex align-items-center">
                <form class="search-input me-2 mb-2 mb-lg-0 position-relative">
                    <input type="text" class="search form-control form-control-sm rounded-5 px-3 py-2 pe-5"
                        placeholder="Pedidos, Clientes e Recursos" />
                    <i class="search-icon fas fa-search position-absolute"
                        style="top: 50%; right: 15px; transform: translateY(-50%);"></i>
                </form>

                <i class="fa-regular fa-bell fs-3 px-2 px-md-3"></i>
                <i class="fa-regular fa-circle-question fs-3 px-2 px-md-3"></i>

                <div class="dropdown">
                    <button class="btn btn-default dropdown-toggle" type="button" data-bs-toggle="dropdown"
                        aria-expanded="false">
                        NOME
                    </button>
                    <ul class="dropdown-menu" role="menu">
                        <li><a class="dropdown-item" href="#">Seu Perfil</a></li>
                    </ul>
                </div>
            </div>
        </div>

        <div
            :class="['vertical', 'd-flex', 'flex-column', 'align-items-between', 'justify-content-between', 'text-center', { expanded: menu }]">

            <div class="content-1">
                <label class="icon-wrapper my-1"><router-link to="/dashboard/inicio">
                        <input type="radio" name="icon-selection" class="icon-radio" checked></router-link>
                    <i id="tour-2" class="fa-regular icon-menu d-flex py-3 px-4 rounded fa-flag"><span
                            class="text-icon px-2">Início</span></i>
                </label>
                <label class="icon-wrapper my-1"><router-link to="/dashboard/perfil">
                        <input type="radio" name="icon-selection" class="icon-radio"></router-link>
                    <i id="tour-3" class="fa-regular icon-menu d-flex py-3 px-4 rounded fa-user"><span
                            class="text-icon px-2">Perfil</span></i>
                </label>
                <label class="icon-wrapper my-1"><router-link to="/dashboard/loja">
                        <input type="radio" name="icon-selection" class="icon-radio"></router-link>
                    <i id="tour-4" class="fa-solid icon-menu d-flex py-3 px-4 rounded fa-store"><span
                            class="text-icon px-2">Sua Loja</span></i>
                </label>
            </div>

            <div class="content-2">
                <label class="icon-wrapper my-1"><router-link to="/dashboard/produtos">
                    <input type="radio" name="icon-selection" class="icon-radio"></router-link>
                    <i id="tour-5" class="fa-solid icon-menu d-flex py-3 px-4 rounded fa-tag"><span
                            class="text-icon px-2">Produtos</span></i>
                </label>
                <label class="icon-wrapper my-1"><router-link to="/dashboard/templates">
                    <input type="radio" name="icon-selection" class="icon-radio"></router-link>
                    <i id="tour-6" class="fa-solid icon-menu d-flex py-3 px-4 rounded fa-tv"><span
                            class="text-icon px-2">Templates</span></i>
                </label>
                <label class="icon-wrapper my-1"><router-link to="/dashboard/configuracao">
                    <input type="radio" name="icon-selection" class="icon-radio"></router-link>
                    <i id="tour-7" class="fa-solid icon-menu d-flex py-3 px-4 rounded fa-gear"><span
                            class="text-icon px-2">Configurações</span></i>
                </label>
            </div>

            <div class="content-3">
                <label class="icon-wrapper my-1"><router-link to="/dashboard/ajuda">
                    <input type="radio" name="icon-selection" class="icon-radio"></router-link>
                    <i id="tour-8" class="fa-regular icon-menu d-flex py-3 px-4 rounded fa-circle-question"><span
                            class="text-icon px-2">Ajuda</span></i>
                </label>
                <label class="icon-wrapper my-1" @click="deslogar">
                    <input type="radio" name="icon-selection" class="icon-radio">
                    <i id="tour-9" class="fa-solid icon-menu d-flex py-3 px-4 rounded fa-right-from-bracket"><span
                            class="text-icon px-2">Logout</span></i>
                </label>
            </div>
        </div>

    </div>

</template>

<style scoped>
* {
    color: white;
    box-sizing: border-box; 
}

html, body {
    margin: 0;
    padding: 0;
    height: 100%; 
}

.content {
    display: flex;
    height: 100vh; 
    overflow: hidden; 
}

.horizontal {
    background-color: #424242;
    height: 8vh;
    width: 100%;
    position: fixed; 
    top: 0;
    left: 0;
    z-index: 1000; 
}

.vertical {
    background-color: #484848;
    height: 92vh; 
    width: 80px;
    position: fixed; 
    top: 8vh; 
    left: 0;
    z-index: 999; 
    transition: width 0.3s; 
}

.vertical:hover,
.vertical.expanded {
  width: 200px;

  & .text-icon {
    display: block;
  }
}

.content-wrapper {
    margin-left: 80px; 
    margin-top: 8vh; 
    flex: 1;
    overflow-y: auto; 
    padding: 16px; 
    background-color: #f4f4f4; 
}

.menu-icon {
    transition: .2s;
}

.menu-icon:hover {
    transform: scale(1.08);
    transition: .2s;
    cursor: pointer;
}

.search {
    background-color: rgba(255, 255, 255, .6);
    border: none;
}

.search-icon {
    cursor: pointer;
}

.dropdown-menu {
    background-color: #424242;
}

.icon-menu {
    cursor: pointer;
}

.text-icon {
    display: none;
    font-weight: normal;
}

.icon-menu:hover {
    background-color: rgb(0, 110, 255);
}

.icon-wrapper {
    position: relative;
    display: inline-block;
    transition: .5s;
}

.icon-radio {
    position: absolute;
    opacity: 0;
    cursor: pointer;
}

.icon-radio:checked+.fa-solid {
    background-color: rgb(0, 110, 255);
}


@media (max-width: 1024px) {
    .search-input {
        display: none;
    }
}
</style>