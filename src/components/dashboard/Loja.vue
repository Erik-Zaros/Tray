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
const indiceAtual = ref(0);
const lightColor = ref('');
const intermediateColor = ref('');
const strongColor = ref('')
const store = ref(false);

const selecionarCategoria = (categoria) => {
    categoriaSelecionada.value = categoria;
    indiceAtual.value = 0;
};

const produtosFiltrados = computed(() => {
    const produtosAtivosPorCategoria = categoriaSelecionada.value
        ? produtos.value.filter(produto => produto.categoria === categoriaSelecionada.value && produto.status === true)
        : produtos.value.filter(produto => produto.status === true);

    return produtosAtivosPorCategoria.slice(indiceAtual.value, indiceAtual.value + 4);
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

const temProximo = computed(() => {
    const total = categoriaSelecionada.value
        ? produtos.value.filter(produto => produto.categoria === categoriaSelecionada.value && produto.status === true).length
        : produtos.value.filter(produto => produto.status === true).length;
    return (indiceAtual.value + 4) < total;
});

const temAnterior = computed(() => {
    return indiceAtual.value > 0;
});

const proximoProduto = () => {
    if (temProximo.value) {
        indiceAtual.value += 4;
    }
};

const anteriorProduto = () => {
    if (temAnterior.value) {
        indiceAtual.value -= 4;
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


        const storeValue = localStorage.getItem('store');
        store.value = storeValue === 'true';
        console.log('Store Value:', store.value);


        // Carregar a cor do localStorage
        const savedColors = JSON.parse(localStorage.getItem('selectedProduct'));
        if (savedColors && savedColors.lightColor) {
            lightColor.value = savedColors.lightColor;
            intermediateColor.value = savedColors.intermediateColor;
            strongColor.value = savedColors.strongColor
        }

    } catch (erro) {
        console.error('Erro ao obter dados do usuário:', erro.message);
        router.push('/login');
    }
});


</script>

<template>
    <div class="store position-relative p-2 p-sm-5">
        <div class="loja bg-light rounded-5 p-3 p-sm-4 h-100">
            <div v-if="store" class="pagina-1 rounded-4 h-100 w-100 d-flex flex-column"
                :style="{ backgroundColor: lightColor }">

                <header class="header">
                    <nav class="navbar navbar-expand-lg rounded-top-4" :style="{ backgroundColor: strongColor }">
                        <div class="container-fluid">
                            <a class="navbar-brand" href="#">SUA LOJA</a>
                            <button class="navbar-toggler" type="button" data-bs-toggle="collapse"
                                data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent"
                                aria-expanded="false" aria-label="Toggle navigation">
                                <span class="navbar-toggler-icon"></span>
                            </button>
                            <div class="collapse navbar-collapse" id="navbarSupportedContent">
                                <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                                    <li class="nav-item" hidden>
                                        <a class="nav-link active" aria-current="page" href="#">Home</a>
                                    </li>
                                    <li class="nav-item" hidden>
                                        <a class="nav-link" href="#">Link</a>
                                    </li>
                                </ul>
                                <form class="d-flex" role="search">
                                    <input class="form-control me-2" type="search" placeholder="Search"
                                        aria-label="Search">
                                    <button class="btn btn-success" type="submit">Search</button>
                                </form>
                            </div>
                        </div>
                    </nav>
                </header>

                <div class="menu d-flex" :style="{ backgroundColor: lightColor }">
                    <div class="textos m-auto">
                        <h1 class="titulo text-center"> SUA LOJA</h1>
                        <p class="sub-titulo text-center">loja maneira e descolada!</p>
                    </div>
                </div>

                <div class="categoria">
                    <div class="w-100 mx-auto d-flex justify-content-center flex-wrap"
                        :style="{ backgroundColor: intermediateColor }">
                        <div class="col-md-3 d-flex mb-4" v-for="categoria in categoriasUnicas" :key="categoria"
                            @click="selecionarCategoria(categoria)">
                            <p class="categoria m-auto pt-sm-4">{{ categoria }}</p>
                        </div>
                    </div>
                </div>

                <div class="cards mx-auto d-flex align-items-center p-3">
                    <i class="fas fs-2 p-2 fa-chevron-left" @click="anteriorProduto" :disabled="!temAnterior"></i>

                    <div class="row">
                        <div class="col-md-3 m-auto" v-for="produto in produtosFiltrados" :key="produto.id">
                            <CardProdutos :referencia="produto.referencia" :image="produto.image"
                                :descricao="produto.descricao" :categoria="produto.categoria" :preco="produto.preco" />
                        </div>
                    </div>
                    <i class="fas fs-2 p-2 fa-chevron-right" @click="proximoProduto" :disabled="!temProximo"></i>
                </div>

            </div>

            <div v-else class="h-100 w-100 d-flex position-relative justify-content-center align-items-center">
                <div class="error rounded-4 w-100 h-100 d-flex justify-content-center align-items-center">
                    <div class="erro drop-shadow z-2 text-white text-center">
                        <p class="">Sua loja esta inativa!</p>
                        <p>
                            Para ativa-la, basta apertar o botao na tela inicial.
                        </p>
                        <RouterLink to="/dashboard/inicio" class="text-primary cursor-pointer">
                            ir para tela inicial.</RouterLink>
                    </div>
                </div>
                <div class="error-img position-absolute z-1">
                    <img class="" src="https://cdn-icons-png.flaticon.com/512/8373/8373648.png" alt="">
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

.error {
    background-color: rgb(190, 190, 190);
}

.erro {
    font-size: 3rem;
    font-weight: bolder;
    color: rgb(161, 160, 160);
}
</style>
