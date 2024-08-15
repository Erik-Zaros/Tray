<script setup>
import { ref, onMounted } from 'vue';
import { useRouter } from 'vue-router';

import Header from "../components/dashboard/Header.vue"

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

</script>

<template>

  <Header />




    <ul>
      <li><strong>Email:</strong> {{ user.email }}</li>
      <li><strong>Username:</strong> {{ user.username }}</li>
    </ul>


</template>
