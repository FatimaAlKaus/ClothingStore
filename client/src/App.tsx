import React, { useEffect, useState } from 'react';

import './App.css';
import { ProductList } from './components/ProductCard/ProductList';
import { requestApi } from './functions/RequestApi';
import { ProductArrayProps } from './interfaces/ProductArrayProp';
import { ProductProps } from './interfaces/ProductProps';

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
      <ProductList items={productCards} />
    </div>
  );
};

export default App;
