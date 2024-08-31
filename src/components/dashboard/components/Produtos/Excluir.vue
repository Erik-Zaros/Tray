<script setup>
import { ref } from 'vue';

const produtoId = ref(null);
const confirmarExclusao = ref(false);

const emit = defineEmits(['confirmarExclusao']);

const mostrarModal = (id) => {
  produtoId.value = id;
  const modal = new bootstrap.Modal(document.getElementById('modalConfirmacaoExclusao'));
  modal.show();
};

const cancelarExclusao = () => {
  const modal = bootstrap.Modal.getInstance(document.getElementById('modalConfirmacaoExclusao'));
  modal.hide();
};

const confirmarExclusaoProduto = () => {
  emit('confirmarExclusao', produtoId.value);
  cancelarExclusao();
};
</script>

<template>
  <div class="modal fade" id="modalConfirmacaoExclusao" tabindex="-1" aria-labelledby="modalConfirmacaoExclusaoLabel" aria-hidden="true">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title" id="modalConfirmacaoExclusaoLabel">Confirmar Exclusão</h5>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Fechar"></button>
        </div>
        <div class="modal-body text-center">
          <p class="b-3">Você tem certeza que deseja excluir este produto? <br> <strong>Esta ação não pode ser desfeita.</strong></p>
        </div>
        <div class="modal-footer d-flex justify-content-center">
          <button type="button" class="btn btn-secondary" @click="cancelarExclusao">Cancelar</button>
          <button type="button" class="btn btn-danger" @click="confirmarExclusaoProduto">Excluir</button>
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
