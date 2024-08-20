<script setup>
</script>

<template>

    <div class="container-fluid p-0">
        <div class="mais d-flex align-items-center justify-content-end">
            <button class="btn">
                <span class="texto"><i class="fa-solid fa-circle-info"></i> Mais sobre <strong>nova Lista de
                        produtos</strong></span>
            </button>
        </div>

        <div class="produtos px-5 py-3 d-flex align-items-center justify-content-between">
            <h4 class="edit fw-bold">Produtos</h4>
            <div class="editar">
                <a href="" class="options text-decoration-none">
                    <i class="fa-solid fa-ellipsis-vertical me-2"></i> Mais Opções
                </a>
                <button class="btn btn-primary py-2 px-3 ms-3 rounded-0">Adicionar Produto</button>
            </div>
        </div>

        <div class="lista shadow-sm rounded-2 m-auto"></div>

    </div>
</template>

<style scoped>
.mais {
    height: 50px;
    background-color: rgb(180, 180, 180);
}

.container-fluid {
    background-color: var(--background-secondary);
}

.lista {
    background-color: var(--background-primary);
    height: 75vh;
    width: 91vw;
}

</style>