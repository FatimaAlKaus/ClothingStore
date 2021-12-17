import React, { useEffect, useState } from 'react';
import { FormControl, InputLabel, MenuItem, Select } from '@mui/material';
import { Box, SxProps, Theme } from '@mui/system';

import { SizeProps } from 'src/interfaces/ProductProps';

export const SizeSelector = ({
  sizes,
  title,
  onChange,
  sx,
  index,
}: {
  sizes: SizeProps[];
  title?: string;
  onChange?: (index: number) => void;
  sx?: SxProps<Theme>;
  index?: number;
}) => {
  const [currentIndex, setIndex] = useState(index);
  useEffect(() => {
    setIndex(index);
  }, [index]);
  const change = (id: number) => {
    setIndex(id);
    onChange?.(id);
  };
  return (
    <Box sx={sx}>
      <FormControl variant="filled" fullWidth>
        <InputLabel>{title}</InputLabel>
        <Select
          value={currentIndex}
          onChange={e => {
            change(Number(e.target.value));
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
