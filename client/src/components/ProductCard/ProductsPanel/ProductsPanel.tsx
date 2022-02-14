import React, { useState, useEffect } from 'react';
import { Pagination } from '@mui/material';

import { SearchBar } from 'src/components/ProductCard/SearchBar/SearchBar';
import { Orentation, ProductList } from 'src/components/ProductCard/ProductList';
import { ProductProps } from 'src/interfaces/ProductProps';
import { getProducts } from 'src/functions/RequestApi';
import { useStyles } from 'src/components/ProductCard/ProductsPanel/ProductsPanel.styles';

export const ProdoductsPanel: React.FC = () => {
  const [products, setProducts] = useState<ProductProps[]>([]);
  const [pageCount, setPageCount] = useState<number>();
  const [filter, setFilter] = useState<string>();
  const [currentPage, setCurrentPage] = useState<number>(1);

  const defaultPageSize = 8;
  const classes = useStyles();
  console.log('render');

  useEffect(() => {
    (async () => {
      const response = await getProducts(currentPage, defaultPageSize, filterByName(filter));
      setProducts(response.queryable);
      setPageCount(response.pageCount);
    })();
  }, [filter, currentPage]);

  const filterByName = (str?: string) => (str === undefined ? str : `name.contains("${str}")`);
  const searchHandler = async (text: string) => {
    setCurrentPage(1);
    setFilter(text);
  };
  const clearFilter = async () => {
    setCurrentPage(1);
    setFilter(undefined);
  };
  const pageChangeHandler = async (_: unknown, number: number) => {
    setCurrentPage(number);
  };
  return (
    <>
      <div>
        <SearchBar onFind={searchHandler} onClear={clearFilter} />
        <ProductList orentation={Orentation.center} cards={products} />
      </div>
      {products.length !== 0 ? (
        <Pagination
          page={currentPage}
          onChange={pageChangeHandler}
          shape="rounded"
          className={classes.pagination}
          count={pageCount}
        />
      ) : (
        <></>
      )}
    </>
  );
};
