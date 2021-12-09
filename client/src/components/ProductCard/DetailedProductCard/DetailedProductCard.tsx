import {
  Button,
  FormControl,
  Grid,
  InputLabel,
  MenuItem,
  Select,
  Typography,
  Box,
  Theme,
  Container,
  useMediaQuery,
} from '@mui/material';
import CartIcon from '@mui/icons-material/ShoppingBag';
import FavoriteIcon from '@mui/icons-material/Favorite';
import { height, SxProps } from '@mui/system';
import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';

import { config } from 'src/config';
import { requestApi } from 'src/functions/RequestApi';
import { ProductProps, SizeProps } from 'src/interfaces/ProductProps';
import { theme } from 'src/theme/StyleTheme';

import { useStyles } from './DetailedProductCard.styles';

const PreviewPhoto = ({
  photos,
  callBack,
  sx,
  spacing,
}: {
  photos: (string | undefined)[];
  callBack?: (index: number) => void;
  sx?: SxProps<Theme>;
  spacing?: number;
}) => {
  const [selectedIndex, setIndex] = useState(-1);
  const isSmallOrLess = useMediaQuery(theme.breakpoints.up('md'));
  const click = (index: number) => {
    setIndex(index);
    callBack?.(index);
  };
  return (
    <Box sx={sx}>
      <Grid container columns={{ xs: 1, md: photos.length }} spacing={spacing ?? 0}>
        {photos.map((x, index) => {
          if (isSmallOrLess || index === 0) {
            return (
              <Grid
                onClick={e => click(index)}
                key={index}
                item
                xs={1}
                md={1}
                sx={{
                  margin: 0,
                  padding: 0,
                }}
              >
                <img
                  style={{
                    height: 'auto',
                    width: '100%',
                  }}
                  src={`${config.productPhotoFolder}${x}`}
                />
              </Grid>
            );
          }
        })}
      </Grid>
    </Box>
  );
};
const PhotoPicker = ({
  photos,
  callBack,
  selectable = false,
  sx,
  columns,
}: {
  photos: (string | undefined)[];
  callBack?: (index: number) => void;
  selectable?: boolean;
  sx?: SxProps<Theme>;
  columns?: number;
}) => {
  const [selectedIndex, setIndex] = useState(-1);
  const click = (index: number) => {
    setIndex(index);
    callBack?.(index);
  };
  return (
    <Box sx={sx}>
      <Grid spacing={1} container columns={{ xs: columns ?? photos.length }}>
        {photos.map((x, index) => (
          <Grid
            key={index}
            item
            xs={1}
            sx={{
              margin: 0,
              padding: 0,
            }}
            onClick={e => click(index)}
          >
            <img
              style={{
                border: 'solid 0',
                borderWidth: selectedIndex === index && selectable ? 1 : 0,
                height: 'auto',
                width: '100%',
              }}
              src={`${config.productPhotoFolder}${x}`}
            />
          </Grid>
        ))}
      </Grid>
    </Box>
  );
};
const SizeSelector = ({
  sizes,
  title,
  onChange,
  sx,
}: {
  sizes: SizeProps[];
  title: string;
  onChange?: (index: number) => void;
  sx?: SxProps<Theme>;
}) => {
  const [size, setSize] = useState('');
  return (
    <Box sx={sx}>
      <FormControl variant="filled" fullWidth>
        <InputLabel>{title}</InputLabel>
        <Select
          value={size}
          onChange={e => {
            setSize(e.target.value);
            onChange?.(Number(e.target.value));
          }}
        >
          {sizes.map(x => (
            <MenuItem key={x.id} value={x.id}>
              {x.label}
            </MenuItem>
          ))}
        </Select>
      </FormControl>
    </Box>
  );
};
export const DetailedProductCard = () => {
  const { idProduct } = useParams<string>();
  const [product, setProduct] = useState<ProductProps>();
  const isBiggerMd = useMediaQuery(theme.breakpoints.up('md'));
  const isBiggerLg = useMediaQuery(theme.breakpoints.up('lg'));

  const classes = useStyles(theme);
  const getProductInfo = async () => {
    setProduct(await requestApi(`/products/${idProduct}`));
  };
  const proudctImages = [product?.productImage, product?.productImage];
  const proudctImages1 = [
    product?.productImage,
    product?.productImage,
    product?.productImage,
    product?.productImage,
    product?.productImage,
    product?.productImage,
    product?.productImage,
  ];
  const options = { style: 'currency', currency: 'RUB' };
  const numberFormat = new Intl.NumberFormat('ru-RU', options);
  useEffect(() => {
    (async () => {
      await getProductInfo();
    })();
  }, []);
  const ButtonWithSelectSize = ({ sx }: { sx?: SxProps<Theme> }) => (
    <Grid container spacing={3} order={5} sx={sx}>
      <Grid item xs={12}>
        <SizeSelector
          sx={{ height: '50px' }}
          title="Размер"
          sizes={[
            { id: 0, label: 'XL' },
            { id: 1, label: 'XL' },
            { id: 2, label: 'XL' },
            { id: 3, label: 'XL' },
          ]}
        />
      </Grid>
      <Grid item xs={12}>
        <Button sx={{ width: '100%' }} variant="contained" startIcon={<CartIcon />}>
          Добавить
        </Button>
      </Grid>
    </Grid>
  );
  return (
    <Grid padding={2} spacing={{ xs: 1, md: 0 }} container columns={{ xs: 12, md: 12 }}>
      <Grid item md={8} xs={12} order={{ md: 1, xs: 2 }}>
        <PreviewPhoto
          spacing={1}
          callBack={index => {
            console.log(index);
          }}
          photos={proudctImages}
        />
      </Grid>
      <Grid item md={0.2} xs={0} order={{ md: 2 }} />
      <Grid position={{ md: 'sticky' }} top={0} item md={3.8} xs={12} order={{ md: 3, xs: 1 }}>
        <Grid spacing={3} container xs={12}>
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
              {/* <Grid item xs={12} height={10} /> */}
              <Grid item xs={12}>
                <PhotoPicker columns={isBiggerLg ? 5 : 4} selectable photos={proudctImages1} />
              </Grid>
            </>
          ) : (
            <></>
          )}
          {isBiggerMd ? (
            <>
              <Grid item xs={12}>
                <ButtonWithSelectSize />
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
            <PhotoPicker selectable photos={proudctImages1} />
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
              <SizeSelector
                title="Размер"
                sizes={[
                  { id: 0, label: 'XL' },
                  { id: 1, label: 'XL' },
                  { id: 2, label: 'XL' },
                  { id: 3, label: 'XL' },
                ]}
              />
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
