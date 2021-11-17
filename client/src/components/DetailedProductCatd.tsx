import React from 'react';
import { Card, CardMedia, CardContent, Typography, CardActions, Fab } from '@mui/material';

import { IDetailedProduct } from 'src/interfaces/ProductProps';

export const DetailedProductCard = (props: IDetailedProduct) => (
  <Card>
    <CardContent>{props.name}</CardContent>
  </Card>
);
