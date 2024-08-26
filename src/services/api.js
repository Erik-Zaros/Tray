const API_URL = 'https://megev-affefxfrajedbqbw.brazilsouth-01.azurewebsites.net/usuarios';

export function obterToken() {
    return localStorage.getItem('token');
}

export function definirToken(token) {
    localStorage.setItem('token', token);
}

export function removerToken() {
    localStorage.removeItem('token');
}

export async function registrarUsuario({ nome, sobrenome, email, senha, saldo }) {
    try {
        const resposta = await fetch(`${API_URL}/registrar`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({ nome, sobrenome, email, senha, saldoConta: saldo }),
        });

        if (!resposta.ok) {
            const mensagem = await resposta.text();
            throw new Error(mensagem);
        }

        return await resposta.json();
    } catch (erro) {
        console.error('Erro ao registrar usuário:', erro.message);
        throw erro;
    }
}

export async function loginUsuario({ email, senha }) {
    try {
        const resposta = await fetch(`${API_URL}/login`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({ email, senha }),
        });

        if (!resposta.ok) {
            const mensagem = await resposta.text();
            throw new Error(mensagem);
        }

        const dados = await resposta.json();
        definirToken(dados.token); // Armazena o token usando a função definida
        return dados;
    } catch (erro) {
        console.error('Erro ao fazer login:', erro.message);
        throw erro;
    }
}

export async function obterDadosUsuario() {
    const token = obterToken();

    if (!token) {
        throw new Error('Usuário não autenticado.');
    }

    try {
        const resposta = await fetch(`${API_URL}/me`, {
            method: 'GET',
            headers: {
                'Authorization': `Bearer ${token}`,
                'Content-Type': 'application/json',
            },
        });

        if (!resposta.ok) {
            const erroTexto = await resposta.text();
            throw new Error(erroTexto);
        }

        return await resposta.json();
    } catch (erro) {
        console.error('Erro ao obter dados do usuário:', erro.message);
        throw erro;
    }
}

export async function atualizarUsuario({ id, nome, sobrenome, email, saldo }) {
    const token = obterToken();

    if (!token) {
        throw new Error('Usuário não autenticado.');
    }

    try {
        const resposta = await fetch(`${API_URL}/${id}`, {
            method: 'PUT',
            headers: {
                'Authorization': `Bearer ${token}`,
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({ nome, sobrenome, email, saldoConta: saldo }),
        });

        if (!resposta.ok) {
            const mensagem = await resposta.text();
            throw new Error(mensagem);
        }

        return await resposta.json();
    } catch (erro) {
        console.error('Erro ao atualizar usuário:', erro.message);
        throw erro;
    }
}

export async function excluirUsuario(id) {
    const token = obterToken();

    if (!token) {
        throw new Error('Usuário não autenticado.');
    }

    try {
        const resposta = await fetch(`${API_URL}/${id}`, {
            method: 'DELETE',
            headers: {
                'Authorization': `Bearer ${token}`,
            },
        });

        if (!resposta.ok) {
            const mensagem = await resposta.text();
            throw new Error(mensagem);
        }

        removerToken();
        return true;
    } catch (erro) {
        console.error('Erro ao excluir usuário:', erro.message);
        throw erro;
    }
}

export function logout() {
    removerToken();
}
