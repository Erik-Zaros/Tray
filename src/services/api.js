import axios from './axios';
import { useRouter } from 'vue-router';

function obterToken() {
    return localStorage.getItem('token');
}

function definirToken(token) {
    localStorage.setItem('token', token);
}

function removerToken() {
    localStorage.removeItem('token');
}

async function tratarResposta(resposta) {
    if (!resposta.ok) {
        const mensagem = await resposta.text();
        throw new Error(`Erro ${resposta.status}: ${mensagem}`);
    }
    return resposta.json();
}

export async function registrarUsuario({ nome, sobrenome, email, senha, saldo, image }) {
    try {
        const resposta = await axios.post('/usuarios/registrar', { nome, sobrenome, email, senha, saldoConta: saldo, userImage: image });
        return resposta.data;
    } catch (erro) {
        console.error('Erro ao registrar usuário:', erro.message);
        throw erro;
    }
}

export async function loginUsuario({ email, senha }) {
    const token = obterToken();
    if (token) {
        const router = useRouter(); // Certifique-se de ter o router disponível
        return router.push('/dashboard/inicio'); // Redireciona para o dashboard se o token já existir
    }
    
    try {
        const resposta = await axios.post('/usuarios/login', { email, senha });
        const dados = resposta.data;
        definirToken(dados.token);
        return dados;
    } catch (erro) {
        console.error('Erro ao fazer login:', erro.message);
        throw erro;
    }
}

export async function obterDadosUsuario() {
    const token = obterToken();
    if (!token) throw new Error('Usuário não autenticado.');

    try {
        const resposta = await axios.get('/usuarios/me', {
            headers: { 'Authorization': `Bearer ${token}` }
        });
        return resposta.data;
    } catch (erro) {
        if (erro.response && erro.response.status === 401) {
            removerToken(); // Remove o token se não estiver autenticado
            const router = useRouter();
            router.push('/login'); // Redireciona para a página de login
        }
        console.error('Erro ao obter dados do usuário:', erro.message);
        throw erro;
    }
}

export async function atualizarUsuario({ id, nome, sobrenome, email, saldo, senha, userImage }) {
    const token = obterToken();
    if (!token) throw new Error('Usuário não autenticado.');
  
    try {
        const resposta = await axios.put(`/usuarios/${id}`, {
            nome,
            sobrenome,
            email,
            saldoConta: saldo,
            senha: senha || '',
            userImage: userImage || ''
        }, {
            headers: { 'Authorization': `Bearer ${token}` }
        });
        return resposta.data;
    } catch (erro) {
        console.error('Erro ao atualizar usuário:', erro.message);
        throw erro;
    }
}
  
export async function excluirUsuario(id) {
    const token = obterToken();
    if (!token) throw new Error('Usuário não autenticado.');

    try {
        const resposta = await axios.delete(`/usuarios/${id}`, {
            headers: { 'Authorization': `Bearer ${token}` }
        });
        if (resposta.status === 204) {
            removerToken(); // Remove o token se o usuário for excluído
            return true;
        }
        return resposta.data;
    } catch (erro) {
        console.error('Erro ao excluir usuário:', erro.message);
        throw erro;
    }
}

export function logout() {
    removerToken();
}

// Funções de Produtos
export async function listarProdutos(pagina = 1, tamanhoPagina = 100) {
    const token = obterToken();
    if (!token) throw new Error('Usuário não autenticado.');

    try {
        const resposta = await axios.get(`/produtos?page=${pagina}&size=${tamanhoPagina}`, {
            headers: { 'Authorization': `Bearer ${token}` }
        });
        const dados = resposta.data;
        
        if (dados.totalPages > pagina) {
            const produtosRestantes = await listarProdutos(pagina + 1, tamanhoPagina);
            return {
                ...dados,
                produtos: [...dados.produtos, ...produtosRestantes.produtos]
            };
        }

        return dados;
    } catch (erro) {
        console.error('Erro ao listar produtos:', erro.message);
        throw erro;
    }
}

export async function adicionarProduto({ referencia, descricao, categoria, preco, status, image, usuarioId }) {
    const token = obterToken();
    if (!token) throw new Error('Usuário não autenticado.');

    try {
        const resposta = await axios.post('/produtos', { referencia, descricao, categoria, preco, status, image, usuarioId }, {
            headers: { 'Authorization': `Bearer ${token}` }
        });
        return resposta.data;
    } catch (erro) {
        console.error('Erro ao adicionar produto:', erro.message);
        throw erro;
    }
}

export async function atualizarProduto({ produtoId, referencia, descricao, categoria, preco, status, image }) {
    const token = obterToken();
    if (!token) throw new Error('Usuário não autenticado.');

    try {
        const resposta = await axios.put(`/produtos/${produtoId}`, { produtoId, referencia, descricao, categoria, preco, status, image }, {
            headers: { 'Authorization': `Bearer ${token}` }
        });
        return resposta.data;
    } catch (erro) {
        console.error('Erro ao atualizar produto:', erro.message);
        throw erro;
    }
}

export async function excluirProduto(produtoId) {
    const token = obterToken();
    if (!token) throw new Error('Usuário não autenticado.');

    try {
        const resposta = await axios.delete(`/produtos/${produtoId}`, {
            headers: { 'Authorization': `Bearer ${token}` }
        });
        if (resposta.status === 204) {
            return true;
        }
        return resposta.data;
    } catch (erro) {
        console.error('Erro ao excluir produto:', erro.message);
        throw erro;
    }
}
