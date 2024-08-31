<script setup>
import Excluir from './Excluir.vue';
import { defineEmits } from 'vue';

const produto = defineProps({
  image: String,
  referencia: String,
  descricao: String,
  categoria: String,
  preco: Number,
  status: Boolean,
  id: Number,
  usuario: Object,
  selecionado: Boolean
});

const emit = defineEmits(['editarProduto', 'excluirProduto', 'selecionarProduto']);

const emitirEditar = () => {
  emit('editarProduto', {
    id: produto.id,
    referencia: produto.referencia,
    descricao: produto.descricao,
    categoria: produto.categoria,
    preco: produto.preco,
    status: produto.status,
    image: produto.image,
    usuario: produto.usuario
  });
};

const mostrarConfirmacaoExclusao = (id) => {
  const modal = new bootstrap.Modal(document.getElementById('modalConfirmacaoExclusao'));
  modal.show();
};

const emitirExcluir = () => {
  emit('excluirProduto', produto.id);
};

// Emitir evento de seleção ao clicar no checkbox
const alterarSelecao = (event) => {
  emit('selecionarProduto', {
    id: produto.id,
    selecionado: event.target.checked
  });
};
</script>

<template>
  <div class="produto-card px-5 mx-4 p-3">
    <div class="row align-items-center">
      <!-- Ajustando o layout dos produtos -->
      <div class="col-auto me-4">
        <input class="form-check-input" type="checkbox" :checked="selecionado" @change="alterarSelecao">
      </div>
      <div class="col-auto me-4">
        <p class="produto-referencia">{{ referencia }}</p>
      </div>
      <div class="col-auto me-4">
        <img class="produto-imagem" :src="image || '/noimg.jpeg'" alt="Imagem do Produto">
      </div>
      <div class="col me-auto">
        <p class="produto-descricao">{{ descricao }}</p>
      </div>
      <div class="col">
        <p class="produto-categoria">{{ categoria }}</p>
      </div>
      <div class="col">
        <p class="produto-preco">R$ {{ preco.toFixed(2) }}</p>
      </div>
      <div class="col">
        <button :class="['produto-status btn', status ? 'btn-success' : 'btn-danger']">
          {{ status ? 'Ativo' : 'Inativo' }}
        </button>
      </div>
      <div class="col-1 alterar d-flex justify-content-between">
        <div class="editar">
          <i class="fa-solid fa-pen-to-square fs-3" @click="emitirEditar"></i>
        </div>
        <div class="excluir">
          <!-- Corrigido: adicionada a aspa de fechamento no lugar certo -->
          <i class="fa-solid fa-trash-can fs-3" @click="mostrarConfirmacaoExclusao(produto.id)"></i>
        </div>
        <!-- Modal de exclusão -->
        <Excluir @confirmarExclusao="emitirExcluir" />
      </div>
    </div>
  </div>
</template>

<style scoped>
.produto-card {
  color: #333;
  border-top: 2px solid rgba(140, 140, 140, .3);
}

.produto-imagem {
  width: 100px;
  height: 100px;
  object-fit: cover;
  border-radius: 8px;
}

.fa-solid:hover {
  cursor: pointer;
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
  width: 100px;
}

.produto-descricao {
  width: 200px;
}

.produto-categoria {
  width: 80px;
}

.produto-preco {
  width: 120px;
}

.produto-status {
  width: 100px;
}

.alterar {
  width: 100px;
}

@media (max-width: 768px) {
  .produto-card .row {
    flex-direction: column;
  }

  .produto-imagem {
    max-width: 75px;
  }
}
</style>
