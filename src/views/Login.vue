<template>
  <div>
    <h1>Login</h1>
    <component :is="currentStep" @next="nextStep" />
  </div>
</template>

<script setup>
import { ref, computed } from 'vue';
import { useRouter } from 'vue-router';
import LoginStep1 from '../components/LoginStep1.vue';
import LoginStep2 from '../components/LoginStep2.vue';

const step = ref(1);
const router = useRouter();

const currentStep = computed(() => (step.value === 1 ? LoginStep1 : LoginStep2));

const nextStep = () => {
  if (step.value === 1) {
    step.value = 2;
  } else {
    router.push('/');
  }
};
</script>
