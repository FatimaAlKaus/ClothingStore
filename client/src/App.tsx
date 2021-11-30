import React, { useEffect, useState } from 'react';

import './App.css';

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
      <ProductList cards={productCards} />
    </div>
  );
};

export default App;
