import { Grid } from '@mui/material';
import { Box, SxProps, Theme } from '@mui/system';
import React, { useEffect, useState } from 'react';

export const PhotoPicker = ({
  photos,
  callBack,
  selectable = false,
  sx,
  columns,
  index,
  spacing,
}: {
  photos: (string | undefined)[];
  callBack?: (index: number) => void;
  selectable?: boolean;
  sx?: SxProps<Theme>;
  columns?: number;
  spacing?: number;
  index?: number;
}) => {
  const click = (id: number) => {
    setIndex(id);
    callBack?.(id);
  };
  const [currentIndex, setIndex] = useState(index);
  useEffect(() => {
    setIndex(index);
  }, [index]);
  return (
    <Box sx={sx}>
      <Grid spacing={spacing ?? 1} container columns={{ xs: columns ?? photos.length }}>
        {photos.map((x, id) => (
          <Grid
            key={id}
            item
            xs={1}
            sx={{
              margin: 0,
              padding: 0,
            }}
            onClick={() => click(id)}
          >
            <img
              style={{
                border: 'solid 0',
                borderWidth: currentIndex === id && selectable ? 1 : 0,
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
