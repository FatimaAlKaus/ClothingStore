import { Image } from '@mui/icons-material';
import {
  Button,
  Container,
  FormControl,
  Grid,
  InputLabel,
  MenuItem,
  Paper,
  Select,
  Stack,
  ThemeProvider,
  Typography,
  Box,
  ImageList,
  ImageListItem,
} from '@mui/material';
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

  const [size, setSize] = useState('');
  useEffect(() => {
    (async () => {
      await getProductInfo();
    })();
  }, []);
  return (
    <ThemeProvider theme={theme}>
      <Grid spacing={1} container columns={{ xs: 12, md: 12 }}>
        <Grid item md={3} xs={6}>
          <img
            style={{ maxWidth: '100%', minWidth: '50%', height: 'auto' }}
            src={`${config.productPhotoFolder}${product?.productImage}`}
          />
        </Grid>
        <Grid md={3} xs={6} item>
          <img
            style={{ maxWidth: '100%', minWidth: '50%', height: 'auto' }}
            src={`${config.productPhotoFolder}${product?.productImage}`}
          />
        </Grid>
        <Grid item xs={6} md={6}>
          <Stack spacing={2}>
            <Typography variant="h3" className={classes.title}>
              {product?.name}
              <Typography variant="h5" className={classes.price}>
                {product?.price} Руб
              </Typography>
            </Typography>
            <Typography variant="body1">{product?.description}</Typography>
            <Box sx={{ minWidth: 120, maxWidth: 200 }}>
              <FormControl variant="filled" fullWidth>
                <InputLabel>Размер</InputLabel>
                <Select value={size} label="Size" onChange={e => setSize(e.target.value)}>
                  <MenuItem value={1}>XS</MenuItem>
                  <MenuItem value={2}>S</MenuItem>
                  <MenuItem value={3}>M</MenuItem>
                  <MenuItem value={4}>L</MenuItem>
                  <MenuItem value={5}>XL</MenuItem>
                  <MenuItem value={6}>XL</MenuItem>
                  <MenuItem value={7}>XXL</MenuItem>
                  <MenuItem value={8}>XS/S</MenuItem>
                  <MenuItem value={9}>S/S</MenuItem>
                  <MenuItem value={10}>M/S</MenuItem>
                  <MenuItem value={11}>L/S</MenuItem>
                  <MenuItem value={12}>XL/S</MenuItem>
                  <MenuItem value={13}>XXL/S</MenuItem>
                </Select>
              </FormControl>
            </Box>
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
