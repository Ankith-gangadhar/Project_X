import React from 'react';
import './ProductList.css';

const ProductList = ({ products, onEdit, onDelete }) => (
  <div className="product-list">
    <h2>Product List</h2>
    <table>
      <thead>
        <tr>
          <th>Name</th>
          <th>Wholesale Price</th>
          <th>MRP</th>
          <th>Profit/Unit</th>
          <th>Profit %</th>
          <th>Actions</th>
        </tr>
      </thead>
      <tbody>
        {products.map(product => (
          <tr key={product.name}>
            <td>{product.name}</td>
            <td>{product.wholesalePrice}</td>
            <td>{product.mrp}</td>
            <td>{product.profitPerUnit}</td>
            <td>{product.profitPercentage.toFixed(2)}%</td>
            <td>
              <button onClick={() => onEdit(product)}>Edit</button>
              <button onClick={() => onDelete(product.name)}>Delete</button>
            </td>
          </tr>
        ))}
      </tbody>
    </table>
  </div>
);

export default ProductList;
