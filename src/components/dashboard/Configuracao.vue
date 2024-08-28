<script setup>
</script>

<template>
    <div class="container-fluid p-0">

    <div class="topo px-5 pt-4 pb-2">
        <h3 class="fw-bold">Configuraçoes</h3>
    </div>

    <div class="cols px-3 d-flex justify-content-around">

 
        <div class="col-md-4 col-12 p-2">
            <div class="card p-4 frete">
                <h4 class="titulo-card mb-3"><i class="bi bi-shop"></i>LOJA</h4>
                <div class="item">
                    <h5 class="titulo">Geral</h5>
                    <p class="texto">Funcionamento geral, cadastro de clientes</p>
                </div>
                <div class="item">
                    <h5 class="titulo">Informações</h5>
                    <p class="texto">Endereço, atendimento,etc</p>
                </div>
                <div class="item">
                    <h5 class="titulo">E-mail</h5>
                    <p class="texto">E-mail vinculados a loja</p>
                </div>
            </div>

            <div class="card p-4 mt-3 frete">
                <h4 class="titulo-card mb-3"><i class="bi bi-cash"></i>Vendas</h4>
                <div class="item">
                    <h5 class="titulo">Objetivo</h5>
                    <p class="texto">Motivos pelo qual esta focado suas vendas</p>
                </div>
                <div class="item">
                    <h5 class="titulo">Metodos Pagamentos</h5>
                    <p class="texto">Principais meios de pagamentos que voce trabalha</p>
                </div>
            </div>
        </div>


        <div class="col-md-4 col-12 p-2">
            <div class="card p-4 frete">
                <h4 class="titulo-card mb-3"><i class="fa-solid fa-truck"></i>Pedidos</h4>
                <div class="item">
                    <h5 class="titulo">Metodos de entrega</h5>
                    <p class="texto">Metodos de entrega o qual sua loja trabalha</p>
                </div>
                <div class="item">
                    <h5 class="titulo">Metodos de rastreio</h5>
                    <p class="texto">Rastreio usado para o usuario achar seu produto</p>
                </div>
                <div class="item">
                    <h5 class="titulo">Pedidos</h5>
                    <p class="texto">Pedidos Gerados dentro da sua loja</p>
                </div>
                <div class="item">
                    <h5 class="titulo">Categoria dos produtos</h5>
                    <p class="texto">Categoria dos produtos que sua loja trabalha</p>
                </div>
            </div>
        </div>


        <div class="col-md-4 col-12 p-2">
            <div class="card p-4 frete">
                <h4 class="titulo-card mb-3"><i class="fa-solid fa-truck"></i> Frete e envio</h4>
                <div class="item">
                    <h5 class="titulo">Correios</h5>
                    <p class="texto">Com a plataforma dos correios tem varios bagui daora e etc.</p>
                </div>
                <div class="item">
                    <h5 class="titulo">Correios</h5>
                    <p class="texto">Com a plataforma dos correios tem varios bagui daora e etc.</p>
                </div>
                <div class="item">
                    <h5 class="titulo">Correios</h5>
                    <p class="texto">Com a plataforma dos correios tem varios bagui daora e etc.</p>
                </div>
                <div class="item">
                    <h5 class="titulo">Correios</h5>
                    <p class="texto">Com a plataforma dos correios tem varios bagui daora e etc.</p>
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

.cols {
    height: 85vh;
}

.item {
    background-color: var(--background-secondary);
    border-radius: 10px;
    padding: 10px;
    margin: 10px 0 10px 0;
}

@media (max-width: 768px) {

    .container {
        max-width: 100% !important;
    }

    .cols {
        flex-direction: column;
    }

}
</style>
