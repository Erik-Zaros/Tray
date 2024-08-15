<template>
  <div>
    <label>Password:</label>
    <input type="password" v-model="password" />
    <button @click="login">Login</button>
  </div>
</template>

<script setup>
import { ref } from 'vue';
import { useRouter } from 'vue-router';

const password = ref('');
const router = useRouter();

const login = async () => {
  const email = sessionStorage.getItem('email');
  const response = await fetch(`${import.meta.env.BASE_URL}users.json`);
  const users = await response.json();
  
  const user = users.find(user => user.email === email && user.password === password.value);

  if (user) {
    localStorage.setItem('user', JSON.stringify(user));
    localStorage.setItem('loginTime', new Date().getTime());
    router.push('/dashboard'); // Redireciona para o Dashboard
  } else {
    alert('Invalid login');
  }
};
</script>
