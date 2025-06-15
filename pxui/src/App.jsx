import React from 'react';
import { BrowserRouter as Router, Routes, Route, Link } from 'react-router-dom';
import Home from './pages/Home/Home';
import Products from './pages/Products/Products';

const App = () => (
  <Router>
    <nav>
      <Link to="/">Home</Link>
      <Link to="/products">Products</Link>
    </nav>
    <Routes>
      <Route path="/" element={<Home />} />
      <Route path="/products" element={<Products />} />
    </Routes>
  </Router>
);

export default App;
