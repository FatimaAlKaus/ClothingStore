import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import { Card, CardMedia, CardContent, Typography, CardActions, Checkbox } from '@mui/material';
import FavoriteIcon from '@mui/icons-material/Favorite';
import { ThemeProvider } from '@mui/material/styles';

import { ProductProps } from 'src/interfaces/ProductProps';
import { theme } from 'src/theme/StyleTheme';

import { useStyles } from './ProductCard.styles';

export const ProductCard: React.FC<ProductProps> = props => {
  const { id, productImage, price, name, clickEvent } = props;
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
        <Link to={`/products/${id}`}>
          <CardMedia onClick={clickEvent} height="600" component="img" image={productImage} />
        </Link>
        <CardContent sx={{ height: '70px' }}>
          <Link style={{ textDecoration: 'none', color: 'black' }} to={`/products/${id}`}>
            <Typography className={classes.text} variant="h5" onClick={clickEvent}>
              {name}
            </Typography>
          </Link>
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
