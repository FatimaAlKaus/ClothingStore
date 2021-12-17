import { Category, CheckBox } from '@material-ui/icons';
import {
  Button,
  Checkbox,
  Dialog,
  DialogActions,
  DialogContent,
  DialogTitle,
  FormControlLabel,
  FormGroup,
} from '@mui/material';
import React, { useEffect, useState } from 'react';

import { requestApi } from 'src/functions/RequestApi';
import { ICategory } from 'src/interfaces/ICategory';
import { ProductProps } from 'src/interfaces/ProductProps';

export const EditCategoriesDialog = ({
  open,
  product,
  onClose,
  allCategories,
  returnCategories,
}: {
  open: boolean;
  product?: ProductProps;
  onClose?: () => void;
  allCategories: ICategory[];
  returnCategories: (categories: ICategory[]) => void;
}) => {
  const [categories, setCategories] = useState<ICategory[]>();
  useEffect(() => {
    const setProductCategories = () => {
      setCategories(product?.categories);
    };
    setProductCategories();
  }, [product]);

  return (
    <Dialog open={open}>
      <DialogTitle>{product?.name}</DialogTitle>
      <DialogContent dividers>
        <FormGroup>
          {allCategories?.map(x => (
            <FormControlLabel
              key={x.id}
              control={
                <Checkbox
                  onChange={() => {
                    categories?.map(c => c.id).includes(x.id)
                      ? setCategories(categories?.filter(y => y.id !== x.id))
                      : setCategories([...categories!, x]);
                  }}
                  checked={categories?.map(y => y.id).includes(x.id)}
                />
              }
              label={`${x.name}`}
            />
          ))}
        </FormGroup>
      </DialogContent>
      <DialogActions>
        <Button autoFocus onClick={() => onClose?.()}>
          Cancel
        </Button>
        <Button
          onClick={() => {
            returnCategories(categories!);
            onClose?.();
          }}
        >
          Ok
        </Button>
      </DialogActions>
    </Dialog>
  );
};
