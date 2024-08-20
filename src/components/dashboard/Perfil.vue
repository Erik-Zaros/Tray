<script setup>
import { ref } from 'vue';
import Header from '../dashboard/components/Perfil/Header.vue';
import Dados from '../dashboard/components/Perfil/Dados.vue';

const isEditing = ref(false);

const handleToggleEdit = (value) => {
  isEditing.value = value;
};
</script>

<template>
  <div>
    <Header @toggleEdit="handleToggleEdit" />
    <Dados :isEditing="isEditing" />
  </div>
</template>


<style scoped></style>