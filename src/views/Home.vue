<script setup>
import { useRouter } from 'vue-router';
import Header from '../components/home/Header.vue'

const router = useRouter();

const navigateToLogin = () => {
  router.push('/login');
};
</script>

<template>
    <Header />
    <h1>Welcome to the Platform</h1>
    <button @click="navigateToLogin">Login</button>
</template>
