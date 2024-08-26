<script setup>
import { ref } from 'vue';

const emit = defineEmits(['next']);

const email = ref('');

const validateEmail = () => {
  if (email.value) {
    sessionStorage.setItem('email', email.value);
    emit('next');
  } else {
    alert('Insira um email valido');
  }
};
</script>

<template>
  <div class="input-group px-4 px-md-5 row">
    <label class="text-start my-2">E-mail  <span class="text-danger">*</span></label>
    <input class="form-control rounded-5 p-3 mb-3" type="email" v-model="email" placeholder="E-mail " />
    <button class="btn btn-success col-12 rounded-5 fs-4 fw-bold" @click="validateEmail">Continuar</button>
  </div>
</template>


