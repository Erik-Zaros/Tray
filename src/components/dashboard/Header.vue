<script setup>
import { ref, onMounted } from 'vue';
import { useRouter } from 'vue-router';

const user = ref({});
const router = useRouter();

const menu = ref(false);

function mudarMenu() {
  menu.value = !menu.value;
}

onMounted(() => {
  const userData = JSON.parse(localStorage.getItem('user'));
  if (userData) {
    user.value = userData;
  } else {
    router.push('/login');
  }
});

const logout = () => {
  localStorage.removeItem('user');
  localStorage.removeItem('loginTime');
  router.push('/login');
};

</script>


<template>

    <div class="container-fluid">

        <div class="horizontal d-flex w-100 justify-content-between px-4">
            <div class="menu d-flex align-items-center">
                <i 
          class="menu-icon fa-solid rounded fa-bars fs-1"
          @click="mudarMenu">
        </i>            </div>

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
                        {{ user.username }}
                    </button>
                    <ul class="dropdown-menu" role="menu">
                        <li>
                            <a class="dropdown-item" href="#">{{ user.first_name }}</a>
                        </li>
                        <li><a class="dropdown-item" href="#">{{ user.email }}</a></li>
                        <li><a class="dropdown-item" href="#"> Settings </a></li>
                    </ul>
                </div>
            </div>

        </div>


        <div :class="['vertical', 'd-flex', 'flex-column', 'align-items-between', 'justify-content-between', 'text-center', { expanded: menu }]">

            <div class="content-1">
                <label class="icon-wrapper my-1">
                    <input type="radio" name="icon-selection" class="icon-radio" checked>
                    <i class="fa-regular icon-menu d-flex py-3 px-4 rounded fa-flag"><span class="text-icon px-2">Início</span></i>
                </label>
                <label class="icon-wrapper my-1">
                    <input type="radio" name="icon-selection" class="icon-radio">
                    <i class="fa-solid icon-menu d-flex py-3 px-4 rounded fa-chart-line"><span class="text-icon px-2">Performance</span></i>
                </label>
                <label class="icon-wrapper my-1">
                    <input type="radio" name="icon-selection" class="icon-radio">
                    <i class="fa-solid icon-menu d-flex py-3 px-4 rounded fa-chart-simple"><span class="text-icon px-2">Relatórios</span></i>
                </label>
            </div>

            <div class="content-2">
                <label class="icon-wrapper my-1">
                    <input type="radio" name="icon-selection" class="icon-radio">
                    <i class="fa-solid icon-menu d-flex py-3 px-4 rounded fa-cart-shopping"><span class="text-icon px-2">Vendas</span></i>
                </label>
                <label class="icon-wrapper my-1">
                    <input type="radio" name="icon-selection" class="icon-radio">
                    <i class="fa-solid icon-menu d-flex py-3 px-4 rounded fa-tag"><span class="text-icon px-2">Produtos</span></i>
                </label>
                <label class="icon-wrapper my-1">
                    <input type="radio" name="icon-selection" class="icon-radio">
                    <i class="fa-solid icon-menu d-flex py-3 px-4 rounded fa-tv"><span class="text-icon px-2">Marketing</span></i>
                </label>
                <label class="icon-wrapper my-1">
                    <input type="radio" name="icon-selection" class="icon-radio">
                    <i class="fa-solid icon-menu d-flex py-3 px-4 rounded fa-shop"><span class="text-icon px-2">Marketplaces</span></i>
                </label>
                <label class="icon-wrapper my-1">
                    <input type="radio" name="icon-selection" class="icon-radio">
                    <i class="fa-solid icon-menu d-flex py-3 px-4 rounded fa-gear"><span class="text-icon px-2">Configurações</span></i>
                </label>
            </div>

            <div class="content-3">
                <label class="icon-wrapper my-1">
                    <input type="radio" name="icon-selection" class="icon-radio">
                    <i class="fa-regular icon-menu d-flex py-3 px-4 rounded fa-circle-question"><span class="text-icon px-2">Ajuda</span></i>
                </label>
                <label class="icon-wrapper my-1" @click="logout">
                    <input type="radio" name="icon-selection" class="icon-radio">
                    <i class="fa-solid icon-menu d-flex py-3 px-4 rounded fa-right-from-bracket"><span class="text-icon px-2">Logout</span></i>
                </label>
            </div>

        </div>

    </div>

</template>

<style scoped>
* {
    color: white;
}

.container-fluid {
    margin: 0;
    padding: 0;
}

.horizontal {
    background-color: #424242;
    height: 8vh;
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




.vertical {
    background-color: #484848;
    height: 92vh;
    width: 80px;
    transition: .3s;
}

.vertical.expanded {
    width: 200px;
    transition: .3s;
    & .text-icon {
        display: block;
        transition: .5s;
    }
}

.icon-menu {
    cursor: pointer;
}

.text-icon {
    display: none; 
    transition: .5s;
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