<script setup>
import { ref, onMounted } from 'vue';
import { RouterView, useRouter } from 'vue-router';

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

<template class="vh-100 vw-100">

  <Header />
  <router-view class="conteudo position-absolute bottom-0 end-0" />

</template>

<style>

.conteudo {
  top: 8vh;
  left: 80px;
  width: calc(100vw - 80px);
  transition: left 0.3s, width 0.3s;
}


</style>