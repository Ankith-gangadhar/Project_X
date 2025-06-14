import React, { useEffect, useState } from 'react';
import { fetchProducts, addProduct, updateProduct, deleteProduct } from '../../api/productApi';
import ProductList from '../../components/ProductList/ProductList';
import AddProductForm from '../../components/AddProductForm/AddProductForm';
import EditProductForm from '../../components/EditProductForm/EditProductForm';
import './Products.css';

const Products = () => {
  const [products, setProducts] = useState([]);
  const [editingProduct, setEditingProduct] = useState(null);

  const loadProducts = async () => {
    const res = await fetchProducts();
    setProducts(res.data);
  };

  useEffect(() => {
    loadProducts();
  }, []);

  const handleAdd = async (product) => {
    await addProduct(product);
    loadProducts();
  };

  const handleEdit = (product) => {
    setEditingProduct(product);
  };

  const handleUpdate = async (product) => {
    await updateProduct(product);
    setEditingProduct(null);
    loadProducts();
  };

  const handleDelete = async (name) => {
    await deleteProduct(name);
    loadProducts();
  };

  const handleCancelEdit = () => setEditingProduct(null);

  return (
    <div className="products-page">
      <AddProductForm onAdd={handleAdd} />
      {editingProduct && (
        <EditProductForm
          product={editingProduct}
          onUpdate={handleUpdate}
          onCancel={handleCancelEdit}
        />
      )}
      <ProductList products={products} onEdit={handleEdit} onDelete={handleDelete} />
    </div>
  );
};

export default Products;
