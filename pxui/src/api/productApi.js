import axios from 'axios';

const API_BASE_URL = 'http://localhost:5007/api/products'; 

export const getProducts = () => axios.get(API_BASE_URL);

export const getProductByName = (name) => axios.get(`${API_BASE_URL}/${name}`);

export const createProduct = (productData) => axios.post(API_BASE_URL, productData);

export const updateProduct = (productData) => axios.put(API_BASE_URL, productData);

export const deleteProduct = (name) => axios.delete(`${API_BASE_URL}/${name}`);
