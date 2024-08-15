<script setup>
import { ref, onMounted } from 'vue';
import { useRouter } from 'vue-router';

const user = ref({});
const router = useRouter();

onMounted(() => {
  const userData = JSON.parse(localStorage.getItem('user'));
  if (userData) {
    user.value = userData;
  } else {
    router.push('/login');
  }
});

const logout = () => {
  localStorage.removeItem('user');
  localStorage.removeItem('loginTime');
  router.push('/login');
};
</script>

<template>
  <div>
    <h1>Welcome to your Dashboard</h1>
    <p>Your account details:</p>
    <ul>
      <li><strong>Email:</strong> {{ user.email }}</li>
      <li><strong>Username:</strong> {{ user.username }}</li>
    </ul>
    <button @click="logout">Logout</button>
  </div>
</template>
