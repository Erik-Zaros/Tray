<script setup>
import { obterDadosUsuario } from '../../../../services/api';
import { ref, onMounted, watch } from 'vue';
import { useRouter } from 'vue-router';
import { defineProps } from 'vue';

const props = defineProps({
    isEditing: {
        type: Boolean,
        default: false
    }
});

const estado = ref({});
const usuario = ref();

watch(() => props.isEditing, (newVal) => {
});

const mudarEstado = () => {
    estado.value.status = estado.value.status === 'active' ? 'inactive' : 'active';
};



onMounted(async () => {
  try {
    const dados = await obterDadosUsuario();
    usuario.value = dados;

  } catch (erro) {
    router.push('/login');
  }
});


const router = useRouter();
const showPassword = ref(false);



const imageSrc = ref(null);
const fileInput = ref(null);

const handleDragOver = (event) => {
    event.preventDefault();
};

const handleDrop = (event) => {
    const file = event.dataTransfer.files[0];
    if (file) {
        previewFile(file);
    }
};

const handleFileChange = (event) => {
    const file = event.target.files[0];
    if (file) {
        previewFile(file);
    }
};

const previewFile = (file) => {
    const reader = new FileReader();
    reader.onload = () => {
        imageSrc.value = reader.result;
    };
    reader.readAsDataURL(file);
};

const removePhoto = () => {
    imageSrc.value = null;
};

const editPhoto = () => {
    alert('Editar Foto');
};
</script>

<template>
    <div class="container d-flex flex-column">

        <div class="dados text-center px-1 px-md-5 pt-5 pt-md-0">
            <h1 class="titulo fw-bold">Dados do Usuário</h1>
            <p class="texto fs-5">Informaçoes do usuário para utilizar na identificaçao. O e-mail será utilizado caso
                precise recuperar a senha.</p>
        </div>
        <div class="perfil d-flex w-100">

            <div class="photo p-3 col-12 col-md-4 pb-3 d-flex flex-column justify-content-start align-items-center">
                <h4 class="align-self-start ps-4">Foto</h4>
                <div v-if="!imageSrc"
                    class="upload-area p-3 d-flex flex-column justify-content-center align-items-center"
                    @dragover.prevent="handleDragOver" @drop.prevent="handleDrop" @click="fileInput.click()">
                    <i class="fa-solid fa-cloud-upload-alt fa-3x text-primary"></i>
                    <p class="text-muted mt-2">Arraste uma foto ou clique aqui para selecionar</p>
                    <input type="file" ref="fileInput" class="d-none" @change="handleFileChange" />
                </div>

                <div v-else class="image-preview d-flex flex-column align-items-center">
                    <img :src="imageSrc" class="img-thumbnail shadow-sm" alt="Pré-visualização" />
                    <div class="d-flex align-items-center p-3">
                        <button class="btn btn-primary m-1 shadow-sm" @click="editPhoto">Editar Foto</button>
                        <button class="btn btn-danger m-1 shadow-sm" @click="removePhoto">Remover Foto</button>
                    </div>
                </div>
            </div>


            <div class="infos col-12 col-md-8 p-3">
                <div class="mb-4">
                    <label for="nome" class="form-label fs-5">Nome</label>
                    <input type="text" class="form-control borde-2 rounded-0 py-3 px-4 fs-5" id="nome"
                        :value="usuario.nome" :readonly="!isEditing">
                </div>

                <div class="mb-4">
                    <label for="sobrenome" class="form-label fs-5">Sobrenome</label>
                    <input type="text" class="form-control borde-2 rounded-0 py-3 px-4 fs-5" id="sobrenome"
                        :value="usuario.sobrenome" :readonly="!isEditing">
                </div>

                <div class="mb-4">
                    <label for="email" class="form-label fs-5">Email</label>
                    <input type="email" class="form-control borde-2 rounded-0 py-3 px-4 fs-5" id="email"
                        :value="usuario.email" :readonly="!isEditing">
                </div>

                <div class="mb-4">
                    <label for="senha" class="form-label fs-5">Senha</label>
                    <div class="input-group position-relative">
                        <input :type="showPassword ? 'text' : 'password'"
                            class="form-control borde-2 rounded-0 py-3 px-4 fs-5" id="senha" :value="usuario.senha"
                            :readonly="!isEditing">

                        <i :class="showPassword ? 'fa-solid fa-eye' : 'fa-solid fa-eye-slash m-auto'"
                            @click="showPassword = !showPassword" class="eye cursor-pointer position-absolute"></i>

                    </div>
                </div>

                <div class="mb-4 m-auto">
                    <label for="status" class="form-label fs-5 pe-3 fs-4">Status: </label>
                    <button type="button" class="btn fs-3 px-5"
                        :class="[user.status === 'active' ? 'btn-primary' : 'btn-danger']" :disabled="!isEditing"
                        @click="mudarEstado">
                        {{ user.status === 'active' ? 'Active' : 'Inactive' }}
                    </button>
                </div>
            </div>
        </div>
    </div>
</template>


<style scoped>
.container {
    height: 84vh;
    background-color: var(--background-primary);
    display: flex;
    justify-content: center;
    align-items: center;
    box-shadow: 0px 15px 10px -10px rgba(0, 0, 0, .1) inset;
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
    top: 38%;
    right: 2%;
}

.perfil {
    flex-wrap: wrap;
}

.upload-area {
    width: 90%;
    height: 50%;
    border: 2px dashed #007bff;
    border-radius: 8px;
    cursor: pointer;
    text-align: center;
    background-color: #f8f9fa;
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
}

.upload-area p {
    margin: 0;
}

.upload-area i {
    font-size: 3rem;
}

.image-preview {
    position: relative;
    width: 90%;
    height: 50%;
}

.image-preview img {
    width: 100%;
    height: 100%;
    object-fit: cover;
}

.overlay {
    position: absolute;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    background: rgba(0, 0, 0, 0.6);
    color: white;
    text-align: center;
    border-radius: 8px;
}

.overlay .btn {
    width: 80%;
}

.infos {
    display: flex;
    flex-direction: column;
    justify-content: center;
}

@media (max-width: 724px) {
    .container {
        height: auto;

    }

    .perfil {
        flex-direction: column;
    }

    .upload-area {
        width: 95%;
        height: 100%;
    }
}
</style>