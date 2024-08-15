<template>
  <div>
    <label>Email:</label>
    <input type="email" v-model="email" />
    <button @click="validateEmail">Next</button>
  </div>
</template>

<script setup>
import { ref } from 'vue';

// Define o emissor de eventos
const emit = defineEmits(['next']);

const email = ref('');

const validateEmail = () => {
  if (email.value) {
    sessionStorage.setItem('email', email.value);
    emit('next');
  } else {
    alert('Please enter a valid email');
  }
};
</script>
