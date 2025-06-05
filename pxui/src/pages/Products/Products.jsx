import React, { useEffect, useState } from 'react';
import axios from 'axios';
import gsap from 'gsap';
import './Products.css'; // Import your CSS
import ProductList from '../../components/ProductList';

function Products() {
  const [products, setProducts] = useState([]);

  useEffect(() => {
    axios.get('http://localhost:5000/api/products') // Adjust URL as needed
      .then((res) => {
        setProducts(res.data);
      })
      .catch((err) => {
        console.error('Error fetching products:', err);
      });
  }, []);

  useEffect(() => {
    gsap.from('.product-card', {
      y: 50,
      opacity: 0,
      duration: 0.5,
      stagger: 0.2,
      ease: 'power3.out',
    });
  }, [products]);

  return (
    <div className="products-page">
      <h2 className="products-heading">Available Products</h2>
      <ProductList products={products} />
    </div>
  );
}

export default Products;
