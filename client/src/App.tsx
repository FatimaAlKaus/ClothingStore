import React from 'react';
import './App.css';
import { BrowserRouter as Router, Navigate, Route, Routes } from 'react-router-dom';
import { ThemeProvider } from '@mui/material/styles';

import { DetailedProductCard } from './components/ProductCard/DetailedProductCard/DetailedProductCard';
import { theme } from './theme/StyleTheme';
import { SearchBar } from './components/ProductCard/SearchBar/SearchBar';
import { ProdoductsPanel } from './components/ProductCard/ProductsPanel/ProductsPanel';

const App: React.FC = () => (
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

export default App;
