import { Image } from '@mui/icons-material';
import { Button, Container, Grid, Paper, Stack, ThemeProvider, Typography } from '@mui/material';
import CartIcon from '@mui/icons-material/ShoppingBag';
import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';

import { config } from 'src/config';
import { requestApi } from 'src/functions/RequestApi';
import { ProductProps } from 'src/interfaces/ProductProps';
import { theme } from 'src/theme/StyleTheme';

import { useStyles } from './DetailedProductCard.styles';

export const DetailedProductCard = () => {
  const { idProduct } = useParams<string>();
  const [product, setProduct] = useState<ProductProps>();
  const classes = useStyles(theme);
  const getProductInfo = async () => {
    setProduct(await requestApi(`/products/${idProduct}`));
  };

  useEffect(() => {
    (async () => {
      await getProductInfo();
    })();
  }, []);
  return (
    <ThemeProvider theme={theme}>
      <Grid spacing={{ xs: 2 }} container columns={{ xs: 12 }}>
        <Grid item xs={5}>
          <img style={{ margin: '10px', width: '100%' }} src={`${config.productPhotoFolder}${product?.productImage}`} />
        </Grid>
        <Grid item xs={6}>
          <Stack spacing={1} direction="column">
            <Typography variant="h3" className={classes.title}>
              {product?.name}
              <Typography variant="h5" className={classes.price}>
                {product?.price} Руб
              </Typography>
            </Typography>
            <Typography variant="body1">{product?.description}</Typography>
            <Container>
              <Button sx={{ maxWidth: '300px' }} startIcon={<CartIcon />} variant="contained">
                Добавить
              </Button>
            </Container>
          </Stack>
        </Grid>
      </Grid>
    </ThemeProvider>
  );
};
