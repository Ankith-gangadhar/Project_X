import React, { useState, useEffect } from 'react';
import './EditProductForm.css';
import { createProduct } from '../../api/productApi';

const EditProductForm = ({ product, onUpdate, onCancel }) => {
  const [form, setForm] = useState({ name: '', wholesalePrice: '', mrp: '' });

  useEffect(() => {
    if (product) {
      setForm({
        name: product.name,
        wholesalePrice: product.wholesalePrice,
        mrp: product.mrp
      });
    }
  }, [product]);

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

  if (!product) return null;

  return (
    <form className="edit-product-form" onSubmit={handleSubmit}>
      <h2>Edit Product</h2>
      <input name="name" value={form.name} disabled />
      <input name="wholesalePrice" type="number" step="0.01" value={form.wholesalePrice} onChange={handleChange} required />
      <input name="rp" type="number" step="0.01" value={form.mrp} onChange={handleChange} required />
      <button type="submit">Update</button>
      <button type="button" onClick={onCancel}>Cancel</button>
    </form>
  );
};

export default EditProductForm;
