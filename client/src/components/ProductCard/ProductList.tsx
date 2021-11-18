import React from 'react';
import { Stack } from '@mui/material';

import { ProductArrayProps } from 'src/interfaces/ProductArrayProp';

import { ProductCard } from './ProductCard';

export const ProductList: React.FC<ProductArrayProps> = props => {
  const { items } = props;
  return (
    <Stack flexWrap="wrap" direction="row">
      {items.map(x => (
        <ProductCard key={x.id} name={x.name} price={x.price} imgPath={x.imgPath} id={x.id} />
      ))}
    </Stack>
  );
};
