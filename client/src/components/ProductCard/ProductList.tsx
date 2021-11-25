import React from 'react';
import { Stack } from '@mui/material';

import { ProductArrayProps } from 'src/interfaces/ProductArrayProp';
import { ProductProps } from 'src/interfaces/ProductProps';
import { config } from 'src/config';

import { ProductCard } from './ProductCard';

export const ProductList = ({ items }: { items: ProductProps[] }) => (
  <Stack flexWrap="wrap" direction="row">
    {items.map(x => (
      <ProductCard
        key={x.id}
        name={x.name}
        price={x.price}
        productImage={`${config['productPhotoFolder']}\\${x.productImage}`}
        id={x.id}
      />
    ))}
  </Stack>
);
