<script>
export default {
    props: {
        referencia: {
            type: String,
            required: true,
        },
        image: {
            type: String,
            required: true,
        },
        descricao: {
            type: String,
            required: true,
        },
        categoria: {
            type: String,
            required: true,
        },
        preco: {
            type: Number,
            required: true,
        },
    },
}
</script>

<template>
    <div class="card shadow rounded-4 p-4">
        <img :src="image" class="card-img-top rounded-3" alt="Imagem do Produto" />
        <div class="card-body">
            <p class="card-text position-absolute bg-success text-light top-0 start-0 mt-5 p-2 px-4 rounded-end-4">{{ categoria }}</p>
            <h4 class="card-title">{{ descricao }}</h4>

            <div class="preco">
                <span class="preco-old text-secondary text-decoration-line-through">{{ (preco + 40).toFixed(2) }}</span>
            </div>

            <h4 class="card-price mt-2 d-flex">
                R$ {{ preco }} no Pix
            </h4>
            <span>Ou 3x R$ {{ ((preco + 10) / 3).toFixed(2) }}</span>
        </div>
    </div>
</template>



<style scoped>
.card {
    height: 420px;
}


.card-img-top {
    object-fit: cover;
    /* Para garantir que a imagem se encaixe bem no card */
    height: 200px;
    /* Ajuste a altura conforme necessário */
}
</style>