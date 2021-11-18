import React from 'react';
import { Card, CardMedia, CardContent, Typography, CardActions, Checkbox } from '@mui/material';
import FavoriteIcon from '@mui/icons-material/Favorite';
import { ThemeProvider } from '@mui/material/styles';

import { ProductProps } from 'src/interfaces/ProductProps';
import { theme } from 'src/theme/StyleTheme';

import { useStyles } from './ProductCard.styles';

export const ProductCard: React.FC<ProductProps> = props => {
  const classes = useStyles();
  return (
    <ThemeProvider theme={theme}>
      <Card className={classes.root}>
        <CardMedia component="img" image={props.imgPath} />
        <CardContent>
          <Typography variant="h5">{props.name}</Typography>
          <Typography variant="inherit">{props.price} Руб</Typography>
        </CardContent>
        <CardActions>
          <Checkbox
            className={classes.favoriteButton}
            checkedIcon={<FavoriteIcon color="primary" />}
            icon={<FavoriteIcon color="secondary" />}
          />
        </CardActions>
      </Card>
    </ThemeProvider>
  );
};
