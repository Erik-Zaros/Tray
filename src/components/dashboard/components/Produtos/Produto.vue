<template>
  <div class="produto-card px-5 mx-4 p-3">
    <div class="row align-items-center">
      <!-- Ajustando o layout dos produtos -->
      <div class="col-auto me-4">
        <input class="form-check-input" type="checkbox">
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
    </div>
  </div>
</template>


<script setup>
import { defineProps } from 'vue';

// Definindo as props que o componente vai receber
const props = defineProps({
  image: String,
  referencia: String,
  descricao: String,
  categoria: String,
  preco: Number,
  status: Boolean
});
</script>

<style scoped>
.produto-card {
  color: #333;
  border-top: 2px solid rgba(140, 140, 140, .3);
}


.produto-imagem {
  width: 100%;
  max-width: 100px;
  height: auto;
  object-fit: cover;
  border-radius: 8px;
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
  width: 120px;
}

.produto-preco {
  width: 80px;
}

.produto-status {
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
