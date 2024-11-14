<script setup>
import { obterDadosUsuario } from '../../services/api';
import { ref, onMounted } from 'vue';
import { useRouter } from 'vue-router';
import { useToast } from 'vue-toastification';
import Progress from './components/Inicio/Progress.vue';
import confetti from 'canvas-confetti'; 

const toast = useToast();
const usuario = ref(null);
const router = useRouter();
const store = ref(false);

const toggleIniciado = () => {
  store.value = !store.value; 
  if (store.value == true) {
    localStorage.setItem('store', store.value);
    confettiStart()
    setTimeout(() => {
      router.push('/dashboard/loja');
      toast.success("Loja Inaugurada!")
    }, 4000);
  } else {
    const confirmarCancelamento = window.confirm("Você tem certeza que deseja cancelar a ação?");
    if (confirmarCancelamento) {
      toast.info("Loja Pausada.");
      localStorage.setItem('store', store.value);
    } else {
      store.value = true;
      toast.info("Ação cancelada.");
    }
  }
};

onMounted(async () => {
  try {
    const dados = await obterDadosUsuario();
    usuario.value = dados;
    localStorage.setItem('usuarioId', dados.id);

    const storeValue = localStorage.getItem('store');
    
    store.value = storeValue === 'true'; 

    console.log('Store Value:', store.value); 

  } catch (erro) {
    router.push('/login');
  }
});

function confettiStart() {
  const button = document.getElementById("confetti");
  button.disabled = true;
  const end = Date.now() + 3 * 1000;
  const colors = ['#bb0000', '#ffffff'];

  function frame() {
    confetti({
      particleCount: 2,
      angle: 60,
      spread: 55,
      origin: { x: 0 },
      colors: colors
    });
    confetti({
      particleCount: 2,
      angle: 120,
      spread: 55,
      origin: { x: 1 },
      colors: colors
    });

    if (Date.now() < end) {
      requestAnimationFrame(frame);
    } else {
      button.disabled = false;
    }
  }
  frame();
}


</script>

<template>
  <div class="container-fluid d-flex p-0" v-if="usuario">

    <div class="col-12 col-md-6">

      <div id="tour-10" class="content-1 shadow-sm m-3 p-3 rounded-4 d-flex align-items-center justify-content-between">
        <div class="d-flex align-items-center">
          <img class="perfil ms-2 ms-md-5 shadow-sm rounded-circle" :src="usuario.userImage || '/image/logoroll.png'"
            alt="">
          <div class="dados ms-2 ms-md-4">
            <h3 class="nome">{{ usuario.nome }}</h3>
            <span class="texto">{{ usuario.email }}</span>
          </div>
        </div>

        <div class="implantacao pe-2 pe-md-4 d-flex flex-column align-items-center justify-content-center">
          <div class="texto text-center">
            <span>Loja em Implantação <i class="fa-regular fa-circle-up"></i></span>
  
        <div id="tour-11" class="content-2 m-3 p-3 rounded-4">
          <div class="post m-0 px-4 d-flex justify-content-between">
            <div class="profile m-0 d-flex align-items-center">
              <img class="perfil-post shadow-sm rounded-circle m-auto" src="https://yt3.googleusercontent.com/FT6pXxVU0FBLbpD9oZSemD59fAVUdIGG58d0zdjOJR20Sm_PHRWgoJdDlZGfXG8r89OY3vUS=s900-c-k-c0x00ffffff-no-rj" alt="">
              <div class="textos ps-3">
                <h4 class="titulo mb-0 mt-2">Dicas do Especialista</h4>
                <p class="texto">Thiago Sarraf</p>
              </div>
            </div>
            <div class="ver d-flex m-0 ps-1 align-items-center">
              <a class="text-decoration-none text-center" href="https://br.linkedin.com/in/thiagosarraf" target="_blank">Ver Mais</a>
            </div>

          </div>
          <div class="inaugurar mt-2">
            <button id="confetti" class="fs-5" :class="store ? 'btn btn-danger' : 'btn btn-primary'" @click="toggleIniciado">
              {{ store ? 'Parar' : 'Iniciar' }}
            </button>
            <!-- <button id="confettiStart" @click="confettiStart">Make it rain</button> -->
          </div>
        </div>
      </div>

      <div id="tour-11" class="content-2 m-3 p-3 rounded-4">
        <div class="post m-0 px-4 d-flex justify-content-between">
          <div class="profile m-0 d-flex align-items-center">
            <img class="perfil-post shadow-sm rounded-circle m-auto"
              src="https://yt3.googleusercontent.com/FT6pXxVU0FBLbpD9oZSemD59fAVUdIGG58d0zdjOJR20Sm_PHRWgoJdDlZGfXG8r89OY3vUS=s900-c-k-c0x00ffffff-no-rj"
              alt="">
            <div class="textos ps-3">
              <h4 class="titulo mb-0 mt-2">Dicas do Especialista</h4>
              <p class="texto">Thiago Sarraf</p>
            </div>
          </div>
          <div class="ver d-flex m-0 ps-1 align-items-center">
            <a class="text-decoration-none text-center" href="https://br.linkedin.com/in/thiagosarraf"
              target="_blank">Ver Mais</a>
          </div>
        </div>

        <div class="post-content p-4">
          <h6>💡 <strong>Dica do Especialista: Personalize Sua Loja!</strong> 🎨</h6>
          <p class="text-post">Quer <strong>aumentar suas vendas</strong>? Experimente a personalização!</p>
          <ul>
            <p class="text-post">🔍 <strong>Analise o Comportamento</strong>: Veja o que seus clientes estão buscando.
            </p>
            <p class="text-post">🛍️ <strong>Recomendações</strong>: Mostre produtos relacionados às suas compras
              anteriores.</p>
            <p class="text-post">🎯 <strong>Ofertas Personalizadas</strong>: Crie promoções específicas para cada perfil
              de cliente.</p>
          </ul>
          <p class="text-post">Transforme a experiência do seu usuário e veja os resultados! 🚀</p>
        </div>
      </div>
    </div>

    <div class="col-12 col-md-6">

      <div id="tour-12" class="content-3 ms-1 my-sm-3 me-3 px-5 rounded-4">

        <div class="plano d-flex justify-content-between align-items-center">
          <h3 class="titulo fw-bold">Meu Plano</h3>
          <a class="text-decoration-none" href="https://tray.com.br/planos-precos/">Gerenciar Plano</a>
        </div>

        <div class="progress w-100">
          <h5 class="conclusao position-absolute pt-4">Cadastro da Loja</h5>
          <Progress class="progress-circle m-auto pt-5" />
        </div>

      </div>

    </div>

  </div>
