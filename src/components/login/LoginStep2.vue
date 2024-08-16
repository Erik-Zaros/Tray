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
    router.push('/dashboard/inicio'); 
  } else {
    alert('Invalid login');
  }
};
</script>

<template>
  <div class="input-group px-2 px-md-5 row">
    <label class="text-start my-2">Senha <span class="text-danger">*</span></label>
    <input class="form-control rounded-5 p-3 mb-3" type="password" v-model="password" placeholder="Senha" />
    <button class="btn btn-success col-12 rounded-5 fs-4 fw-bold" @click="login">Login</button>
  </div>
</template>




