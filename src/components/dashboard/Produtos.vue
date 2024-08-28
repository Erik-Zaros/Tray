<script setup>
import { ref, onMounted, computed } from 'vue';
import { useRouter } from 'vue-router';
import AdicionarProdutos from './components/Produtos/AdicionarProdutos.vue'; // Importar o modal de cadastro
import ImportarProdutos from './components/Produtos/ImportarProdutos.vue'; // Importar o modal de cadastro
import Produto from './components/Produtos/Produto.vue'; // Importar o modal de cadastros
import { listarProdutos, excluirProduto as apiExcluirProduto } from '../../services/api'; // Certifique-se de ajustar o caminho conforme necessário

const produtos = ref([]);
const router = useRouter();
const filtro = ref({
  codigoReferencia: '',
  nomeProduto: '',
  categorias: '',
  precoDe: '',
  precoAte: ''
});
const ordenacao = ref({ campo: '', direcao: '' });
const categoriasUnicas = ref([]); // Constante para armazenar categorias únicas

const carregarProdutos = async () => {
  try {
    const resposta = await listarProdutos();
    produtos.value = resposta.produtos || []; // Acessa o array 'produtos' do JSON retornado
    // Extrai as categorias únicas
    const categorias = produtos.value.map(produto => produto.categoria);
    categoriasUnicas.value = [...new Set(categorias)];
  } catch (erro) {
    console.error('Erro ao carregar produtos:', erro.message);
    alert('Erro ao carregar produtos.');
  }
};

const excluirProduto = async (produtoId) => {
  try {
    await apiExcluirProduto(produtoId);
    produtos.value = produtos.value.filter(produto => produto.id !== produtoId);
    alert('Produto excluído com sucesso.');
  } catch (erro) {
    console.error('Erro ao excluir produto:', erro.message);
    alert('Erro ao excluir produto.');
  }
};

const aplicarFiltro = () => {
  // Recarregar os produtos para garantir que os filtros sejam aplicados na lista atualizada
  carregarProdutos();
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

      return codigoOuReferenciaMatch && nomeProdutoMatch && categoriaMatch && precoMatch ;
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

const ordenar = (campo) => {
  if (ordenacao.value.campo === campo) {
    ordenacao.value.direcao = ordenacao.value.direcao === 'asc' ? 'desc' : 'asc';
  } else {
    ordenacao.value.campo = campo;
    ordenacao.value.direcao = 'asc';
  }
};

const limparFiltro = () => {
  filtro.value = {
    codigoReferencia: '',
    nomeProduto: '',
    categorias: '',
    precoDe: '',
    precoAte: '',
  };
};

// Carregar produtos ao montar o componente
onMounted(() => {
  carregarProdutos();
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

        <ImportarProdutos />
        <button class="btn btn-primary py-2 px-3 ms-3 rounded-0" data-bs-toggle="modal" data-bs-target="#productModal">
          Adicionar Produto <!-- Ao clicar, deve abrir o modal de produtos -->
        </button>
      </div>
    </div>

    <div class="lista shadow-sm rounded-2 m-auto">
      <div class="container pt-4">
        <form @submit.prevent="aplicarFiltro">
          <h4 class="filtro-texto pb-3">Filtrar Produtos</h4>
          <div class="row g-3 border-bottom border-top pb-4">
            <!-- Código ou Referência -->
            <div class="col-md-6">
              <label for="codigoReferencia" class="form-label">Código ou Referência</label>
              <input v-model="filtro.codigoReferencia" type="text" class="form-control" id="codigoReferencia"
                placeholder="Digite o código ou referência">
            </div>

            <!-- Nome do Produto -->
            <div class="col-md-6">
              <label for="nomeProduto" class="form-label">Nome do Produto</label>
              <input v-model="filtro.nomeProduto" type="text" class="form-control" id="nomeProduto"
                placeholder="Digite o nome do produto">
            </div>

            <!-- Categorias -->
            <div class="col-md-6">
              <label for="categorias" class="form-label">Categorias</label>
              <select v-model="filtro.categorias" id="categorias" class="form-select">
                <option value="">Selecione...</option>
                <option v-for="categoria in categoriasUnicas" :key="categoria" :value="categoria">
                  {{ categoria }}
                </option>
              </select>
            </div>


            <!-- Faixa de Preço -->
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
          <!-- Botão de Filtro -->
          <div class="col-12 d-flex justify-content-end pt-3">
            <button type="button" class="btn btn-outline-dark rounded-0" @click="limparFiltro"><i
                class="fa-solid text-secondary fa-circle-info"></i> Limpar Filtros</button>
            <button type="submit" class="btn btn-primary rounded-0 ms-3">Filtrar</button>
          </div>
        </form>
      </div>

      <div class="pt-4">
        <div class="ordem row align-items-center mx-5 p-3 px-3">
          <!-- Ajuste o layout do cabeçalho para corresponder ao layout dos produtos -->
          <div class="col-auto me-4 mb-3 ordenar-item">
            <input class="form-check-input" type="checkbox">
          </div>
          <div class="col-auto me-5 ordenar-item produto-referencia" @click="ordenar('referencia')">
            <p class="ordenar-texto">
              Referência
            <div class="ordenar bg-warning d-flex">
              <i
                :class="{ 'fa-solid fa-caret-up': ordenacao.campo === 'referencia' && ordenacao.direcao === 'asc', 'fa-solid fa-caret-up text-dark': ordenacao.campo === 'referencia' && ordenacao.direcao === 'desc' }"></i>
              <i
                :class="{ 'fa-solid fa-caret-down': ordenacao.campo === 'referencia' && ordenacao.direcao === 'desc', 'fa-solid fa-caret-down text-dark': ordenacao.campo === 'referencia' && ordenacao.direcao === 'asc' }"></i>
            </div>
            </p>
          </div>
          <div class="col-auto ordenar-item produto-imagem">
            <p class="ordenar-texto">
              Imagem
              <i class="fa-solid fa-sort ms-2"></i>
            </p>
          </div>
          <div class="col ordenar-item produto-descricao">
            <p class="ordenar-texto">
              Descriçao
              <i class="fa-solid fa-sort ms-2"></i>
            </p>
          </div>
          <div class="col ordenar-item produto-categoria">
            <p class="ordenar-texto">
              Categoria
              <i class="fa-solid fa-sort ms-2"></i>
            </p>
          </div>
          <div class="col ordenar-item produto-preco">
            <p class="ordenar-texto">
              Preço
              <i class="fa-solid fa-sort ms-2"></i>
            </p>
          </div>
          <div class="col ordenar-item produto-status">
            <p class="ordenar-texto">
              Status
              <i class="fa-solid fa-sort ms-2"></i>
            </p>
          </div>
          <div class="ordenar-item produto-alterar">
            <p class="ordenar-texto">
            </p>
          </div>
        </div>

        <!-- Renderização dos produtos -->
        <div class="produto-lista">
          <div class="lista-produtos" v-for="produto in produtosFiltrados" :key="produto.id">
            <Produto :referencia="produto.referencia" :image="produto.image" :descricao="produto.descricao"
              :categoria="produto.categoria" :preco="produto.preco" :status="produto.status"
              @excluirProduto="excluirProduto(produto.id)" />
          </div>
        </div>
      </div>

    </div>

    <!-- Modal de Cadastro de Produto -->
    <AdicionarProdutos />
  </div>
</template>

<style scoped>
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
}

.produto-preco {
  width: 80px;
}

.produto-status {
  width: 100px;
}

.produto-alterar {
  width: 0px;
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
