import { Close, Search } from '@mui/icons-material';
import { Button, IconButton, InputAdornment, StandardTextFieldProps, TextField } from '@mui/material';
import React, { useState } from 'react';

import { useStyles } from './SearchBar.styles';

interface SearchBarParams {
  onFind?: (text: string) => void;
}
export const SearchBar: React.FC<SearchBarParams> = ({ onFind }) => {
  const [text, setText] = useState('');
  const classes = useStyles();
  const clearText = () => {
    setText('');
  };
  const findClickHandler = () => {
    onFind?.(text);
  };

  return (
    <div>
      <TextField
        className={classes.textBox}
        value={text}
        placeholder="Search products"
        variant="standard"
        onChange={(e: React.ChangeEvent<HTMLInputElement>) => {
          setText(e.target.value);
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
    </div>
  );
};
