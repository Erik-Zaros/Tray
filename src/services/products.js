// api.js

const API_URL = 'https://megev-affefxfrajedbqbw.brazilsouth-01.azurewebsites.net';

function obterToken() {
    return localStorage.getItem('token');
}

async function listarProdutos() {
    const token = obterToken();

    if (!token) {
        throw new Error('Usuário não autenticado.');
    }

    try {
        const resposta = await fetch(`${API_URL}/produtos`, {
            method: 'GET',
            headers: {
                'Authorization': `Bearer ${token}`
            }
        });

        if (!resposta.ok) {
            const erroTexto = await resposta.text();
            throw new Error(`Erro ${resposta.status}: ${erroTexto}`);
        }

        return await resposta.json();
    } catch (erro) {
        console.error('Erro ao listar produtos:', erro.message);
        throw erro;
    }
}

async function adicionarProduto(produto) {
    const token = obterToken();

    if (!token) {
        throw new Error('Usuário não autenticado.');
    }

    try {
        const resposta = await fetch(`${API_URL}/produtos`, {
            method: 'POST',
            headers: {
                'Authorization': `Bearer ${token}`,
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(produto)
        });

        if (!resposta.ok) {
            const erroTexto = await resposta.text();
            throw new Error(`Erro ${resposta.status}: ${erroTexto}`);
        }

        return await resposta.json();
    } catch (erro) {
        console.error('Erro ao adicionar produto:', erro.message);
        throw erro;
    }
}

async function atualizarProduto(id, produto) {
    const token = obterToken();

    if (!token) {
        throw new Error('Usuário não autenticado.');
    }

    try {
        const resposta = await fetch(`${API_URL}/produtos/${id}`, {
            method: 'PUT',
            headers: {
                'Authorization': `Bearer ${token}`,
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(produto)
        });

        if (!resposta.ok) {
            const erroTexto = await resposta.text();
            throw new Error(`Erro ${resposta.status}: ${erroTexto}`);
        }

        return await resposta.json();
    } catch (erro) {
        console.error('Erro ao atualizar produto:', erro.message);
        throw erro;
    }
}

async function excluirProduto(id) {
    const token = obterToken();

    if (!token) {
        throw new Error('Usuário não autenticado.');
    }

    try {
        const resposta = await fetch(`${API_URL}/produtos/${id}`, {
            method: 'DELETE',
            headers: {
                'Authorization': `Bearer ${token}`
            }
        });

        if (!resposta.ok) {
            const erroTexto = await resposta.text();
            throw new Error(`Erro ${resposta.status}: ${erroTexto}`);
        }
    } catch (erro) {
        console.error('Erro ao excluir produto:', erro.message);
        throw erro;
    }
}

export { listarProdutos, adicionarProduto, atualizarProduto, excluirProduto };
