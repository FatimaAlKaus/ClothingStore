import React, { useEffect, useState } from 'react';
import './App.css';
import { BrowserRouter as Router, Navigate, Route, Routes } from 'react-router-dom';
import { ThemeProvider } from '@mui/material/styles';

import { ProductProps } from './interfaces/ProductProps';
import { ProductList } from './components/ProductCard/ProductList';
import { DetailedProductCard } from './components/ProductCard/DetailedProductCard/DetailedProductCard';
import { requestApi } from './functions/RequestApi';
import { theme } from './theme/StyleTheme';

const App: React.FC = () => {
  const [productCards, setProducts] = useState<ProductProps[]>([]);

  const getProducts = async () => {
    const result = await requestApi('/products');
    console.log(result);
    setProducts(result);
  };
  useEffect(() => {
    (async () => {
      await getProducts();
    })();
  }, []);

  return (
    <ThemeProvider theme={theme}>
      <div className="App">
        <Router>
          <Routes>
            <Route path="" element={<Navigate to="/products" />} />
            <Route path="/products/:idProduct" element={<DetailedProductCard />} />
            <Route path="/products" element={<ProductList cards={productCards} />} />
          </Routes>
        </Router>
      </div>
    </ThemeProvider>
  );
};

export default App;
