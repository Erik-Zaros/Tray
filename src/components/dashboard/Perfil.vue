<script setup>
import { ref, onMounted } from 'vue';
import { useRouter } from 'vue-router';
import { obterDadosUsuario, atualizarUsuario } from '../../services/api';
import Tour from '../dashboard/components/Perfil/Tour.vue';
// Notificacoes maneiras
import { useToast } from 'vue-toastification';
const toast = useToast();


const editando = ref(false);
const usuario = ref({});
const usuarioOriginal = ref({});
const router = useRouter();

const imageSrc = ref(null);
const addImagem = ref(null);

const alternarEdicao = () => {
  if (editando.value) {
    // Quando entra no modo de edição, guarda o estado original
    usuarioOriginal.value = { ...usuario.value };
  }
  editando.value = !editando.value;
};

const salvarEdicao = async () => {
  try {
    const dadosAtualizados = {
      id: usuario.value.id,
      nome: usuario.value.nome,
      sobrenome: usuario.value.sobrenome,
      email: usuario.value.email,
      saldo: usuario.value.saldo,
      userImage: usuario.value.userImage // Inclua a URL da imagem aqui
    };

    // Verifica os dados antes de enviar
    // console.log('Dados para atualização:', dadosAtualizados);

    // Salvar alterações
    await atualizarUsuario(dadosAtualizados);
    await perfilUsuario();
    toast.success('Dados atualizados com sucesso!');
    editando.value = false;
  } catch (erro) {
    // console.error('Erro ao atualizar dados:', erro);
    toast.error(`Erro ao atualizar dados: ${erro.message}`);
  }
};

const cancelarEdicao = () => {
  // Reverter as mudanças e sair do modo de edição
  usuario.value = { ...usuarioOriginal.value };
  editando.value = false;
};

const arrastaImagem = (event) => {
  event.preventDefault();
};

const soltaImagem = (event) => {
  const file = event.dataTransfer.files[0];
  if (file) {
    preview(file);
  }
};

const alteraImagem = (event) => {
  const file = event.target.files[0];
  if (file) {
    preview(file);
  }
};

const preview = (file) => {
  const reader = new FileReader();
  reader.onload = () => {
    imageSrc.value = reader.result;
    usuario.value.userImage = reader.result; // Atualize o campo do usuário
  };
  reader.readAsDataURL(file);
};

const removerFoto = () => {
  imageSrc.value = null;
  usuario.value.userImage = ''; // Limpar a URL da imagem
};

const mudarEstado = () => {
  usuario.value.status = usuario.value.status === 'active' ? 'inactive' : 'active';
};

const perfilUsuario = async () => {
  try {
    const dados = await obterDadosUsuario();
    usuario.value = dados;
    usuarioOriginal.value = { ...dados }; // Guarda o estado original ao montar
    imageSrc.value = dados.userImage; // Preenche o preview com a imagem do usuário
  } catch (erro) {
    // console.error('Erro ao obter dados do usuário:', erro); // Log mais detalhado
    router.push('/login');
  }
}

onMounted(async () => {
  await perfilUsuario();
});


</script>

