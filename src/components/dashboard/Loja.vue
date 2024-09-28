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
const categoriaSelecionada = ref(null);
const indiceAtual = ref(0); // Adicionado para controlar a posição dos produtos

// Método para selecionar a categoria
const selecionarCategoria = (categoria) => {
    categoriaSelecionada.value = categoria;
    indiceAtual.value = 0; // Reinicia o índice ao mudar de categoria
};

// Computed property para filtrar produtos pela categoria
const produtosFiltrados = computed(() => {
    const produtosFiltradosPorCategoria = categoriaSelecionada.value
        ? produtos.value.filter(produto => produto.categoria === categoriaSelecionada.value)
        : produtos.value;

    return produtosFiltradosPorCategoria.slice(indiceAtual.value, indiceAtual.value + 4); // Limita a 4 produtos
});

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

// Computed properties para navegação
const temProximo = computed(() => {
    const total = categoriaSelecionada.value ? produtos.value.filter(produto => produto.categoria === categoriaSelecionada.value).length : produtos.value.length;
    return (indiceAtual.value + 4) < total;
});

const temAnterior = computed(() => {
    return indiceAtual.value > 0;
});

// Funções de navegação
const proximoProduto = () => {
    if (temProximo.value) {
        indiceAtual.value += 4; // Mover para o próximo conjunto
    }
};

const anteriorProduto = () => {
    if (temAnterior.value) {
        indiceAtual.value -= 4; // Voltar para o conjunto anterior
    }
};

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
                    <div class="w-100 mx-auto bg-success d-flex justify-content-center flex-wrap">
                        <div class="col-md-3 d-flex mb-4" v-for="categoria in categoriasUnicas" :key="categoria"
                            @click="selecionarCategoria(categoria)">
                            <p class="categoria m-auto pt-sm-4">{{ categoria }}</p>
                        </div>
                    </div>
                </div>

                <div class="cards container p-3">
                    <div class="d-flex justify-content-between mb-3">
                        <button class="btn btn-secondary" @click="anteriorProduto" :disabled="!temAnterior">Anterior</button>
                        <button class="btn btn-secondary" @click="proximoProduto" :disabled="!temProximo">Próximo</button>
                    </div>

                    <div class="row">
                        <div class="col-md-3 m-auto" v-for="produto in produtosFiltrados" :key="produto.id">
                            <CardProdutos :referencia="produto.referencia" :image="produto.image"
                                :descricao="produto.descricao" :categoria="produto.categoria" :preco="produto.preco" />
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
    display: flex;
    justify-content: center;
    flex-wrap: wrap;
    color: azure;
}

.categoria:hover {
    cursor: pointer;
    color: rgb(210, 213, 213);
}
</style>
