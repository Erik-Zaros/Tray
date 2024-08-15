<template>
  <div>
    <h1>Welcome to the Platform</h1>
    <button @click="navigateToLogin">Login</button>
  </div>
</template>

<script setup>
import { useRouter } from 'vue-router';

const router = useRouter();

const navigateToLogin = () => {
  router.push('/login');
};
</script>



