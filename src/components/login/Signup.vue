<template>
  <div>
    <label>Email:</label>
    <input type="email" v-model="email" />

    <label>Password:</label>
    <input type="password" v-model="password" />

    <label>Username:</label>
    <input type="text" v-model="username" />

    <button @click="signup">Sign Up</button>
  </div>
</template>

<script setup>
import { ref } from 'vue';
import { useRouter } from 'vue-router';

const email = ref('');
const password = ref('');
const username = ref('');
const router = useRouter();

const signup = async () => {
  const response = await fetch(`${import.meta.env.BASE_URL}users.json`);
  const users = await response.json();

  const newUser = {
    id: users.length + 1,
    email: email.value,
    password: password.value,
    username: username.value,
    created_at: new Date().toISOString(),
    status: 'active'
  };

  localStorage.setItem('user', JSON.stringify(newUser));
  router.push('/dashboard'); // Redireciona para o Dashboard
};
</script>