</template>


<style scoped>
.html {
  overflow-x: hidden;
}

.container-fluid {
  height: 92vh;
}

.content-1 {
  height: 30vh;
  background-color: var(--background-primary);
}

.content-2 {
  background-color: var(--background-primary);
  height: 56vh;
}

.content-3 {
  background-color: var(--background-primary);
  height: 88vh;
}

.perfil {
  height: 170px;
  width: 170px;
  object-fit: cover;
}

.texto {
  color: var(--text-color-sub);
  font-size: 1em;
}

.plano {
  border-bottom: 1px solid rgba(200, 200, 200, .3);
  height: 20%;
}

.progress {
  background-color: var(--background-primary);
  height: 80%;
}

.progress-circle {
  transform: scale(2.5);
}

.post {
  border-bottom: 1px solid rgba(200, 200, 200, .3);
  height: 20%;
}

.perfil-post {
  height: 50px;
}

.post-content {
  height: 80%;
  font-size: 1.9vh;
}

@media (max-width: 724px) {

  .container-fluid {
    height: 150vh;
    background-color: var(--background-secondary);
  }

  .container-fluid {
    flex-direction: column;
  }

  .content-1 {
    height: 20vh;
    background-color: var(--background-primary);
  }

  .content-2 {
    background-color: var(--background-primary);
    height: 66vh;
  }

  .content-3 {
    background-color: var(--background-primary);
    height: 57vh;
  }

  .dados>.nome {
    font-size: 1em;
  }

  .texto {
    font-size: .5em;
  }

  .textos>.titulo {
    font-size: 13px;
  }

  .ver>a {
    font-size: .8rem;
  }

  .perfil-post {
    height: 35px;
  }

  .post-content {
    height: 0%;
    font-size: 1.5vh;
  }

  .plano {
    height: 20%;
  }

  .plano>.titulo {
    font-size: 20px;
  }

  .plano>a {
    font-size: 14px;
  }

  .progress {
    background-color: var(--background-primary);
  }

  .progress-circle {
    transform: scale(1.2);
  }
}
</style>