<script setup>
import { ref, watch, onMounted } from 'vue';
import { atualizarProduto as atualizarProdutoAPI } from '../../../../services/api';

const props = defineProps({
    produto: {
        type: Object,
        required: true
    },
    showModal: Boolean,
    categoriasUnicas: {
        type: Array,
        required: true
    }
});

const produto = ref({ ...props.produto });
const emit = defineEmits(['closeModal', 'produtoEditado']);

watch(() => props.produto, (novaProduto) => {
    produto.value = { ...novaProduto };
    console.log('Produto após atualização:', produto.value); // Verifique o valor do ID aqui
}, { immediate: true });

onMounted(() => {
    const modalElement = document.getElementById('editProductModal');
    if (modalElement) {
        const modalInstance = new bootstrap.Modal(modalElement);
        if (props.showModal) {
            modalInstance.show();
        }
    }
});

watch(() => props.showModal, (newVal) => {
    const modalElement = document.getElementById('editProductModal');
    if (modalElement) {
        const modalInstance = new bootstrap.Modal(modalElement);
        if (newVal) {
            modalInstance.show();
        } else {
            modalInstance.hide();
        }
    }
});

const atualizaProduto = async () => {
    try {
        const token = localStorage.getItem('token');
        if (!token) throw new Error('Usuário não autenticado.');

        // Adicione console.log para verificar o conteúdo de produto.value
        console.log('Produto a ser atualizado:', produto.value);

        const produtoAtualizado = await atualizarProdutoAPI({
            produtoId: produto.value.id, // Certifique-se de que isso não é undefined
            referencia: produto.value.referencia,
            descricao: produto.value.descricao,
            categoria: produto.value.categoria,
            preco: produto.value.preco,
            status: produto.value.status,
            image: produto.value.image
        }, token);

        console.log('Produto atualizado com sucesso:', produtoAtualizado);

        emit('produtoEditado', produtoAtualizado);

        const modalElement = document.getElementById('editProductModal');
        const modal = bootstrap.Modal.getInstance(modalElement);
        if (modal) {
            modal.hide();
        } else {
            new bootstrap.Modal(modalElement).hide();
        }

        emit('closeModal');
    } catch (erro) {
        console.error('Erro ao atualizar produto:', erro.message);
        alert('Erro ao atualizar produto.');
    }
};
</script>

<template>
    <div v-if="showModal" class="modal fade" id="editProductModal" tabindex="-1" aria-labelledby="editProductModalLabel"
        aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="editProductModalLabel">Editar Produto</h5>
                    <button type="button" class="btn-close" @click="emit('closeModal')" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <form @submit.prevent="atualizaProduto">
                        <div class="mb-3">
                            <label for="descricaoProduto" class="form-label">Descrição</label>
                            <input type="text" id="descricaoProduto" class="form-control" v-model="produto.descricao"
                                required />
                        </div>
                        <div class="mb-3">
                            <label for="referenciaProduto" class="form-label">Referência</label>
                            <input type="text" id="referenciaProduto" class="form-control" v-model="produto.referencia"
                                required />
                        </div>
                        <div class="mb-3">
                            <label for="categoriaProduto" class="form-label">Categoria</label>
                            <select id="categoriaProduto" class="form-select" v-model="produto.categoria" required>
                                <option value="">Selecione...</option>
                                <option v-for="categoria in categoriasUnicas" :key="categoria" :value="categoria">
                                    {{ categoria }}
                                </option>
                            </select>
                        </div>
                        <div class="mb-3">
                            <label for="precoProduto" class="form-label">Preço</label>
                            <input type="number" id="precoProduto" class="form-control" v-model.number="produto.preco"
                                required step="0.01" />
                        </div>
                        <div class="mb-3">
                            <label for="imagemProduto" class="form-label">Imagem</label>
                            <input type="text" id="imagemProduto" class="form-control" v-model="produto.image" />
                        </div>
                        <div class="mb-3">
                            <label for="statusProduto" class="form-label">Status</label>
                            <select id="statusProduto" class="form-select" v-model="produto.status">
                                <option :value="true">Ativo</option>
                                <option :value="false">Inativo</option>
                            </select>
                        </div>
                        <button type="submit" class="btn btn-primary">Salvar</button>
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
