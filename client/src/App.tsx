import React, { useEffect, useState } from 'react';
import './App.css';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import { ThemeProvider } from '@mui/material/styles';

import { DetailedProductCard } from './components/ProductCard/DetailedProductCard/DetailedProductCard';
import { requestApi } from './functions/RequestApi';
import { theme } from './theme/StyleTheme';
import { PagedResult } from './interfaces/PagedResult';
import { SearchBar } from './components/ProductCard/SearchBar/SearchBar';
import { ProdoductsPanel } from './components/ProductCard/ProductsPanel/ProductsPanel';

const App: React.FC = () => {
  const [products, setProducts] = useState<PagedResult>({ queryable: [] });

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
            <Route path="/products" element={<ProdoductsPanel />} />
            <Route path="/searchbar" element={<SearchBar />} />
          </Routes>
        </Router>
      </div>
    </ThemeProvider>
  );
};

export default App;
