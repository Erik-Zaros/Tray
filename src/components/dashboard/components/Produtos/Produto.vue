<template>
  <div class="produto-card shadow-sm rounded-2 p-3 mb-3">
    <div class="row">
      <div class="col-md-4">
        <img :src="produto.image" alt="Imagem do produto" class="img-fluid rounded">
      </div>
      <div class="col-md-8">
        <h5 class="produto-nome">{{ produto.descricao }}</h5>
        <p class="produto-categoria">Categoria: {{ produto.categoria }}</p>
        <p class="produto-preco">Preço: R$ {{ produto.preco.toFixed(2) }}</p>
        <p class="produto-status">Status: {{ produto.status ? 'Ativo' : 'Inativo' }}</p>
      </div>
    </div>
  </div>
</template>

<script setup>
import { defineProps } from 'vue';

const props = defineProps({
  produto: {
    type: Object,
    required: true
  }
});
</script>

<style scoped>
.produto-card {
  background-color: var(--background-primary);
}

.produto-nome {
  font-size: 1.25rem;
  font-weight: bold;
}

.produto-categoria,
.produto-preco,
.produto-status {
  font-size: 1rem;
}

img {
  max-width: 100%;
  height: auto;
}
</style>
