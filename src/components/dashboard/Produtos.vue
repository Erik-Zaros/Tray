<script setup>
import { ref, onMounted, computed } from 'vue';
import { useRouter } from 'vue-router';
import AdicionarProdutos from './components/Produtos/AdicionarProdutos.vue'; // Importar o modal de cadastro
import EditarProdutos from './components/Produtos/EditarProdutos.vue'; // Importar o modal de cadastro
import ImportarProdutos from './components/Produtos/ImportarProdutos.vue'; // Importar o modal de cadastro
import Produto from './components/Produtos/Produto.vue'; // Importar o modal de cadastros
import { obterDadosUsuario, listarProdutos, excluirProduto as apiExcluirProduto } from '../../services/api'; // Certifique-se de ajustar o caminho conforme necessário
// Notificacoes maneiras
import { useToast } from 'vue-toastification';
const toast = useToast();

const produtosSelecionados = ref([]);

const obterProdutos = async () => {
  try {
    const dados = await listarProdutos();
    produtos.value = dados.produtos;
  } catch (erro) {
    toast.info('Sem produtos adicionados:', erro.message);
  }
};

const selecionarTodos = (event) => {
  if (event.target.checked) {
    produtosSelecionados.value = produtos.value.map(produto => produto.id);
  } else {
    produtosSelecionados.value = [];
  }
};

const marcarProduto = ({ id, selecionado }) => {
  if (selecionado) {
    if (!produtosSelecionados.value.includes(id)) {
      produtosSelecionados.value.push(id);
    }
  } else {
    produtosSelecionados.value = produtosSelecionados.value.filter(produtoId => produtoId !== id);
  }
};

const excluirSelecionados = async () => {
  try {
    for (const id of produtosSelecionados.value) {
      await excluirProduto(id);
    }
    produtosSelecionados.value = [];
    toast.warning("Produtos selecionados excluidos com sucesso")
    await obterProdutos(); // Recarregar a lista de produtos após exclusão
  } catch (erro) {
    toast.error('Erro ao excluir produtos:', erro.message);
  }
};

const todosSelecionados = computed(() => {
  return produtos.value.length > 0 && produtos.value.every(produto => produtosSelecionados.value.includes(produto.id));
});












const produtos = ref([]);
const usuario = ref({});
const router = useRouter();
const filtro = ref({
  codigoReferencia: '',
  nomeProduto: '',
  categorias: '',
  precoDe: '',
  precoAte: ''
});
const categoriasUnicas = ref([]); // Constante para armazenar categorias únicas

const showModalEditar = ref(false);
const produtoAtual = ref({ id: null, nome: '', preco: 0 });

const atualizarProduto = (produto) => {
  console.log('Produto a ser editado:', produto);
  produtoAtual.value = produto;
  showModalEditar.value = true;
};

const closeModal = () => {
  showModalEditar.value = false;
};

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


const excluirProduto = async (produtoId) => {
  try {
    await apiExcluirProduto(produtoId);
    produtos.value = produtos.value.filter(produto => produto.id !== produtoId);
  } catch (erro) {
    toast.error('Erro ao excluir produto.');
  }
};

const produtosFiltrados = computed(() => {
  return produtos.value
    .filter(produto => {
      // Verificar se as propriedades do produto estão definidas e garantir que a operação de conversão para minúsculas não falhe
      const referencia = produto.referencia ? produto.referencia.toLowerCase() : '';
      const nome = produto.descricao ? produto.descricao.toLowerCase() : '';
      const categoria = produto.categoria || '';
      const preco = produto.preco || 0;

      const codigoOuReferenciaMatch = referencia.includes(filtro.value.codigoReferencia.toLowerCase());
      const nomeProdutoMatch = nome.includes(filtro.value.nomeProduto.toLowerCase());
      const categoriaMatch = filtro.value.categorias ? categoria === filtro.value.categorias : true;
      const precoMatch = (!filtro.value.precoDe || preco >= filtro.value.precoDe) &&
        (!filtro.value.precoAte || preco <= filtro.value.precoAte);

      return codigoOuReferenciaMatch && nomeProdutoMatch && categoriaMatch && precoMatch;
    })
    .sort((a, b) => {
      const campo = ordenacao.value.campo;
      if (!campo) return 0;
      const valorA = a[campo] || '';
      const valorB = b[campo] || '';
      if (valorA < valorB) return ordenacao.value.direcao === 'asc' ? -1 : 1;
      if (valorA > valorB) return ordenacao.value.direcao === 'asc' ? 1 : -1;
      return 0;
    });
});

