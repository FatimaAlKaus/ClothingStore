import React, { useState, useEffect, useRef } from 'react';

import { SearchBar } from 'src/components/ProductCard/SearchBar/SearchBar';
import { ProductList } from 'src/components/ProductCard/ProductList';
import { ProductProps } from 'src/interfaces/ProductProps';

interface ProductsPanelProps {
  products: ProductProps[];
}
export const ProdoductsPanel: React.FC<ProductsPanelProps> = ({ products }) => {
  const [displayedProducts, setDisplayedProducts] = useState<ProductProps[]>([]);
  const allProducts = useRef(products);
  useEffect(() => {
    setDisplayedProducts(products);
    allProducts.current = products;
  }, [products]);
  const searchHandler = (text: string) => {
    const result =
      text === ''
        ? allProducts.current
        : allProducts.current.filter(x => x.name.toLowerCase().includes(text.toLowerCase()));
    setDisplayedProducts(result);
  };
  const clearFilter = () => {
    setDisplayedProducts(allProducts.current);
  };
  return (
    <div style={{ textAlign: 'right' }}>
      <SearchBar onTextChanged={searchHandler} onClear={clearFilter} sx={{ margin: '10px' }} />
      <ProductList cards={displayedProducts} />
    </div>
  );
};
