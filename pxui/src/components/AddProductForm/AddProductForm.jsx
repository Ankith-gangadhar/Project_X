import React, { useState } from 'react';
import './AddProductForm.css';
import { createProduct } from '../../api/productApi';

const AddProductForm = ({ onAdd }) => {
  const [form, setForm] = useState({ name: '', wholesalePrice: '', mrp: '' });

  const handleChange = e => {
    setForm({ ...form, [e.target.name]: e.target.value });
  };

const handleSubmit = async (e) => {
  e.preventDefault();
  const product = {
    name: form.name,
    wholesalePrice: parseFloat(form.wholesalePrice),
    mrp: parseFloat(form.mrp)
  };
  try {
    await createProduct(product);
  } catch (error) {
    console.error('Failed to add product', error);
  }
};


  return (
    <form className="add-product-form" onSubmit={handleSubmit}>
      <h2>Add Product</h2>
      <input name="name" placeholder="Name" value={form.name} onChange={handleChange} required />
      <input name="wholesalePrice" type="number" step="0.01" placeholder="Wholesale Price" value={form.wholesalePrice} onChange={handleChange} required />
      <input name="mrp" type="number" step="0.01" placeholder="MRP" value={form.mrp} onChange={handleChange} required />
      <button type="submit">Add</button>
    </form>
  );
};

export default AddProductForm;