<template>
  <div>
    <div class="container-fluid p-0">
      <div class="salvar shadow w-100 px-5 d-flex align-items-center justify-content-between">
        <div class="editar-titulo fw-bold">{{ usuario.nome ? `Usuário: ${usuario.nome}` : 'Usuário' }}</div>
        <div class="usuario" :class="{ 'd-none': editando }">
          <button @click="alternarEdicao" class="btn btn-primary py-2 px-3 ms-3 rounded-0">Editar</button>
        </div>
        <div class="opcoes-editar" :class="{ 'd-block': editando, 'd-none': !editando }">
          <button @click="cancelarEdicao" class="btn btn-outline-secondary py-2 px-3 ms-5 rounded-0">Cancelar</button>
          <button @click="salvarEdicao" class="btn btn-outline-primary py-2 px-3 ms-3 rounded-0">Salvar</button>
        </div>
      </div>
    </div>

    <div class="container d-flex flex-column">
      <div class="dados text-center px-1 px-md-5 pt-5 pt-md-0">
        <h1 class="titulo fw-bold">Dados do Usuário</h1>
        <p class="texto fs-5">Informações do usuário para utilizar na identificação. O e-mail será utilizado caso
          precise recuperar a senha.</p>
      </div>
      <div class="perfil d-flex w-100">
        <div class="foto p-3 col-12 col-md-4 pb-3 d-flex flex-column justify-content-start align-items-center">
          <h4 class="align-self-start ps-4">Foto</h4>

          <div v-if="!imageSrc" :class="{ 'inativo': !editando }" class="area-upload p-3 d-flex flex-column justify-content-center align-items-center"
            @dragover.prevent="arrastaImagem" @drop.prevent="soltaImagem" @click="addImagem.click()">
            <i class="fa-solid fa-cloud-upload-alt fa-3x text-primary"></i>
            <p class="text-muted mt-2">Arraste uma foto ou clique aqui para selecionar</p>
            <input type="file" ref="addImagem" class="d-none" @change="alteraImagem" />
          </div>
          <div v-else class="preview-imagem d-flex flex-column align-items-center">
            <img :src="imageSrc" class="img-thumbnail shadow-sm" alt="Pré-visualização" />
            <div class="d-flex align-items-center p-3 position-absolute end-0">
              <i v-show="editando" class="fa-solid fa-trash-can text-light fs-2" @click="removerFoto"></i>
            </div>
          </div>
        </div>
        <div class="informacoes col-12 col-md-8 p-3">
          <div class="mb-4">
            <label for="nome" class="form-label fs-5">Nome</label>
            <input type="text" class="form-control borde-2 rounded-0 py-3 px-4 fs-5" id="nome" v-model="usuario.nome"
              :readonly="!editando">
          </div>
          <div class="mb-4">
            <label for="sobrenome" class="form-label fs-5">Sobrenome</label>
            <input type="text" class="form-control borde-2 rounded-0 py-3 px-4 fs-5" id="sobrenome"
              v-model="usuario.sobrenome" :readonly="!editando">
          </div>
          <div class="mb-4">
            <label for="email" class="form-label fs-5">Email</label>
            <input type="email" class="form-control borde-2 rounded-0 py-3 px-4 fs-5" id="email" v-model="usuario.email"
              :readonly="!editando">
          </div>
          <div class="mb-4">
            <label for="userImage" class="form-label fs-5">URL da Imagem</label>
            <input type="text" class="form-control borde-2 rounded-0 py-3 px-4 fs-5" id="userImage"
              v-model="usuario.userImage" :readonly="!editando" placeholder="Cole a URL da imagem aqui" />
          </div>
          <div class="mb-4 m-auto">
            <label for="status" class="form-label fs-5 pe-3 fs-4">Status: </label>
            <button type="button" class="btn fs-3 px-5"
              :class="[usuario.status === 'active' ? 'btn-primary' : 'btn-danger']" :disabled="!editando"
              @click="mudarEstado">
              {{ usuario.status === 'active' ? 'Active' : 'Inactive' }}
            </button>
          </div>
        </div>
      </div>
      
    </div>

    <!-- Tour Component -->
    <Tour />
  </div>
</template>

<style scoped>

.container-fluid {
  z-index: 3;
}

.salvar {
  height: 8vh;
  background-color: var(--background-navbar);
}

.editar-titulo {
  font-size: 1.6em;
  color: var(--color-primary);
}

.d-none {
  display: none;
}

.d-block {
  display: block;
}

.container {
  height: 84vh;
  background-color: var(--background-primary);
  display: flex;
  justify-content: center;
  align-items: center;
  box-shadow: 0px 15px 10px -10px rgba(0, 0, 0, .1) inset;
}

.perfil {
  flex-wrap: wrap;
}

.area-upload {
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

.area-upload p {
  margin: 0;
}

.area-upload i {
  font-size: 3rem;
}

.preview-imagem {
  position: relative;
  width: 90%;
  height: 50%;
}

.preview-imagem img {
  width: 100%;
  height: 100%;
  object-fit: cover;
}

.informacoes {
  display: flex;
  flex-direction: column;
  justify-content: center;
}

.input-group button {
  cursor: pointer;
}

.olho {
  top: 38%;
  right: 2%;
}

.inativo {
  pointer-events: none; /* Desativa a interatividade */
  opacity: 0.5; /* Opcional: visualmente indica que está inativo */
}

.excluir {
  margin-left: 1%;
  margin-bottom: 1%;
}

@media (max-width: 724px) {
  .container {
    height: auto;
  }

  .perfil {
    flex-direction: column;
  }

  .area-upload {
    width: 95%;
    height: 100%;
  }
}
</style>
