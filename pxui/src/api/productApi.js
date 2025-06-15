import axios from 'axios';

const BASE_URL = 'https://localhost:5007/api/products'; 
export const fetchProducts = () => axios.get(BASE_URL);

export const fetchProductByName = (name) => axios.get(`${BASE_URL}/${encodeURIComponent(name)}`);

export const addProduct = (product) => axios.post(BASE_URL, product);

export const updateProduct = (product) => axios.put(BASE_URL, product);

export const deleteProduct = (name) => axios.delete(`${BASE_URL}/${encodeURIComponent(name)}`);
