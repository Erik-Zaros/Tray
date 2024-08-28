<script setup>
import { ref } from 'vue';
import { adicionarProduto as adicionarProdutoAPI } from '../../../../services/api';

const produto = ref({
  referencia: '',
  descricao: '',
  categoria: '',
  preco: 0,
  status: false,
  image: '',
  usuarioId: 0 // Adicionei o usuárioId
});

async function adicionaProduto() {
  try {
    const token = localStorage.getItem('token');
    if (!token) throw new Error('Usuário não autenticado.');
    
    // Adiciona o ID do usuário ao produto
    produto.value.usuarioId = 1; // Ajuste isso para o ID do usuário autenticado
    
    const novoProduto = await adicionarProdutoAPI(produto.value, token);
    console.log('Produto cadastrado com sucesso:', novoProduto);
    
    produto.value = {
      referencia: '',
      descricao: '',
      categoria: '',
      preco: 0,
      status: false,
      image: '',
      usuarioId: 0
    };
    
    const modal = bootstrap.Modal.getInstance(document.getElementById('productModal'));
    modal.hide();

    alert('Produto cadastrado com sucesso!');
    window.location.reload();
  } catch (erro) {
    console.error('Erro ao cadastrar produto:', erro.message);
    alert('Erro ao cadastrar produto.');
  }
}
</script>

<template>
  <div class="modal fade" id="productModal" tabindex="-1" aria-labelledby="productModalLabel" aria-hidden="true">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title" id="productModalLabel">Cadastrar Produto</h5>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
          <form @submit.prevent="adicionaProduto">
            <div class="mb-3">
              <label for="referencia" class="form-label">Referência:</label>
              <input type="text" class="form-control" id="referencia" v-model="produto.referencia" required>
            </div>
            <div class="mb-3">
              <label for="descricao" class="form-label">Descrição:</label>
              <input type="text" class="form-control" id="descricao" v-model="produto.descricao" required>
            </div>
            <div class="mb-3">
              <label for="categoria" class="form-label">Categoria:</label>
              <input type="text" class="form-control" id="categoria" v-model="produto.categoria" required>
            </div>
            <div class="mb-3">
              <label for="preco" class="form-label">Preço:</label>
              <input type="number" class="form-control" id="preco" v-model.number="produto.preco" step="0.01" required>
            </div>
            <div class="mb-3 form-check">
              <input type="checkbox" class="form-check-input" id="status" v-model="produto.status">
              <label class="form-check-label" for="status">Ativo</label>
            </div>
            <div class="mb-3">
              <label for="image" class="form-label">Imagem:</label>
              <input type="text" class="form-control" id="image" v-model="produto.image">
            </div>
            <button type="submit" class="btn btn-primary">Cadastrar Produto</button>
          </form>
        </div>
      </div>
    </div>
  </div>
</template>

<style scoped>
.modal {
  margin-top: 15vh;
}
</style>
