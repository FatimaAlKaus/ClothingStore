import React from 'react';
import { Grid } from '@mui/material';

import { ProductProps } from 'src/interfaces/ProductProps';

import { ProductCard } from './ProductCard';

export const ProductList = ({ cards }: { cards: ProductProps[] }) => (
  <Grid container spacing={{ xs: 1 }} columns={{ xs: 1, sm: 8, md: 12 }}>
    {cards.map(x => (
      <Grid item xs={2} sm={4} md={3} key={`Grid_${x.id}`}>
        <ProductCard key={x.id} name={x.name} price={x.price} imgPath={x.imgPath} id={x.id} />
      </Grid>
    ))}
  </Grid>
);
