<template>
    <div class="container pt-4">
        <form>
            <h4 class="filtro-texto pb-3">Filtrar Produtos</h4>
            <div class="row g-3 border-bottom border-top pb-4">
                <!-- Código ou Referência -->
                <div class="col-md-4">
                    <label for="codigoReferencia" class="form-label">Código ou Referência</label>
                    <input type="text" class="form-control" id="codigoReferencia"
                        placeholder="Digite o código ou referência">
                </div>

                <!-- Nome do Produto -->
                <div class="col-md-4">
                    <label for="nomeProduto" class="form-label">Nome do Produto</label>
                    <input type="text" class="form-control" id="nomeProduto" placeholder="Digite o nome do produto">
                </div>

                <!-- Status -->
                <div class="col-md-4">
                    <label for="status" class="form-label">Status</label>
                    <select id="status" class="form-select">
                        <option value="">Selecione...</option>
                        <option value="ativo">Ativo</option>
                        <option value="inativo">Inativo</option>
                    </select>
                </div>

                <!-- Categorias -->
                <div class="col-md-4">
                    <label for="categorias" class="form-label">Categorias</label>
                    <select id="categorias" class="form-select">
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
                        <input type="number" class="form-control rounded" id="precoDe" placeholder="0.00">
                        <span class="preco m-auto p-2 fw-bold">Até R$</span>
                        <input type="number" class="form-control rounded" id="precoAte" placeholder="0.00">
                    </div>
                </div>

                <!-- Estoque -->
                <div class="col-md-4">
                    <label for="estoque" class="form-label">Estoque</label>
                    <select id="estoque" class="form-select">
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
                <button type="submit" class="btn btn-outline-dark rounded-0"><i
                        class="fa-solid text-secondary fa-circle-info"></i></button>
                <button type="submit" class="btn btn-outline-dark rounded-0 ms-3">Limpar Filtrar</button>
                <button type="submit" class="btn btn-primary rounded-0 ms-3">Filtrar</button>
            </div>
        </form>
    </div>
</template>

<script setup>

import { ref, onMounted } from 'vue';
import { useRouter } from 'vue-router';

const user = ref({});
const router = useRouter();

onMounted(() => {
    const userData = JSON.parse(localStorage.getItem('user'));
    if (userData) {
        user.value = userData;
    } else {
        router.push('/login');
    }
});

</script>

<style scoped>
</style>