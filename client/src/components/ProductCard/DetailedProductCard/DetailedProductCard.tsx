import { Button, Grid, Typography, useMediaQuery } from '@mui/material';
import CartIcon from '@mui/icons-material/ShoppingBag';
import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';

import { requestApi } from 'src/functions/RequestApi';
import { ProductProps } from 'src/interfaces/ProductProps';
import { theme } from 'src/theme/StyleTheme';

import { useStyles } from './DetailedProductCard.styles';
import { PhotoPicker } from './PhotoPicker';
import { PreviewPhotos } from './PreviewPhotos';
import { SizeSelector } from './SizeSelector';

export const DetailedProductCard = () => {
  const { idProduct } = useParams<string>();
  const [product, setProduct] = useState<ProductProps>();
  const isBiggerMd = useMediaQuery(theme.breakpoints.up('md'));
  const isBiggerLg = useMediaQuery(theme.breakpoints.up('lg'));
  const [photo, setPhoto] = useState<string>();
  const [photoIndex, setPhotoIndex] = useState(0);
  const classes = useStyles(theme);
  const getProductInfo = async () => {
    setProduct(await requestApi(`/products/${idProduct}`));
  };
  const options = { style: 'currency', currency: 'RUB' };
  const numberFormat = new Intl.NumberFormat('ru-RU', options);
  useEffect(() => {
    (async () => {
      await getProductInfo();
    })();
  }, []);
  useEffect(() => {
    setPhoto(product?.photos?.[0]);
    setPhotoIndex(0);
  }, [product]);
  useEffect(() => {
    setPhoto(product?.photos?.[photoIndex]);
  }, [photoIndex]);
  const [size, setSize] = useState(0);
  const sizes = [
    { id: 0, label: 'XL' },
    { id: 1, label: 'M' },
    { id: 2, label: 'L' },
    { id: 3, label: 'XXL' },
  ];
  return (
    <Grid padding={2} spacing={{ xs: 1, md: 0 }} container columns={{ xs: 12, md: 12 }}>
      <Grid item md={8} xs={12} order={{ md: 1, xs: 2 }}>
        <PreviewPhotos
          spacing={1}
          callBack={index => {
            console.log(index);
          }}
          photos={isBiggerMd ? [photo, photo] : [photo]}
        />
      </Grid>
      <Grid item md={0.2} xs={0} order={{ md: 2 }} />
      <Grid item md={3.8} xs={12} order={{ md: 3, xs: 1 }}>
        <Grid position="sticky" top={0} spacing={3} container xs={12}>
          {isBiggerMd ? (
            <>
              <Grid item xs={12}>
                <Typography textAlign={{ md: 'left' }} variant={'h4'}>
                  {product?.name}
                </Typography>
              </Grid>
            </>
          ) : (
            <></>
          )}
          {isBiggerMd ? (
            <>
              <Grid item xs={12}>
                <Typography textAlign={{ md: 'left', xs: 'center' }} variant="h5">
                  {numberFormat.format(Number(product?.price))}
                </Typography>
              </Grid>
            </>
          ) : (
            <></>
          )}
          {isBiggerMd ? (
            <>
              <Grid item xs={12}>
                <PhotoPicker
                  index={photoIndex}
                  callBack={index => {
                    setPhotoIndex(index);
                  }}
                  columns={isBiggerLg ? 5 : 4}
                  selectable
                  photos={product?.photos ?? []}
                />
              </Grid>
            </>
          ) : (
            <></>
          )}
          {isBiggerMd ? (
            <>
              <Grid item xs={12}>
                <Grid container spacing={3} order={5}>
                  <Grid item xs={12}>
                    <SizeSelector
                      index={size}
                      sx={{ height: '50px' }}
                      title="Размер"
                      onChange={e => setSize(e)}
                      sizes={sizes}
                    />
                  </Grid>
                  <Grid item xs={12}>
                    <Button sx={{ width: '100%' }} variant="contained" startIcon={<CartIcon />}>
                      Добавить
                    </Button>
                  </Grid>
                </Grid>{' '}
              </Grid>
            </>
          ) : (
            <></>
          )}
        </Grid>
      </Grid>
      {!isBiggerMd ? (
        <>
          <Grid item xs={12} order={4}>
            <PhotoPicker
              index={photoIndex}
              callBack={index => {
                setPhotoIndex(index);
              }}
              selectable
              photos={product?.photos ?? []}
            />
          </Grid>
        </>
      ) : (
        <></>
      )}
      <Grid item xs={12} md={8} order={5}>
        <Typography align="left" variant="h6">
          {product?.description}
        </Typography>
      </Grid>
      {!isBiggerMd ? (
        <>
          <Grid
            sx={{ backgroundColor: '#eee' }}
            top={0}
            padding={2}
            spacing={0.5}
            container
            columns={12}
            position="sticky"
          >
            <Grid item xs={12}>
              <Typography textAlign="left" variant={'h5'}>
                {product?.name}
              </Typography>
            </Grid>
            <Grid item xs={12}>
              <Typography textAlign="left" variant="h6">
                {numberFormat.format(Number(product?.price))}
              </Typography>
            </Grid>
            <Grid item xs={6}>
              <SizeSelector title="Размер" index={size} onChange={e => setSize(e)} sizes={sizes} />
            </Grid>
            <Grid item xs={6}>
              <Button sx={{ width: '100%', height: '100%' }} variant="contained" startIcon={<CartIcon />}>
                Добавить
              </Button>
            </Grid>
          </Grid>
        </>
      ) : (
        <></>
      )}
    </Grid>
  );
};
