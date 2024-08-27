<script setup>
import { ref, onMounted } from 'vue';
import { useRouter } from 'vue-router';
import AdicionarProdutos from './components/Produtos/AdicionarProdutos.vue'; // Importar o modal de cadastro
import Produto from './components/Produtos/Produto.vue'; // Importar o modal de cadastro
import { listarProdutos } from '../../services/api'; // Certifique-se de ajustar o caminho conforme necessário

const produtos = ref([]);
const filtro = ref({
  codigoReferencia: '',
  nomeProduto: '',
  status: '',
  categorias: '',
  precoDe: '',
  precoAte: '',
  estoque: ''
});
const router = useRouter();

const carregarProdutos = async () => {
  try {
    const resposta = await listarProdutos();
    produtos.value = resposta.produtos || []; // Acessa o array 'produtos' do JSON retornado
    console.log(produtos.value);
  } catch (erro) {
    console.error('Erro ao carregar produtos:', erro.message);
    alert('Erro ao carregar produtos.');
  }
};

const aplicarFiltro = async () => {
  try {
    // Implementar a lógica para filtrar produtos com base no estado `filtro`
    // Atualize a função `listarProdutos` para aceitar parâmetros de filtro se necessário
    await carregarProdutos();
  } catch (erro) {
    console.error('Erro ao aplicar filtros:', erro.message);
    alert('Erro ao aplicar filtros.');
  }
};

const limparFiltro = () => {
  filtro.value = {
    codigoReferencia: '',
    nomeProduto: '',
    status: '',
    categorias: '',
    precoDe: '',
    precoAte: '',
    estoque: ''
  };
  aplicarFiltro();
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
      <div class="editar">
        <a href="" class="options text-decoration-none">
          <i class="fa-solid fa-ellipsis-vertical me-2"></i> Mais Opções
        </a>
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
            <div class="col-md-4">
              <label for="codigoReferencia" class="form-label">Código ou Referência</label>
              <input v-model="filtro.codigoReferencia" type="text" class="form-control" id="codigoReferencia" placeholder="Digite o código ou referência">
            </div>

            <!-- Nome do Produto -->
            <div class="col-md-4">
              <label for="nomeProduto" class="form-label">Nome do Produto</label>
              <input v-model="filtro.nomeProduto" type="text" class="form-control" id="nomeProduto" placeholder="Digite o nome do produto">
            </div>

            <!-- Status -->
            <div class="col-md-4">
              <label for="status" class="form-label">Status</label>
              <select v-model="filtro.status" id="status" class="form-select">
                <option value="">Selecione...</option>
                <option value="ativo">Ativo</option>
                <option value="inativo">Inativo</option>
              </select>
            </div>

            <!-- Categorias -->
            <div class="col-md-4">
              <label for="categorias" class="form-label">Categorias</label>
              <select v-model="filtro.categorias" id="categorias" class="form-select">
                <option value="">Selecione...</option>
                <option value="eletronicos">Eletrônicos</option>
                <option value="utensilios">Utensílios</option>
                <!-- Adicione mais categorias conforme necessário -->
              </select>
            </div>

            <!-- Faixa de Preço -->
            <div class="col-md-4">
              <label for="precoDe" class="form-label">Faixa de Preço</label>
              <div class="input-group">
                <span class="preco m-auto p-2 fw-bold">De R$</span>
                <input v-model="filtro.precoDe" type="number" class="form-control rounded" id="precoDe" placeholder="0.00">
                <span class="preco m-auto p-2 fw-bold">Até R$</span>
                <input v-model="filtro.precoAte" type="number" class="form-control rounded" id="precoAte" placeholder="0.00">
              </div>
            </div>

            <!-- Estoque -->
            <div class="col-md-4">
              <label for="estoque" class="form-label">Estoque</label>
              <select v-model="filtro.estoque" id="estoque" class="form-select">
                <option value="">Selecione...</option>
                <option value="todos">Todos</option>
                <option value="maiorQueZero">Maior que 0</option>
                <option value="igualAZero">Igual a 0</option>
                <option value="menorQueZero">Menor que 0</option>
              </select>
            </div>
          </div>
          <!-- Botão de Filtro -->
          <div class="col-12 d-flex justify-content-end pt-3">
            <button type="button" class="btn btn-outline-dark rounded-0" @click="limparFiltro"><i class="fa-solid text-secondary fa-circle-info"></i> Limpar Filtros</button>
            <button type="submit" class="btn btn-primary rounded-0 ms-3">Filtrar</button>
          </div>
        </form>
      </div>

      <div class="produtos-lista pt-4">
        <div>
          <ul>
            <li v-for="produto in produtos" :key="produto.id">
              ID: {{ produto.id }}, Referência: {{ produto.referencia }}, Descrição: {{ produto.descricao }}, Categoria:
              {{ produto.categoria }}, Preço: {{ produto.preco }}, Status: {{ produto.status }}
            </li>
          </ul>
        </div>
      </div>
    </div>

    <!-- Modal de Cadastro de Produto -->
    <AdicionarProdutos />
  </div>
</template>

<style scoped>
/* Suas estilizações existentes */

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

/* Filtro */
.container {
  max-width: 95% !important;
}

.filtro-texto {
  color: var(--text-color-link);
}

.preco {
  color: var(--text-color-sub);
}

@media (max-width: 768px) {
  .container {
    max-width: 100% !important;
  }
}
</style>
