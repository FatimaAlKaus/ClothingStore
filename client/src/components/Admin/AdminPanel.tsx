import React, { useEffect, useState } from 'react';
import { Admin, Resource, useDataProvider } from 'react-admin';
import jsonServerProvider from 'ra-data-json-server';
import AddIcon from '@mui/icons-material/Add';
import SaveIcon from '@mui/icons-material/Save';
import { DataGrid, GridColDef, GridRenderCellParams, GridValueGetterParams } from '@mui/x-data-grid';
import { Box } from '@mui/system';
import { Button, Paper, Typography } from '@mui/material';

import { ProductProps } from 'src/interfaces/ProductProps';
import { ICategory } from 'src/interfaces/ICategory';
import { requestApi } from 'src/functions/RequestApi';

import { useStyles } from './AdminPanel.styles';
import { EditCategoriesDialog } from './EditCategoriesDialog';

export const AdminPanel = () => {
  const [products, setProducts] = useState<ProductProps[]>();
  const [isDisabled, setDisabled] = useState(true);
  const [isOpen, setIsOpen] = useState(false);
  const [product, setProduct] = useState<ProductProps>();
  const [categories, setAllCategories] = useState<ICategory[]>();
  useEffect(() => {
    (async () => {
      const reply = await requestApi('/products');
      for (let i = 0; i < reply.length; i++) {
        reply[i].categories = reply[i].categories.map((x: ICategory) => x.name).join(', ');
      }
      setProducts(reply);
    })();
    (async () => {
      setAllCategories(await requestApi('/categories'));
    })();
  }, []);

  const editOnClick = async (id: number) => {
    const reply = await requestApi(`/products/${id}`);
    setIsOpen(true);
    setProduct(reply);
  };
  const classes = useStyles();
  const RowButtonWithText = (params: GridRenderCellParams) => (
    <div className={classes.actionRow}>
      <Typography>{params.value}</Typography>
      <Button
        variant="text"
        onClick={() => {
          const id = Number(params.id.toString());
          editOnClick(id);
        }}
      >
        Edit
      </Button>
    </div>
  );

  const columns: GridColDef[] = [
    { field: 'id', headerName: 'ID', flex: 0.5 },
    {
      field: 'name',
      headerName: 'Name',
      flex: 2,
      editable: true,
    },
    {
      field: 'price',
      headerName: 'Price',
      flex: 1,
      editable: true,
      type: 'number',
      align: 'left',
      headerAlign: 'left',
    },
    {
      field: 'categories',
      headerName: 'Categories',
      renderCell: RowButtonWithText,
      flex: 3,
    },
    {
      field: 'createdDate',
      headerName: 'Created date',
      type: 'dateTime',
      flex: 2,
    },
    {
      field: 'modifiedDate',
      headerName: 'Modified date',
      flex: 2,
    },
  ];
  return (
    <Box sx={{ width: 'auto' }}>
      <Paper className={classes.content}>
        <div className={classes.toolbar}>
          <Typography variant="h6" component="h2" color="primary">
            Products
          </Typography>
          <Button variant="outlined" color="primary" startIcon={<AddIcon />}>
            New Product
          </Button>
        </div>
        <DataGrid
          autoHeight
          rows={products ?? []}
          columns={columns}
          pageSize={5}
          rowsPerPageOptions={[5]}
          checkboxSelection
          disableSelectionOnClick
          onEditRowsModelChange={() => {
            setDisabled(false);
          }}
        />
        <div className={classes.botToolBar}>
          <Button
            variant="contained"
            disabled={isDisabled}
            className={classes.saveButton}
            onClick={() => setDisabled(true)}
            startIcon={<SaveIcon />}
          >
            Save
          </Button>
        </div>
      </Paper>
      <EditCategoriesDialog
        allCategories={categories!}
        onClose={() => setIsOpen(false)}
        product={product}
        open={isOpen}
      />
    </Box>
  );
};
