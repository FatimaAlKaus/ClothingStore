import React, { useState, useEffect, useRef } from 'react';

import { SearchBar } from 'src/components/ProductCard/SearchBar/SearchBar';
import { ProductList } from 'src/components/ProductCard/ProductList';
import { ProductProps } from 'src/interfaces/ProductProps';
import { getAllProducts } from 'src/functions/RequestApi';

export const ProdoductsPanel: React.FC = () => {
  const [products, setProducts] = useState<ProductProps[]>([]);
  useEffect(() => {
    (async () => {
      setProducts(await getAllProducts());
    })();
  }, []);
  const searchHandler = async (text: string) => {
    const allProducts = await getAllProducts();
    const result =
      text === '' ? allProducts : allProducts.filter(x => x.name.toLowerCase().includes(text.toLowerCase()));
    setProducts(result);
  };
  const clearFilter = async () => {
    setProducts(await getAllProducts());
  };
  return (
    <div style={{ textAlign: 'right' }}>
      <SearchBar onFind={searchHandler} onClear={clearFilter} sx={{ margin: '10px' }} />
      <ProductList cards={products} />
    </div>
  );
};
