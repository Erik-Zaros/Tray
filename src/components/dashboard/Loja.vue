<script setup>
import { ref, onMounted, computed } from 'vue';
import { useRouter } from 'vue-router';
import { obterDadosUsuario, listarProdutos } from '../../services/api';
import { useToast } from 'vue-toastification';
import CardProdutos from './components/Loja/Card.vue';

const toast = useToast();
const produtos = ref([]);
const usuario = ref({});
const router = useRouter();
const categoriasUnicas = ref([]);

const carregarProdutos = async () => {
    try {
        const resposta = await listarProdutos();
        produtos.value = resposta.produtos || [];

        // Extrai as categorias únicas
        const categorias = produtos.value.map(produto => produto.categoria);
        categoriasUnicas.value = [...new Set(categorias)];
    } catch (erro) {
        toast.info('Sem produtos adicionados:', erro.message);
    }
};

// Computed property para filtrar produtos com status verdadeiro
const produtosAtivos = computed(() => produtos.value.filter(produto => produto.status === true));

onMounted(async () => {
    try {
        const token = localStorage.getItem('token');
        if (!token) {
            router.push('/login');
            return;
        }

        const respostaUsuario = await obterDadosUsuario(token);
        usuario.value = respostaUsuario.usuario;
        await carregarProdutos();
    } catch (erro) {
        console.error('Erro ao obter dados do usuário:', erro.message);
        router.push('/login');
    }
});
</script>

<template>

    <div class="store p-2 p-sm-5">

        <div class="loja bg-light rounded-5 p-3 p-sm-4 h-100">

            <div class="pagina-1 rounded-4 h-100">

                <header class="header">
                    <nav class="navbar navbar-expand-lg bg-body-tertiary">
                        <div class="container-fluid">
                            <a class="navbar-brand" href="#">SUA LOJA</a>
                            <button class="navbar-toggler" type="button" data-bs-toggle="collapse"
                                data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent"
                                aria-expanded="false" aria-label="Toggle navigation">
                                <span class="navbar-toggler-icon"></span>
                            </button>
                            <div class="collapse navbar-collapse" id="navbarSupportedContent">
                                <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                                    <li class="nav-item">
                                        <a class="nav-link active" aria-current="page" href="#">Home</a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" href="#">Link</a>
                                    </li>
                                </ul>
                                <form class="d-flex" role="search">
                                    <input class="form-control me-2" type="search" placeholder="Search"
                                        aria-label="Search">
                                    <button class="btn btn-outline-success" type="submit">Search</button>
                                </form>
                            </div>
                        </div>
                    </nav>
                </header>

                <div class="menu d-flex bg-primary">
                    <div class="textos m-auto">
                        <h1 class="titulo text-center"> SUA LOJA</h1>
                        <p class="sub-titulo text-center">loja maneira e descolada!</p>
                    </div>
                </div>

                <div class="categoria">
                    <div class="w-50 mx-auto bg-success d-flex">
                        <div class="col-md-3 d-flex mb-4">
                            <p class="categoria m-auto pt-sm-4">Categoria 1</p>
                        </div>
                        <div class="col-md-3 d-flex mb-4">
                            <p class="categoria m-auto pt-sm-4">Categoria 2</p>
                        </div>
                        <div class="col-md-3 d-flex mb-4">
                            <p class="categoria m-auto pt-sm-4">Categoria 3</p>
                        </div>
                        <div class="col-md-3 d-flex mb-4">
                            <p class="categoria m-auto pt-sm-4">Categoria 4</p>
                        </div>
                    </div>
                </div>

                <div class="cards container p-3">
                    <div class="row">
                        <!-- Aqui estamos usando o computed produtosAtivos -->
                        <div class="col-md-3 m-auto" v-for="produto in produtosAtivos" :key="produto.id">
                            <CardProdutos 
                                :referencia="produto.referencia" 
                                :image="produto.image"
                                :descricao="produto.descricao" 
                                :categoria="produto.categoria" 
                                :preco="produto.preco" />
                        </div>
                    </div>
                </div>

            </div>

        </div>
    </div>

</template>

<style scoped>
.menu {
    height: 250px;
}

.titulo {
    font-size: 4rem;
}

.sub-titulo {
    font-size: 1rem;
}

.categoria {
    color: azure;
}

.categoria:hover {
    cursor: pointer;
    color: rgb(210, 213, 213);
}
</style>
