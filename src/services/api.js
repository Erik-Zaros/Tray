// src/services/apiService.js

const API_URL_USUARIOS = 'https://megev-affefxfrajedbqbw.brazilsouth-01.azurewebsites.net/usuarios';
const API_URL_PRODUTOS = 'https://megev-affefxfrajedbqbw.brazilsouth-01.azurewebsites.net/produtos';

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

// Funções de Usuário

export async function registrarUsuario({ nome, sobrenome, email, senha, saldo, image }) {
    try {
        const resposta = await fetch(`${API_URL_USUARIOS}/registrar`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({ nome, sobrenome, email, senha, saldoConta: saldo, userImage: image }),
        });
        return await tratarResposta(resposta);
    } catch (erro) {
        console.error('Erro ao registrar usuário:', erro.message);
        throw erro;
    }
}

export async function loginUsuario({ email, senha }) {
    try {
        const resposta = await fetch(`${API_URL_USUARIOS}/login`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({ email, senha }),
        });
        const dados = await tratarResposta(resposta);
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
        const resposta = await fetch(`${API_URL_USUARIOS}/me`, {
            method: 'GET',
            headers: {
                'Authorization': `Bearer ${token}`,
                'Content-Type': 'application/json',
            },
        });
        return await tratarResposta(resposta);
    } catch (erro) {
        console.error('Erro ao obter dados do usuário:', erro.message);
        throw erro;
    }
}

export async function atualizarUsuario({ id, nome, sobrenome, email, saldo }) {
    const token = obterToken();
    if (!token) throw new Error('Usuário não autenticado.');

    try {
        const resposta = await fetch(`${API_URL_USUARIOS}/${id}`, {
            method: 'PUT',
            headers: {
                'Authorization': `Bearer ${token}`,
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({ nome, sobrenome, email, saldoConta: saldo }),
        });
        return await tratarResposta(resposta);
    } catch (erro) {
        console.error('Erro ao atualizar usuário:', erro.message);
        throw erro;
    }
}

export async function excluirUsuario(id) {
    const token = obterToken();
    if (!token) throw new Error('Usuário não autenticado.');

    try {
        const resposta = await fetch(`${API_URL_USUARIOS}/${id}`, {
            method: 'DELETE',
            headers: {
                'Authorization': `Bearer ${token}`,
            },
        });
        if (resposta.ok) {
            removerToken();
            return true;
        }
        return await tratarResposta(resposta);
    } catch (erro) {
        console.error('Erro ao excluir usuário:', erro.message);
        throw erro;
    }
}

export function logout() {
    removerToken();
}

// Funções de Produtos
export async function listarProdutos() {
    const token = obterToken();
    if (!token) throw new Error('Usuário não autenticado.');

    try {
        const resposta = await fetch(API_URL_PRODUTOS, {
            method: 'GET',
            headers: {
                'Authorization': `Bearer ${token}`,
                'Content-Type': 'application/json' // Adicione o Content-Type se necessário
            }
        });

        if (!resposta.ok) {
            throw new Error(`Erro ${resposta.status}: ${resposta.statusText}`);
        }

        const dados = await resposta.json();
        return dados; // Certifique-se de que o formato de dados retornado está correto
    } catch (erro) {
        console.error('Erro ao listar produtos:', erro.message);
        throw erro;
    }
}

export async function adicionarProduto({ referencia, descricao, categoria, preco, status, image }) {
    const token = obterToken();
    if (!token) throw new Error('Usuário não autenticado.');

    try {
        const resposta = await fetch(API_URL_PRODUTOS, {
            method: 'POST',
            headers: {
                'Authorization': `Bearer ${token}`,
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ referencia, descricao, categoria, preco, status, image })
        });
        return await tratarResposta(resposta);
    } catch (erro) {
        console.error('Erro ao adicionar produto:', erro.message);
        throw erro;
    }
}

export async function atualizarProduto({ produtoId, referencia, descricao, categoria, preco, status, image }) {
    const token = obterToken();
    if (!token) throw new Error('Usuário não autenticado.');

    try {
        console.log('Atualizando produto com ID:', produtoId); 
        const resposta = await fetch(`${API_URL_PRODUTOS}/${produtoId}`, {
            method: 'PUT',
            headers: {
                'Authorization': `Bearer ${token}`,
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ referencia, descricao, categoria, preco, status, image })
        });
        return await tratarResposta(resposta);
    } catch (erro) {
        console.error('Erro ao atualizar produto:', erro.message);
        throw erro;
    }
}




export async function excluirProduto(produtoId) {
    const token = obterToken();
    if (!token) throw new Error('Usuário não autenticado.');

    try {
        const resposta = await fetch(`${API_URL_PRODUTOS}/${produtoId}`, {
            method: 'DELETE',
            headers: {
                'Authorization': `Bearer ${token}`
            }
        });

        if (resposta.ok) {
            // Resposta bem-sucedida, pode não ter conteúdo
            return true;
        } else {
            const mensagem = await resposta.text();
            // Verifique se a resposta possui um corpo
            if (mensagem) {
                // Se a resposta contém uma mensagem de erro, trate-a como JSON se necessário
                try {
                    return JSON.parse(mensagem);
                } catch (e) {
                    throw new Error(`Erro ${resposta.status}: ${mensagem}`);
                }
            } else {
                throw new Error(`Erro ${resposta.status}: Resposta vazia`);
            }
        }
    } catch (erro) {
        console.error('Erro ao excluir produto:', erro.message);
        throw erro;
    }
}
