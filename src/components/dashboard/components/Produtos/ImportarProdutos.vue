<script setup>
import { ref, computed } from 'vue';
import { adicionarProduto } from '../../../../services/api'; 

const modalAberto = ref(false);
const dadosCSV = ref([]);
const dadosHeaderCSV = ref(["referência", "descrição", "categoria", "preço", "status", "imagem"]);
const mostrarTabelaCSV = ref(false);
const mensagemAlerta = ref(null);

function abreModal() {
    modalAberto.value = true;
}

function fechaModal() {
    mostrarTabelaCSV.value = false;
    modalAberto.value = false;
    dadosCSV.value = ''
}

function arquivoSelecionados(event) {
    const file = event.target.files[0];
    if (!file) return;

    const reader = new FileReader();

    reader.onload = function (event) {
        const csv = event.target.result;
        const parsedData = analisaCSV(csv);
        dadosCSV.value = parsedData;

        console.log('Dados lidos do CSV:', dadosCSV.value);
        if (dadosCSV.value.length === 0) {
            console.warn('Nenhum dado foi carregado do CSV.');
        }
    };

    reader.readAsText(file);
}

function analisaCSV(csv) {
    const lines = csv.split('\n');
    const data = [];

    for (let i = 1; i < lines.length; i++) {
        const line = lines[i].trim();
        if (!line) continue;

        const values = line.split(',');
        const obj = {
            referencia: values[0] ? values[0].trim() : '',
            descricao: values[1] ? values[1].trim() : '',
            categoria: values[2] ? values[2].trim() : '',
            preco: values[3] ? parseFloat(values[3].trim()) : 0,
            status: values[4] ? values[4].trim().toLowerCase() === 'true' : false,
            image: values[5] ? values[5].trim() : ''
        };

        data.push(obj);
    }

    return data.length ? data : [];
}

function acionaArquivo(index) {
    document.getElementById('fileInput' + index).click();
}

function imagemSelecionada(event, index) {
    const file = event.target.files[0];
    if (!file) return;

    const reader = new FileReader();
    reader.onload = function (event) {
        dadosCSV.value[index].image = event.target.result;
        console.log('Imagem lida para o produto:', index, dadosCSV.value[index].image);
    };
    reader.readAsDataURL(file);
}

function mostraTabela() {
    mostrarTabelaCSV.value = true;
}

async function salvaProdutosImportados() {
    mensagemAlerta.value = null;

    const usuarioId = localStorage.getItem('usuarioId'); // Obtendo o ID do usuário autenticado
    if (!usuarioId) {
        mensagemAlerta.value = 'Usuário não autenticado.';
        return;
    }

    for (let produto of dadosCSV.value) {

        if (!produto.referencia || !produto.descricao || !produto.categoria) {
            mensagemAlerta.value = 'Dados incompletos em um ou mais produtos. Verifique e tente novamente.';
            return;
        }

        produto.usuarioId = usuarioId; 

        try {
            // Chama a função que adiciona o produto à API
            const token = localStorage.getItem('token');
            if (!token) throw new Error('Usuário não autenticado.');
            await adicionarProduto(produto, token);
        } catch (error) {
            console.error('Erro ao salvar produto:', produto, error);
            mensagemAlerta.value = `Erro ao salvar alguns produtos. Verifique os dados e tente novamente.`;
            return;
        }
    }

    mensagemAlerta.value = "Produtos importados salvos com sucesso!";
    mostrarTabelaCSV.value = false;
    fechaModal();
    window.location.reload();
}

const classeAlerta = computed(() => {
    return mensagemAlerta.value && mensagemAlerta.value.includes('sucesso') ? 'alert success' : 'alert error';
});
</script>

<template>
    <div>
        <!-- Botão para abrir o modal -->
        <button class="btn btn-secondary py-2 px-3 ms-3 rounded-0" @click="abreModal">Importar Produtos</button>

        <!-- Modal -->
        <div v-if="modalAberto" class="modal fade show" style="display: block;" tabindex="-1">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Importar Produtos</h5>
                        <button type="button" class="btn-close" @click="fechaModal"></button>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col">
                                <input class="form-control m-2" type="file" id="csvFileInput" accept=".csv"
                                    @change="arquivoSelecionados">
                            </div>
                            <div class="col-auto">
                                <button class="btn btn-success m-2" @click="mostraTabela"
                                    v-if="dadosCSV && dadosCSV.length">Mostrar Produtos</button>
                                <button class="btn btn-primary m-2" @click="salvaProdutosImportados"
                                    v-if="dadosCSV && dadosCSV.length">Salvar Produtos</button>
                            </div>
                        </div>

                        <!-- Alertas -->
                        <div v-if="mensagemAlerta" class="alert" :class="classeAlerta">
                            {{ mensagemAlerta }}
                        </div>

                        <!-- Tabela de produtos -->
                        <div class="row m-3" v-if="mostrarTabelaCSV">
                            <div class="col-12">
                                <div class="table-container">
                                    <table class="table">
                                        <thead>
                                            <tr>
                                                <th v-for="header in dadosHeaderCSV" :key="header">{{ header }}</th>
                                                <th>Arquivo</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr v-for="(row, index) in dadosCSV" :key="index">
                                                <td v-for="(value, key) in row" :key="key">
                                                    <input class="form-control" v-model="row[key]">
                                                </td>
                                                <td>
                                                    <button class="btn btn-secondary"
                                                        @click="acionaArquivo(index)">+</button>
                                                    <input type="file" :id="'fileInput' + index"
                                                        @change="imagemSelecionada($event, index)" accept="image/*"
                                                        style="display: none;">
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer d-flex justify-content-between">
                        <a class="text-decoration-none" href="/importa-produtos.csv" download="exemplo-importação">
                            Modelo de Importação <i class="fa-solid fa-file-arrow-down"></i>
                        </a>
                        <button type="button" class="btn btn-secondary" @click="fechaModal">Fechar</button>
                    </div>
                </div>
            </div>
        </div>

        <!-- Background overlay -->
        <div v-if="modalAberto" class="modal-backdrop fade show"></div>
    </div>
</template>

<style scoped>
.modal {
    margin-top: 12vh;
}

.modal-header {
    background-color: var(--background-primary);
}

th {
    text-align: center;
    background-color: #bbb;
    border: 1px black solid;
}

tbody {
    text-align: center;
    border: 1px black solid;
}

td {
    border-left: 1px black solid;
    border-bottom: transparent;
}

.table-container {
    max-height: 450px;
    width: 100%;
    overflow-y: auto;
}

.alert {
    padding: 1rem;
    margin: 1rem 0;
}

.alert.success {
    color: green;
}

.alert.error {
    color: red;
}

.modal-backdrop {
    position: fixed;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    background-color: rgba(0, 0, 0, 0.5);
    z-index: 1040;
}
</style>
