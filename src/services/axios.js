// src/services/axios.js
import axios from 'axios';
import store from '../store';

const instance = axios.create({
  baseURL: 'https://megev-affefxfrajedbqbw.brazilsouth-01.azurewebsites.net', 
  headers: {
    'Content-Type': 'application/json'
  }
});

instance.interceptors.request.use((config) => {
  store.dispatch('ativarCarregamento');
  return config;
}, (error) => {
  store.dispatch('desativarCarregamento');
  return Promise.reject(error);
});

instance.interceptors.response.use((response) => {
  store.dispatch('desativarCarregamento');
  return response;
}, (error) => {
  store.dispatch('desativarCarregamento');
  return Promise.reject(error);
});

export default instance;
