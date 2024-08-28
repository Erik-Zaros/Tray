<template>
  <div class="container">
    <h1 class="text-center my-4">Ajuda e Suporte</h1>

    <section id="inicio" class="mb-5">
      <h2 class="text-dark">Início</h2>
      <p>A seção "Início" é a página principal do seu painel de controle. Aqui você encontrará uma visão geral do seu site, incluindo métricas importantes, atualizações recentes e outras informações essenciais para monitorar o desempenho do seu site.</p>

      <h3>Principais Funcionalidades</h3>
      <ul>
        <li><strong>Visão Geral do Site:</strong> Veja uma visão rápida das métricas de desempenho, como visitantes, páginas mais vistas e vendas recentes.</li>
        <li><strong>Notificações:</strong> Receba alertas sobre atividades importantes, atualizações ou ações que precisam da sua atenção.</li>
        <li><strong>Acesso Rápido:</strong> Navegue facilmente para outras seções do painel através de atalhos e widgets personalizáveis.</li>
      </ul>
    </section>

    <section id="perfil" class="mb-5">
      <h2 class="text-dark">Perfil</h2>
      <p>A seção "Perfil" permite que você gerencie as informações pessoais associadas à sua conta. Aqui você pode atualizar seu nome, e-mail e senha para garantir que suas informações estejam sempre atualizadas e seguras.</p>

      <h3>Como Atualizar</h3>
      <ol>
        <li>Clique no botão de edição ao lado das informações que deseja modificar.</li>
        <li>Faça as alterações desejadas.</li>
        <li>Clique em "Salvar" para aplicar as mudanças.</li>
      </ol>
      <p>Certifique-se de que seu e-mail esteja correto para receber notificações importantes e redefinir sua senha se necessário.</p>
    </section>

    <section id="loja" class="mb-5">
      <h2 class="text-dark">Sua Loja</h2>
      <p>A seção "Sua Loja" é onde você gerencia as configurações da sua loja online. Aqui você pode ajustar informações sobre seus produtos, configurar métodos de pagamento e definir opções de envio.</p>

      <h3>Gerenciamento de Produtos</h3>
      <p>Para adicionar ou editar produtos:</p>
      <ol>
        <li>Acesse a subseção de gerenciamento de produtos.</li>
        <li>Para adicionar um novo produto, clique em "Adicionar Novo".</li>
        <li>Preencha os campos necessários, como nome, descrição, preço e imagens.</li>
        <li>Organize seus produtos em categorias para facilitar a navegação.</li>
        <li>Salve suas alterações e publique os produtos na sua loja.</li>
      </ol>
    </section>

    <section id="produtos" class="mb-5">
      <h2 class="text-dark">Produtos</h2>
      <p>A seção "Produtos" permite gerenciar o catálogo de produtos da sua loja. Você pode visualizar, editar e excluir produtos, além de gerenciar categorias e tags associadas.</p>

      <h3>Adicionar Novo Produto</h3>
      <p>Para adicionar um novo produto:</p>
      <ol>
        <li>Clique em "Adicionar Novo".</li>
        <li>Preencha todos os campos obrigatórios, como nome, descrição e preço.</li>
        <li>Adicione imagens de alta qualidade para destacar o produto.</li>
        <li>Clique em "Salvar" para adicionar o produto ao seu catálogo.</li>
      </ol>
      <p>Certifique-se de revisar as informações antes de salvar para evitar erros.</p>
    </section>

    <section id="templates" class="mb-5">
      <h2 class="text-dark">Templates</h2>
      <p>A seção "Templates" permite escolher e personalizar os modelos de design do seu site. Você pode aplicar diferentes temas para alterar a aparência do seu site e ajustar o layout para atender às suas necessidades.</p>

      <h3>Selecionar um Template</h3>
      <p>Para selecionar um template:</p>
      <ol>
        <li>Navegue pela lista de templates disponíveis.</li>
        <li>Clique no template desejado para visualizar uma prévia.</li>
        <li>Se estiver satisfeito com a prévia, clique em "Aplicar" para definir o template como o design atual do seu site.</li>
      </ol>
      <p>Você pode personalizar ainda mais o template escolhido usando as ferramentas de edição disponíveis.</p>
    </section>

    <section id="configuracoes" class="mb-5 pb-5">
      <h2 class="text-dark">Configurações</h2>
      <p>A seção "Configurações" permite ajustar as configurações gerais do seu site. Isso inclui ajustes de segurança, preferências de idioma e opções de integração com outros serviços.</p>

      <h3>Configurações de Segurança</h3>
      <p>Para ajustar as configurações de segurança:</p>
      <ol>
        <li>Acesse a subseção de segurança.</li>
        <li>Configure opções como autenticação de dois fatores para proteger sua conta.</li>
        <li>Ajuste permissões de acesso para diferentes usuários, se aplicável.</li>
      </ol>
      <p>Mantenha suas configurações de segurança atualizadas para proteger seu site contra ameaças e ataques.</p>
      <p>Se tiver alguma dúvida, clique no botão "Fale Conosco" para ser direcionado à nossa página de suporte e conhecimento.</p>
      <a href="https://tray.com.br/canais-de-atendimento/"><button class="btn btn-primary">Fale Conosco</button></a>
    </section>
  </div>
</template>

<style scoped>
  body, html {
    margin: 0;
    padding: 0;
    height: 100%;
  }

  .container {
    background-color: #dddddd;
    min-height: 252vh; 
    padding: 20px;
  }

  h2 {
    border-bottom: 2px solid var(--color-dark);
    padding-bottom: 10px;
  }

  h3 {
    margin-top: 20px;
    color: var(--color-dark);
  }
</style>
