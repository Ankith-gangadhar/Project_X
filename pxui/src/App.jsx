import Home from './pages/Home';
import './App.css'

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<Home />} />
        {/* Add more routes like below when needed */}
        {/* <Route path="/products" element={<ProductList />} /> */}
      </Routes>
    </Router>
  );
}

export default App
