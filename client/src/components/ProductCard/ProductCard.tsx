import React, { useState } from 'react';
import { Card, CardMedia, CardContent, Typography, CardActions, Checkbox } from '@mui/material';
import FavoriteIcon from '@mui/icons-material/Favorite';
import { ThemeProvider } from '@mui/material/styles';

import { ProductProps } from 'src/interfaces/ProductProps';
import { theme } from 'src/theme/StyleTheme';

import { useStyles } from './ProductCard.styles';

export const ProductCard: React.FC<ProductProps> = props => {
  const { imgPath, price, name } = props;
  const classes = useStyles();
  const [isFollow, setFollow] = useState(false);
  return (
    <ThemeProvider theme={theme}>
      <Card className={classes.root}>
        <CardMedia height="400" component="img" image={imgPath} />
        <CardContent sx={{ height: '70px' }}>
          <Typography variant="h5">{name}</Typography>
          <Typography variant="inherit" sx={{ fontWeight: 'bold' }}>
            {price} Руб
          </Typography>
        </CardContent>
        <CardActions>
          <Checkbox
            onClick={e => {
              setFollow(!isFollow);
            }}
            className={classes.favoriteButton}
            checkedIcon={<FavoriteIcon color="primary" />}
            icon={<FavoriteIcon color="secondary" />}
          />
        </CardActions>
      </Card>
    </ThemeProvider>
  );
};