const limparFiltro = () => {
  filtro.value = {
    codigoReferencia: '',
    nomeProduto: '',
    categorias: '',
    precoDe: '',
    precoAte: '',
  };
};

const ordenar = (campo) => {
  if (ordenacao.value.campo === campo) {
    // Alternar a direção da ordenação
    ordenacao.value.direcao = ordenacao.value.direcao === 'asc' ? 'desc' : 'asc';
  } else {
    // Mudar o campo de ordenação e definir a direção como crescente
    ordenacao.value.campo = campo;
    ordenacao.value.direcao = 'asc';
  }
};

const getSortIconClass = (campo) => {
  if (ordenacao.value.campo === campo) {
    return ordenacao.value.direcao === 'asc'
      ? 'fa-solid fa-caret-up text-dark'
      : 'fa-solid fa-caret-down text-dark';
  } else {
    return 'fa-solid fa-sort'; // Ícone padrão quando não está sendo ordenado
  }
};

const ordenacao = ref({ campo: '', direcao: 'asc' }); // Inicializa com ordem crescente


onMounted(async () => {
  try {
    // Certifique-se de que o usuário esteja autenticado
    const token = localStorage.getItem('token');
    if (!token) {
      router.push('/login');
      return;
    }

    const respostaUsuario = await obterDadosUsuario(token);
    usuario.value = respostaUsuario.usuario; 
    await carregarProdutos();
    //console.log(respostaUsuario) mostra dados do usuario logado
  } catch (erro) {
    console.error('Erro ao obter dados do usuário:', erro.message);
    router.push('/login');
  }
});
</script>


<template>
  <div class="container-fluid p-0">
    <div class="mais d-flex align-items-center justify-content-end d-none">
      <button class="btn">
        <span class="texto"><i class="fa-solid fa-circle-info"></i> Mais sobre <strong>nova lista de
            produtos</strong></span>
      </button>
    </div>

    <div class="produtos px-5 py-3 d-flex align-items-center justify-content-between">
      <h4 class="edit fw-bold">Produtos</h4>
      <div class="editar d-flex">
        <a href="" class="options text-decoration-none dropdown-toggle my-auto" data-bs-toggle="dropdown"
          aria-expanded="false">
          <i class="fa-solid fa-ellipsis-vertical me-2"></i> Mais Opções
        </a>
        <ul class="dropdown-menu border-0" role="menu">
          <li><a class="dropdown-item text-primary" href="#">Adicionar Categorias</a></li>
        </ul>

        <ImportarProdutos @produtoAdicionado="carregarProdutos" />
        <button class="btn btn-primary py-2 px-3 ms-3 rounded-0" data-bs-toggle="modal" data-bs-target="#productModal">
          Adicionar Produto
        </button>
      </div>
    </div>

    <div class="lista shadow-sm rounded-2 m-auto">
      <div class="container pt-4">
        <form @submit.prevent="aplicarFiltro">
          <h4 class="filtro-texto pb-3">Filtrar Produtos</h4>
          <div class="row g-3 border-bottom border-top pb-4">
            
            <div class="col-md-6">
              <label for="codigoReferencia" class="form-label">Código ou Referência</label>
              <input v-model="filtro.codigoReferencia" type="text" class="form-control" id="codigoReferencia"
                placeholder="Digite o código ou referência">
            </div>

    
            <div class="col-md-6">
              <label for="nomeProduto" class="form-label">Nome do Produto</label>
              <input v-model="filtro.nomeProduto" type="text" class="form-control" id="nomeProduto"
                placeholder="Digite o nome do produto">
            </div>

    
            <div class="col-md-6">
              <label for="categorias" class="form-label">Categorias</label>
              <select v-model="filtro.categorias" id="categorias" class="form-select">
                <option value="">Selecione...</option>
                <option v-for="categoria in categoriasUnicas" :key="categoria" :value="categoria">
                  {{ categoria }}
                </option>
              </select>
            </div>


    
            <div class="col-md-6">
              <label for="precoDe" class="form-label">Faixa de Preço</label>
              <div class="input-group">
                <span class="preco m-auto p-2 fw-bold">De R$</span>
                <input v-model="filtro.precoDe" type="number" class="form-control rounded" id="precoDe"
                  placeholder="0.00">
                <span class="preco m-auto p-2 fw-bold">Até R$</span>
                <input v-model="filtro.precoAte" type="number" class="form-control rounded" id="precoAte"
                  placeholder="0.00">
              </div>
            </div>

          </div>
  
          <div class="col-12 d-flex justify-content-end pt-3">
          </div>
        </form>
      </div>

      <div class="pt-4">
        <div class="ordem row align-items-center mx-5 p-3 px-3">
  
          <div class="col-auto me-4 mb-3 ordenar-item">
            <input class="form-check-input" type="checkbox" @change="selecionarTodos" :checked="todosSelecionados">
          </div>
          <div class="col-auto me-5 ordenar-item produto-referencia" @click="ordenar('referencia')">
            <p class="ordenar-texto">
              Referência
              <i :class="getSortIconClass('referencia')"></i>
            </p>
          </div>
  
          <div class="col-auto ordenar-item produto-imagem" @click="ordenar('imagem')">
            <p class="ordenar-texto">
              Imagem
            </p>
          </div>
          <div class="col ordenar-item produto-descricao" @click="ordenar('descricao')">
            <p class="ordenar-texto ps-4 ms-1">
              Descrição
              <i :class="getSortIconClass('descricao')"></i>
            </p>
          </div>
          <div class="col ordenar-item produto-categoria" @click="ordenar('categoria')">
            <p class="ordenar-texto ps-3">
              Categoria
              <i :class="getSortIconClass('categoria')"></i>
            </p>
          </div>
          <div class="col ordenar-item produto-preco" @click="ordenar('preco')">
            <p class="ordenar-texto ps-4">
              Preço
              <i :class="getSortIconClass('preco')"></i>
            </p>
          </div>
          <div class="col ordenar-item produto-status" @click="ordenar('status')">
            <p class="ordenar-texto ps-4 ms-1">
              Status
            </p>
          </div>
          <div class="ordenar-item limpar_filtro">
            <button type="button" class="btn btn-outline-dark rounded-0" @click="limparFiltro"><i
                class="fa-solid text-secondary fa-circle-info"></i> Limpar Filtros</button>

            <button type="button" class="btn btn-outline-danger rounded-0 ms-2" @click="excluirSelecionados">Excluir
              Todos</button>
          </div>

        </div>


        <div class="produto-lista">
          <div class="lista-produtos" v-for="produto in produtosFiltrados" :key="produto.id">
            <Produto :referencia="produto.referencia" :image="produto.image" :descricao="produto.descricao"
              :categoria="produto.categoria" :preco="produto.preco" :status="produto.status" :id="produto.id"
              :selecionado="produtosSelecionados.includes(produto.id)" @excluirProduto="excluirProduto"
              @editarProduto="atualizarProduto" @selecionarProduto="marcarProduto" />
          </div>
        </div>

      </div>

    </div>

    <AdicionarProdutos @produtoAdicionado="carregarProdutos" />

    <EditarProdutos v-if="showModalEditar" :produto="produtoAtual" :showModal="showModalEditar"
      :categoriasUnicas="categoriasUnicas" @closeModal="closeModal" @produtoEditado="carregarProdutos" />

  </div>
