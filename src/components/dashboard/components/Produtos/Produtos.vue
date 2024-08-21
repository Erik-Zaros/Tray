<template>
    <div class="container">
      <h2 class="mb-4">Lista de Produtos</h2>
      <ul class="list-group">
        <li v-for="produto in produtos" :key="produto.id" class="list-group-item">
          <div class="row">
            <div class="col-md-2">
              <img src="https://via.placeholder.com/100" class="img-thumbnail" alt="Imagem do produto">
            </div>
            <div class="col-md-10">
              <h5 class="list-group-item-heading">{{ produto.nome }}</h5>
              <p class="list-group-item-text">
                <strong>Código:</strong> {{ produto.codigo }}<br>
                <strong>Categoria:</strong> {{ produto.categoria }}<br>
                <strong>Preço:</strong> R$ {{ produto.preco.toFixed(2) }}<br>
                <strong>Estoque:</strong> {{ produto.estoque >= 0 ? produto.estoque : 'Indisponível' }}
              </p>
              <span class="badge" :class="getBadgeClass(produto.status)">
                {{ produto.status === 'ativo' ? 'Ativo' : 'Inativo' }}
              </span>
            </div>
          </div>
        </li>
      </ul>
    </div>
  </template>
  
  <script setup>
  import { defineProps } from 'vue';
  
  const props = defineProps({
    produtos: Array
  });
  
  const getBadgeClass = (status) => {
    return status === 'ativo' ? 'bg-success text-white' : 'bg-danger text-white';
  };
  </script>
  
  <style scoped>
  .list-group-item {
    border: 1px solid #ddd;
    border-radius: 8px;
    padding: 15px;
    margin-bottom: 10px;
  }
  
  .img-thumbnail {
    width: 100%;
    height: auto;
  }
  
  .list-group-item-heading {
    font-size: 1.25rem;
  }
  
  .list-group-item-text {
    font-size: 1rem;
  }
  
  .badge {
    font-size: 0.875rem;
  }
  </style>
  