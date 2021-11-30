import React, { useEffect, useState } from 'react';
import './App.css';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';

import { ProductProps } from './interfaces/ProductProps';
import { ProductList } from './components/ProductCard/ProductList';
import { requestApi } from './functions/RequestApi';

const App: React.FC = () => {
  const [productCards, setProducts] = useState<ProductProps[]>([]);

  const getProducts = async () => {
    const result = await requestApi('/products');
    setProducts(result);
  };
  useEffect(() => {
    (async () => {
      await getProducts();
    })();
  }, []);

  return (
    <div className="App">
      <Router>
        <Routes>
          <Route path="/products" element={<ProductList cards={productCards} />} />
        </Routes>
      </Router>
    </div>
  );
};

export default App;
