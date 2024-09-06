<script setup>
import { ref } from 'vue';
import { useRouter } from 'vue-router';
import { excluirUsuario } from '../../services/api';
import { useToast } from 'vue-toastification';
const toast = useToast();
const router = useRouter();


const excluirConta = async () => {
  try {
    await excluirUsuario(usuario.value.id);
    toast.success('Conta excluída com sucesso!');

    // Aguarda 2 segundos (2000 milissegundos)
    await new Promise(resolve => setTimeout(resolve, 2000));

    router.push('/login');
  } catch (erro) {
    //console.error('Erro ao excluir conta:', erro); // Log mais detalhado
    toast.error(`Erro ao excluir conta: ${erro.message}`);
  }
}

</script>

<template>
    <div class="container-fluid p-0">

    <div class="topo px-5 pt-4 pb-2">
        <h3 class="fw-bold">Configuraçoes</h3>
    </div>

    <div class="cols px-3 d-flex justify-content-around">

 
        <div class="col-md-4 col-12 p-2">
            <div class="card p-4 loja">
                <h4 class="titulo-card mb-3"><i class="fas fa-store me-2"></i>Loja</h4>
                <div class="item">
                    <router-link to="/dashboard/perfil">
                        <h5 class="titulo">Geral</h5>
                        <p class="texto">Funcionamento geral, cadastro de clientes</p>
                    </router-link>
                </div>
                <div class="item">
                    <h5 class="titulo">Informações</h5>
                    <p class="texto">Endereço, atendimento, etc...</p>
                </div>
                <div class="item">
                    <h5 class="titulo">Clientes</h5>
                    <p class="texto">Relatório de acessos e vendas</p>
                </div>
            </div>

            <div class="card p-4 mt-3 pedidos">
                <h4 class="titulo-card mb-3"><i class="fa-solid fa-cart-shopping me-2"></i>Pedidos</h4>
                <div class="item">
                    <h5 class="titulo">Devoluções</h5>
                    <p class="texto">Métricas de Devolução</p>
                </div>
                <div class="item">
                    <h5 class="titulo">Suporte</h5>
                    <p class="texto">Assistência e chat</p>
                </div>
            </div>
        </div>


        <div class="col-md-4 col-12 p-2">
            <div class="card p-4 frete">
                <h4 class="titulo-card mb-3"><i class="fa-solid fa-truck"></i> Frete e envio</h4>
                <div class="item">
                    <h5 class="titulo">Geral <button class="btn btn-primary p-1 py-0 ms-1 mb-1">Pré-ativa</button></h5>
                    <p class="texto mb-0">Formas de envio, Correios, retirada na loja.</p>
                </div>
            </div>
            <div class="card p-4 produtos mt-3">
                <h4 class="titulo-card mb-3"><i class="fa-solid fa-tag me-2"></i>Produtos</h4>
                <div class="item">
                    <router-link to="/dashboard/produtos">
                        <h5 class="titulo">Lista de Produtos</h5>
                        <p class="texto">Listagem e exibição de produtos na</p>
                    </router-link>
                </div>
                <div class="item">
                    <h5 class="titulo">Categoria dos produtos</h5>
                    <p class="texto">Categoria dos produtos que sua loja trabalha</p>
                </div>
                <div class="item">
                    <h5 class="titulo">Pedidos</h5>
                    <p class="texto">Pedidos Gerados dentro da sua loja</p>
                </div>
                <div class="item">
                    <h5 class="titulo">Metodos de entrega</h5>
                    <p class="texto">Metodos de entrega o qual sua loja trabalha</p>
                </div>
            </div>
        </div>


        <div class="col-md-4 col-12 p-2">
            <div class="card p-4 pagamento">
                <h4 class="titulo-card mb-3"><i class="fa-solid fa-money-bill"></i> Pagamentos</h4>
                <div class="item">
                    <h5 class="titulo">Formas de Pagamento <button class="btn btn-danger p-1 py-0 ms-1 mb-1">Novo</button></h5>
                    <p class="texto mb-0">Configure e organize seu checkout com diversas opções de gateways e intermediadores de pagamento</p>
                </div>
                <div class="item">
                    <h5 class="titulo">Vindi <i class="fa-solid fa-circle-question fs-6"></i></h5>
                    <p class="texto">Configurações do intermediador.</p>
                </div>
            </div>
            <div class="card p-4 excluir mt-3">
                <h4 class="titulo-card mb-3"><i class="fa-solid fa-delete-left"></i> Encerrar Assinatura</h4>
                <div class="item" @click="excluirConta">
                    <h5 class="titulo">Excluir Conta </h5>
                    <p class="texto mb-0">Excluir loja, conta e cancelar assinatura.</p>
                </div>
            </div>
        </div>


    </div>

</div>
</template>

<style scoped>
.container-fluid {
    height: 92vh;
    background-color: var(--background-secondary);
}

.item {
    background-color: var(--background-secondary);
    border-radius: 10px;
    padding: 15px 15px 8px 15px;
    margin: 10px 0 10px 0;
}

.item:hover {
    background-color: #0D6EFD;
    color: rgb(255, 255, 255)!important;
    transition: .2s;
    & .texto {
        color: rgb(235, 235, 235)!important;
    }
}

.texto {
    transition: .2s;
    color: var(--text-color-sub);
    font-size: 12px;
}

@media (max-width: 768px) {

    .container {
        max-width: 100% !important;
    }

    .cols {
        flex-direction: column;
    }

}
a{
    text-decoration: none;
    color:black;
}
</style>
