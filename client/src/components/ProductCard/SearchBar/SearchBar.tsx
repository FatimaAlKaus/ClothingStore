import { Close, Search } from '@mui/icons-material';
import { InputAdornment, TextField } from '@mui/material';
import { Box, SxProps, Theme } from '@mui/system';
import React, { useState } from 'react';

import { useStyles } from './SearchBar.styles';

interface SearchBarParams {
  onFind?: (text: string) => void;
  onTextChanged?: (text: string) => void;
  onClear?: () => void;
  sx?: SxProps<Theme>;
}
export const SearchBar: React.FC<SearchBarParams> = ({ onFind, onClear, onTextChanged, sx }) => {
  const [text, setText] = useState('');
  const classes = useStyles();
  const clearText = () => {
    onClear?.();
    setText('');
  };
  const findClickHandler = () => {
    onFind?.(text);
  };
  return (
    <Box sx={sx}>
      <TextField
        className={classes.textBox}
        value={text}
        placeholder="Search products"
        variant="standard"
        onChange={(e: React.ChangeEvent<HTMLInputElement>) => {
          setText(e.target.value);
          onTextChanged?.(e.target.value);
        }}
        InputProps={{
          startAdornment: (
            <InputAdornment position="start">
              <Search className={classes.searchIcon} onClick={findClickHandler} />
            </InputAdornment>
          ),
        }}
      />
      <Close
        onClick={clearText}
        className={classes.closeIcon}
        sx={{
          verticalAlign: 'bottom',
          visibility: text.length === 0 ? 'hidden' : 'visible',
        }}
      />
    </Box>
  );
};
