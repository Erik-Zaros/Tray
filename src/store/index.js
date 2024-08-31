// src/store/index.js
import { createStore } from 'vuex';

export default createStore({
  state() {
    return {
      carregando: false
    };
  },
  mutations: {
    ativarCarregamento(state) {
      state.carregando = true;
    },
    desativarCarregamento(state) {
      state.carregando = false;
    }
  },
  actions: {
    ativarCarregamento({ commit }) {
      commit('ativarCarregamento');
    },
    desativarCarregamento({ commit }) {
      commit('desativarCarregamento');
    }
  },
  getters: {
    carregando(state) {
      return state.carregando;
    }
  }
});
