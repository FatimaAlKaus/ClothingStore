import React, { useEffect, useState } from 'react';
import './App.css';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import { ThemeProvider } from '@mui/material/styles';

import { ProductProps } from './interfaces/ProductProps';
import { ProductList } from './components/ProductCard/ProductList';
import { DetailedProductCard } from './components/ProductCard/DetailedProductCard/DetailedProductCard';
import { requestApi } from './functions/RequestApi';
import { theme } from './theme/StyleTheme';
import { AdminPanel } from './components/Admin/AdminPanel';

const App: React.FC = () => {
  const [productProps, setProducts] = useState<ProductProps[]>([]);

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
    <ThemeProvider theme={theme}>
      <div className="App">
        <Router>
          <Routes>
            <Route path="/products/:idProduct" element={<DetailedProductCard />} />
            <Route path="/products" element={<ProductList cards={productProps} />} />
            <Route path="/admin" element={<AdminPanel />} />
          </Routes>
        </Router>
      </div>
    </ThemeProvider>
  );
};

export default App;
