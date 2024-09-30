<template>
  <div class="container-fluid p-4">
    <h2 class="text-center fs-1 mb-3">Loja de Templates</h2>
    <div class="products-container">
      <div class="row">
        <TemplateCard v-for="(product, index) in products" :key="product.id" :productId="product.id"
          :productName="product.name"
          :isSelected="!!(selectedProduct && selectedProduct.id === product.id) || (product.isSelected === true)"
          @selectProduct="selectProduct" :themeIndex="index % 6" />
      </div>

      <div class="container-seletor card d-flex align-items-center justify-content-center p-2 pt-3 rounded-4">
        <h1>Painel Admin</h1>
        <div class="seletor">
          <label class="pe-2 fs-5" for="color">Selecione a cor: </label>
          <input class="p-0 rounded-4" id="color" type="color" v-model="selectedColor" />
        </div>

        <div class="cor-selecionada">
          <p class="fs-5">Cor selecionada: <strong>{{ selectedColor }}</strong></p>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { defineComponent, ref, onMounted, watch } from 'vue';
import TemplateCard from './components/Template/TemplateCard.vue';

export default defineComponent({
  name: 'ProductGrid',
  components: {
    TemplateCard,
  },
  setup() {
    const products = [
      { id: 1, name: 'Tema A' },
      { id: 2, name: 'Tema B' },
      { id: 3, name: 'Tema C' },
      { id: 4, name: 'Tema D' },
      { id: 5, name: 'Tema E' },
      { id: 6, name: 'Tema F' },
    ];

    const selectedProduct = ref(getSelectedProduct());
    const selectedColor = ref('#424242'); 

    function selectProduct(product) {
      selectedProduct.value = product;
      saveSelectedProduct();
    }

    function saveSelectedProduct() {
      localStorage.setItem('selectedProduct', JSON.stringify(selectedProduct.value));
    }

    function getSelectedProduct() {
      const savedProduct = localStorage.getItem('selectedProduct');
      return savedProduct ? JSON.parse(savedProduct) : null;
    }

    const atualizarCorNavbar = (cor) => {
      document.documentElement.style.setProperty('--navbar-color', cor);
      localStorage.setItem('navbarColor', cor);
    };

    onMounted(() => {
      const storedColor = localStorage.getItem('navbarColor');
      selectedColor.value = storedColor || '#424242';
      atualizarCorNavbar(selectedColor.value);
    });

    watch(selectedColor, (novaCor) => {
      atualizarCorNavbar(novaCor);
    });

    return {
      products,
      selectedProduct,
      selectProduct,
      selectedColor,
    };
  },
});

</script>

<style scoped></style>