</template>

<style scoped>
.ordenar {
  height: 30px;
  width: 30px;
}

.mais {
  height: 50px;
  background-color: rgb(180, 180, 180);
}

.container-fluid {
  height: 92vh;
  background-color: var(--background-secondary);
}

.lista {
  background-color: var(--background-primary);
  height: 80vh;
  width: 91vw;
}

.dropdown-menu {
  background-color: rgba(255, 255, 255, 0.2) !important;
}

.dropdown-toggle::after {
  display: none;
  /* Oculta o ícone de seta */
}

.container {
  max-width: 95% !important;
}

.filtro-texto {
  color: var(--text-color-link);
}

.preco {
  color: var(--text-color-sub);
}

.produto-lista {
  height: 35vh;
  display: flex;
  flex-direction: column;
  overflow-y: auto;
}

.lista-produtos {
  max-height: 300px;
}

.col-auto {
  flex: 0 0 auto;
}

.ordenar-item {
  position: relative;
  display: flex;
  align-items: center;
  cursor: pointer;
  white-space: nowrap;
}

.produto-referencia,
.produto-descricao,
.produto-categoria,
.produto-preco,
.produto-status {
  margin-bottom: 0;
  white-space: nowrap;
  overflow: hidden;
  text-overflow: ellipsis;
}


.produto-referencia {
  width: 120px;
}

.produto-descricao {
  width: 200px;
}

.produto-categoria {
  width: 120px;
  margin-left: 1%;
}

.produto-preco {
  width: 60px;
  margin-left: .2%;
}

.produto-status {
  margin-right: -180px;
}

.limpar_filtro {
  width: 280px;
}

.ordem {
}

@media (max-width: 768px) {

  .container {
    max-width: 100% !important;
  }

  .produto-card .row,
  .ordem.row {
    flex-direction: column;

  }

  .produto-imagem {
    max-width: 75px;

  }
}
</style>
