import React from 'react';
import { Grid } from '@mui/material';

import { ProductProps } from 'src/interfaces/ProductProps';

import { ProductCard } from './ProductCard';

export enum Orentation {
  start = 'start',
  end = 'end',
  center = 'center',
}

export const ProductList = ({ cards, orentation }: { cards: ProductProps[]; orentation?: Orentation }) => (
  <Grid
    container
    spacing={{ xs: 1, md: 1.5 }}
    columns={{ xs: 1, sm: 8, md: 12 }}
    sx={{ justifyContent: orentation?.toString() }}
  >
    {console.log(orentation)}
    {cards.map(x => (
      <Grid item xs={2} sm={4} md={3} key={`Grid_${x.id}`}>
        <ProductCard key={x.id} name={x.name} price={x.price} productImage={x.productImage} id={x.id} />
      </Grid>
    ))}
  </Grid>
);
