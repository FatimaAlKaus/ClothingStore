import React, { useState } from 'react';
import { Card, CardMedia, CardContent, Typography, CardActions, Checkbox } from '@mui/material';
import FavoriteIcon from '@mui/icons-material/Favorite';
import { ThemeProvider } from '@mui/material/styles';

import { ProductProps } from 'src/interfaces/ProductProps';
import { theme } from 'src/theme/StyleTheme';

import { useStyles } from './ProductCard.styles';

export const ProductCard: React.FC<ProductProps> = props => {
  const { productImage, price, name } = props;
  const classes = useStyles();
  const [isFollow, setFollow] = useState(false);
  const [raised, setRaised] = useState(false);
  return (
    <ThemeProvider theme={theme}>
      <Card
        className={classes.root}
        onMouseOver={() => setRaised(true)}
        onMouseOut={() => setRaised(false)}
        raised={raised}
      >
        <CardMedia height="600" component="img" src={productImage} />
        <CardContent sx={{ height: '70px' }}>
          <Typography variant="h5">{name}</Typography>
          <Typography variant="inherit" sx={{ fontWeight: 'bold' }}>
            {price} Руб
          </Typography>
        </CardContent>
        <CardActions>
          <Checkbox
            onClick={() => {
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
