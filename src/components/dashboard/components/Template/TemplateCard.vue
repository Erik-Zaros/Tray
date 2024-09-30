<template>
    <div class="col-md-4 mb-4">
        <div class="product-card bg-light p-3 rounded-4 border text-center">
            <h6>{{ productName }}</h6>
            <div class="image-container d-flex flex-column mb-4" :style="{ backgroundColor: lightColors[themeIndex] }">
                <header class="header w-100" :style="{ backgroundColor: strongColors[themeIndex] }">Cabeçalho</header>
                <div class="container-image d-flex" :style="{ backgroundColor: lightColors[themeIndex] }">
                    <p class="frase-loja m-auto">Frase Loja</p>
                </div>
                <div class="nav justify-content-center" :style="{ backgroundColor: intermediateColors[themeIndex] }">
                    <li class="px-2">Item</li>
                    <li class="px-2">Item</li>
                    <li class="px-2">Item</li>
                </div>
                <div class="produtos d-flex justify-content-center p-2"
                    :style="{ backgroundColor: lightColors[themeIndex] }">
                    <div class="card px-4 py-4 mx-2 my-1">.</div>
                    <div class="card px-4 py-4 mx-2 my-1">.</div>
                    <div class="card px-4 py-4 mx-2 my-1">.</div>
                    <div class="card px-4 py-4 mx-2 my-1">.</div>
                </div>
            </div>
            <div class="infos text-center">
                <div class="form-check">
                    <label :for="'product' + productId" class="form-check-label">Selecionar</label>
                    <input type="checkbox" class="form-check-input" :id="'product' + productId" :checked="isSelected"
                        @change="toggleSelect" />
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import { defineComponent } from 'vue';

export default defineComponent({
    name: 'ProductCard',
    props: {
        productId: {
            type: Number,
            required: true,
        },
        productName: {
            type: String,
            required: true,
        },
        isSelected: {
            type: Boolean,
            required: true,
        },
        themeIndex: {
            type: Number,
            required: true,
        },
    },
    data() {
        return {
            strongColors: ['#FF5733', '#33FF57', '#3357FF', '#FF33A1', '#FFD433', '#33FFF2'],
            lightColors: ['#FFC3B0', '#B0FFC3', '#B0C3FF', '#FFC3E0', '#FFE1B0', '#B0FFFF'],
            intermediateColors: ['#FF8D1A', '#1AFF8D', '#1A8DFF', '#FF1A8D', '#FFD81A', '#1AFFFF'],
        };
    },

    methods: {
        toggleSelect() {
            this.$emit('selectProduct', {
                id: this.productId,
                name: this.productName,
                strongColor: this.strongColors[this.themeIndex],
                lightColor: this.lightColors[this.themeIndex],
                intermediateColor: this.intermediateColors[this.themeIndex],
            });
        },
    },
});
</script>

<style scoped>
.container-image {
    height: 100px;
}

.product-card {
    transition: transform 0.2s;
}

.product-card:hover {
    transform: scale(1.01);
}
</style>