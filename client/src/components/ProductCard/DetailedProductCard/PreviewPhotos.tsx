import React from 'react';
import { Grid } from '@mui/material';
import { Box, SxProps, Theme } from '@mui/system';

export const PreviewPhotos = ({
  photos,
  callBack,
  sx,
  spacing,
  columns,
}: {
  photos: (string | undefined)[];
  callBack?: (index: number) => void;
  sx?: SxProps<Theme>;
  spacing?: number;
  columns?: number;
}) => {
  const click = (index: number) => {
    callBack?.(index);
  };
  return (
    <Box sx={sx}>
      <Grid container columns={{ xs: columns ?? photos.length }} spacing={spacing ?? 0}>
        {photos.map((x, index) => (
          <Grid
            onClick={() => click(index)}
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
              src={x}
            />
          </Grid>
        ))}
      </Grid>
    </Box>
  );
};
