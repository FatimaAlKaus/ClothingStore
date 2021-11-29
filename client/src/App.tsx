import React, { useEffect, useState } from 'react';

import './App.css';
import { DetailedProductCard } from './components/DetailedProductCatd';

import { ProductProps } from './interfaces/ProductProps';
import { ProductList } from './components/ProductCard/ProductList';

const App: React.FC = () => {
  const [productCards, setProducts] = useState<ProductProps[]>([]);

  const getProducts = async () => {
    const result = await (await fetch(`http://localhost:5000/api/products`)).json();
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
