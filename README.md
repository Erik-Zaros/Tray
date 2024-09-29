# Projeto Tray MEGEV - Universidade de Marília - Unimar

[![Trello](https://img.shields.io/badge/Trello-0079BF?style=for-the-badge&logo=trello&logoColor=white)](https://trello.com/b/PO8GLwIj/megev)
[![YouTube](https://img.shields.io/badge/YouTube-FF0000?style=for-the-badge&logo=youtube&logoColor=white)](https://youtube.com)

## Objetivo do projeto

Este sistema oferece uma interface intuitiva onde o usuário pode gerenciar sua conta, realizar login e criar novas contas. Após o cadastro, um guia interativo orienta o usuário por todas as funcionalidades do sistema. A tela principal permite acompanhar o progresso do cadastro da loja e visualizar dicas personalizadas. O gerenciamento de perfil inclui a edição de informações pessoais e a atualização da imagem de perfil. Os usuários podem visualizar e gerenciar seus produtos, incluindo cadastro, edição, exclusão e importação em massa via Excel. Além disso, é possível personalizar a navbar e a sidebar com cores em formato hexadecimal. A navegação é facilitada por um painel que direciona para diferentes seções, e um suporte detalhado está disponível para esclarecer dúvidas, com um botão "Fale Conosco" para atendimento imediato.

## Requisitos

### Backend
- Visual Studio 2022
- .NET Core 8.0
- MySQL Workbench

### Frontend
- Node.js 14.x ou superior

## Clone o repositório

Para clonar o repositório, execute o seguinte comando no seu CMD:

```bash
git clone https://github.com/GustavoM4tias/Tray.git
```

## Executando o Frontend

Após clonar o repositório em sua máquina, navegue até a pasta `Tray` do projeto e execute os seguintes comandos:

- Executar os comandos na ordem mostrada em tela!

  - npm install
  - npm install axios
  - npm run dev

Isso gerará uma URL no localhost, que você pode abrir no navegador. Com isso, o frontend estará funcionando localmente em sua máquina.

Observação: Utilize o CMD/prompt de comando em vez do PowerShell.

![image](https://github.com/user-attachments/assets/2795d4db-20cc-4d04-b17a-d3de7ada8fbd)

## Localizando arquivo para abrir o Visual Studio 2022

1. Navegue até a pasta principal do projeto: Tray > BackEnd > ApiMegev.
2. Clique no arquivo `ApiMegev.csproj`, que abrirá automaticamente o backend e a API com suas dependências no visual studio 2022.

![image](https://github.com/user-attachments/assets/2ba27ad5-4eae-4d2c-8683-488090459c3e)

## Configuração do MySQL Workbench
- No arquivo de conexão `appsettings.json`. Substitua a seção `ConnectionStrings` com as informações de conexão do seu MySQL Workbench. Segue imagem de exemplo:

![image](https://github.com/user-attachments/assets/1ed31cc7-a2c7-4f45-a56c-738a0c740d12)


![image](https://github.com/user-attachments/assets/fd4fde98-ed3d-4b07-bb82-9d077646e496)

## Atualizando o Banco de Dados
- Abra o terminal no Visual Studio na pasta raiz do projeto `ApiMegev` e execute o seguinte comando:

```bash
dotnet ef database update
```

![image](https://github.com/user-attachments/assets/9400784c-2650-4401-8c99-58177ee78611)

- Isso criará o banco de dados `megev_tray` no MySQL Workbench.

![image](https://github.com/user-attachments/assets/ab94c6af-0879-4cc8-ab6f-747c4053881c)

## Executando o Backend

- Após a atualização do banco de dados, vá até o arquivo `Program.cs` no visual studio 2022 e execute o backend. Segue os pontos para clicar:

![image](https://github.com/user-attachments/assets/1e1e3f1a-506f-44cf-8da1-7398bb76f803)

## Acessando o Swagger

- Após executar o backend, uma URL no localhost será gerada automaticamente no seu navegador padrão. A tela pode exibir uma mensagem como "Página não encontrada". Para acessar o Swagger, acrescente `/swagger/index.html` à URL, ficando da seguinte forma: `https://localhost:7205/swagger/index.html`.

- O Swagger exibirá todos os endpoints desenvolvidos, e tanto o frontend quanto o backend estarão funcionando e devidamente conectados.

![image](https://github.com/user-attachments/assets/a819d6dc-1758-4919-a544-3ec3b2e994db)

Observação: Verifique no arquivo `axios.js` se a porta é a mesma que a do Swagger.

- Após a execução de todos os passos mencionados, tanto o frontend quanto o backend estarão funcionando corretamente. Em seguida, realize os testes necessários através do localhost gerado pelo frontend.

## Observação Importante: A não observância de qualquer ponto deste README pode resultar em mau funcionamento do projeto ou até mesmo impossibilitar a execução de testes.

## Tela 01

- Arquivo: Inicio.vue
- Nesta tela inicial, o usuário tem a opção de fazer login em sua conta existente. O processo de login é simples e rápido, permitindo acesso imediato às funcionalidades do sistema. Para novos usuários, o registro é facilitado por um formulário intuitivo, onde informações básicas são solicitadas. Após o cadastro, o usuário poderá explorar todas as funcionalidades disponíveis no sistema.

![image](https://github.com/user-attachments/assets/0cf87a65-b82f-4447-ab50-852dab0763c2)

## Tela 02

- Arquivo: LoginStep1.vue/LoginStep2.vue
- Nesta tela, o usuário que já criou sua conta pode realizar o login no sistema em duas etapas simples e seguras. Na primeira etapa, o usuário deve inserir seu endereço de e-mail associado à conta. Em seguida, na segunda etapa, ele deve fornecer sua senha. Este processo de autenticação em duas etapas garante maior segurança e proteção dos dados do usuário, permitindo o acesso rápido e eficiente às funcionalidades do sistema.
 
![image](https://github.com/user-attachments/assets/5c7c185b-fe11-4200-b705-207ae9e5b2a5)


## Tela 03

- Arquivo: Registrar.vue
- Nesta tela, o usuário tem a oportunidade de criar uma nova conta para acessar o sistema. O processo de cadastro é intuitivo e consiste em preencher um formulário com informações essenciais, como nome, sobrenome, e-mail e senha. Ao finalizar o cadastro, o usuário poderá acessar ao sistema, garantindo um acesso personalizado e seguro às suas informações.

![image](https://github.com/user-attachments/assets/2749a8fa-c6e7-44db-881c-1999f6d1c2df)

## Tela 04

- Arquivo: Tour.vue
- Ao cadastrar uma nova conta para acessar o sistema, o usuário será recebido com um guia interativo durante o login. Esse guia irá percorrer cada tela do sistema, oferecendo explicações detalhadas sobre as funcionalidades e recursos disponíveis. Dessa forma, o usuário terá uma experiência mais fluida e intuitiva, facilitando a compreensão do funcionamento do sistema e permitindo que aproveite ao máximo todas as suas capacidades desde o início.
  
![image](https://github.com/user-attachments/assets/7f5e253a-3ba9-418f-be17-051db0a0b219)

## Tela 05

- Arquivo: Inicio.vue
- Esta é a tela principal do sistema, onde o usuário pode monitorar o progresso do cadastro de sua loja. Além disso, ele terá acesso a dicas valiosas de especialistas, que o auxiliarão na personalização da sua loja. Essa combinação de informações e orientações práticas proporciona uma experiência otimizada, permitindo que o usuário tome decisões informadas para melhorar sua presença no mercado.

![image](https://github.com/user-attachments/assets/72499dc6-8a95-458f-89eb-0856d5efc9cd)

## Tela 06

- Arquivo: Perfil.vue
- Nesta tela, o usuário pode gerenciar seu perfil de maneira abrangente. É possível editar informações como nome, sobrenome e e-mail de acesso ao sistema, garantindo que seus dados estejam sempre atualizados. Além disso, o usuário pode atualizar sua imagem de perfil, seja fazendo upload de um arquivo de imagem ou fornecendo uma URL correspondente. Para maior controle, também existe a opção de ativar ou desativar o perfil conforme a necessidade.

![image](https://github.com/user-attachments/assets/14cc85bf-68b8-4538-8c18-28d8a1cc686a)

## Tela 07

- Arquivo: Loja.vue
- Nesta tela, o usuário pode visualizar todos os produtos cadastrados, dispostos de maneira organizada por categoria. Cada produto é exibido com seu respectivo valor, facilitando a navegação e a gestão do inventário.

![image](https://github.com/user-attachments/assets/dbcbf6a6-9ef7-4fb3-a0be-c7783bb321ba)

## Tela 08

- Arquivo: Produtos.vue
- Nesta tela, o usuário tem a capacidade de cadastrar, editar, excluir e filtrar produtos de maneira eficiente. Além disso, oferece a funcionalidade de importar vários produtos simultaneamente através de um arquivo Excel, otimizando o processo de gestão do inventário.

![image](https://github.com/user-attachments/assets/1c8ac0b2-d3b9-4d49-af99-336235565956)

## Tela 09

- Arquivo: Templates.vue
- Nesta tela, o usuário pode selecionar a cor desejada para aplicar à navbar e à sidebar do sistema. A cor escolhida é apresentada em formato hexadecimal, permitindo uma visualização clara e precisa da seleção feita.

![image](https://github.com/user-attachments/assets/3918b264-0c8a-4d08-8521-6941a58409c1)

## Tela 10

- Arquivo: Configuracao.vue
- Esta tela funciona como um painel de navegação, guiando o usuário para as diversas seções do sistema. Com uma interface intuitiva, facilita o acesso rápido às funcionalidades disponíveis, promovendo uma experiência de uso eficiente.

![image](https://github.com/user-attachments/assets/fee7fd16-2488-4cb6-9d48-66b4c0973620)

## Tela 11

- Arquivo: Ajuda.vue
- Esta tela é dedicada para oferecer orientação detalhada ao usuário sobre cada aspecto do sistema, servindo como um recurso valioso para esclarecer dúvidas ou fornecer suporte adicional. Um botão chamado "Fale Conosco" está disponível ao clicar nele, o usuário é direcionado a um canal de atendimento, garantindo que suas questões sejam atendidas de forma rápida e eficaz.
  
![image](https://github.com/user-attachments/assets/dad194fb-9231-4d88-b1b1-497f9505a992)

## Stacks utilizadas

![Vue.js](https://img.shields.io/badge/Vue.js-35495E?style=for-the-badge&logo=vue.js&logoColor=4FC08D)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)
[![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
![MySQL Workbench](https://img.shields.io/badge/MySQL_Workbench-4479A1?style=for-the-badge&logo=mysql&logoColor=white)

## Nome e RA dos colaboradores do projeto

- **Edmar Augusto Martins - 1959465 - Dev**
- **Erik Delanda Zaros - 1959937 - Scrum**
- **Gustavo Henrique Matias Diniz - 1977490 - Front-End**
- **Victor Gabriel de Lima Peres - 1969980 - Front-End**
