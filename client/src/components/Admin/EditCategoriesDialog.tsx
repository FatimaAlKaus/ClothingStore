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
}: {
  open: boolean;
  product?: ProductProps;
  onClose?: () => void;
  allCategories: ICategory[];
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
              control={<Checkbox checked={categories?.map(y => y.id).includes(x.id)} />}
              label={`${x.name}`}
            />
          ))}
        </FormGroup>
      </DialogContent>
      <DialogActions>
        <Button autoFocus onClick={() => onClose?.()}>
          Cancel
        </Button>
        <Button>Ok</Button>
      </DialogActions>
    </Dialog>
  );
};
