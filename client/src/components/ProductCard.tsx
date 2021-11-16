import React from 'react';
import { Card, CardMedia, CardContent, Typography, CardActions, Fab } from '@mui/material';
import FavoriteIcon from '@mui/icons-material/Favorite';

import { ProductProps } from 'src/interfaces/ProductProps';

import { useStyles } from './ProductCard.styles';

export const ProductCard: React.FC<ProductProps> = props => {
  const classes = useStyles();
  return (
    <Card className={classes.root}>
      <CardMedia component="img" image={props.imgPath} />
      <CardContent>
        <Typography variant="h5">{props.name}</Typography>
        <Typography variant="body2">{props.price} Руб</Typography>
      </CardContent>
      <CardActions className={classes.favoriteButton}>
        <FavoriteIcon />
      </CardActions>
    </Card>
  );
};
