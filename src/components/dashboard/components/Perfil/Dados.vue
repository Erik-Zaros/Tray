<script setup>
import { ref, onMounted, watch } from 'vue';
import { useRouter } from 'vue-router';
import { defineProps } from 'vue';

const props = defineProps({
    isEditing: {
        type: Boolean,
        default: false
    }
});

const user = ref({});
const router = useRouter();
const showPassword = ref(false);

onMounted(() => {
    const userData = JSON.parse(localStorage.getItem('user'));
    if (userData) {
        user.value = userData;
    } else {
        router.push('/login');
    }
});

watch(() => props.isEditing, (newVal) => {
});


const toggleStatus = () => {
    user.value.status = user.value.status === 'active' ? 'inactive' : 'active';
};

</script>

<template>
    <div class="container">
        <form>
            <div class="mb-3">
                <label for="username" class="form-label">Username</label>
                <input type="text" class="form-control rounded" id="username" :value="user.username" :readonly="!isEditing">
            </div>

            <div class="mb-3">
                <label for="name" class="form-label">Full Name</label>
                <input type="text" class="form-control rounded" id="name" :value="user.full_name" :readonly="!isEditing">
            </div>

            <div class="mb-3">
                <label for="email" class="form-label">Email</label>
                <input type="email" class="form-control rounded" id="email" :value="user.email" :readonly="!isEditing">
            </div>

            <div class="mb-3">
                <label for="password" class="form-label">Password</label>
                <div class="input-group position-relative">
                    <input :type="showPassword ? 'text' : 'password'" class="form-control rounded" id="password"
                        :value="user.password" :readonly="!isEditing">

                    <i :class="showPassword ? 'fa-solid fa-eye m-auto' : 'fa-solid fa-eye-slash m-auto'"
                        @click="showPassword = !showPassword" class="eye cursor-pointer position-absolute"></i>

                </div>
            </div>

            <div class="mb-3">
                <label for="status" class="form-label pe-3">Status: </label>
                <button type="button" class="btn" :class="[user.status === 'active' ? 'btn-primary' : 'btn-danger']"
                    :disabled="!isEditing" @click="toggleStatus">
                    {{ user.status === 'active' ? 'Active' : 'Inactive' }}
                </button>
            </div>
        </form>
    </div>
</template>


<style scoped>
.container {
    height: 84vh;
    background-color: var(--background-primary);
    display: flex;
    justify-content: center;
    align-items: center;
}

form {
    width: 100%;
    max-width: 400px;
}

.input-group button {
    cursor: pointer;
}

.showPassword {
    background-color: red;
}

.eye {
    top: 30%;
    right: 2%;
}

</style>
