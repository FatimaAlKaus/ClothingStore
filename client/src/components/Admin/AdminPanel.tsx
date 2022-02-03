import React, { useEffect, useState } from 'react';
import { Admin, Resource, useDataProvider } from 'react-admin';
import jsonServerProvider from 'ra-data-json-server';
import AddIcon from '@mui/icons-material/Add';
import SaveIcon from '@mui/icons-material/Save';
import { DataGrid, GridColDef, GridEditRowsModel, GridRenderCellParams, GridValueGetterParams } from '@mui/x-data-grid';
import { Box } from '@mui/system';
import { Button, Paper, Typography } from '@mui/material';

import { ProductProps } from 'src/interfaces/ProductProps';
import { ICategory } from 'src/interfaces/ICategory';
import { requestApi } from 'src/functions/RequestApi';
import { UpdatesProducts } from 'src/functions/SendProductUpdateRequest';

import { useStyles } from './AdminPanel.styles';
import { EditCategoriesDialog } from './EditCategoriesDialog';

export const AdminPanel = () => {
  const [products, setProducts] = useState<ProductProps[]>();
  const [isDisabled, setDisabled] = useState(true);
  const [isOpen, setIsOpen] = useState(false);
  const [product, setProduct] = useState<ProductProps>();
  const [categories, setAllCategories] = useState<ICategory[]>();
  // const addToChanged = (id: number) => {
  //   if (!Number.isNaN(id) && changedProducts.indexOf(id) === -1) {
  //     changedProducts.push(id);
  //     console.log(changedProducts);
  //   }
  // };

  useEffect(() => {
    (async () => {
      const reply = await requestApi('/products');
      setProducts(reply);
    })();
    (async () => {
      setAllCategories(await requestApi('/categories'));
    })();
  }, []);

  const editOnClick = async (id: number) => {
    const reply = products?.find(x => x.id === id);
    setProduct(reply);
    setIsOpen(true);
  };
  const classes = useStyles();
  const RowButtonWithText = (params: GridRenderCellParams) => (
    <div className={classes.actionRow}>
      <Typography>{params.value.map((x: ICategory) => x.name).join(', ')}</Typography>
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
          onEditRowsModelChange={param => {
            const key = Number(Object.keys(JSON.parse(JSON.stringify(param)))[0]);
            setDisabled(false);
          }}
        />
        <div className={classes.botToolBar}>
          <Button
            variant="contained"
            disabled={isDisabled}
            className={classes.saveButton}
            onClick={() => {
              UpdatesProducts(products!);
              setDisabled(true);
            }}
            startIcon={<SaveIcon />}
          >
            Save
          </Button>
        </div>
      </Paper>
      <EditCategoriesDialog
        returnCategories={categ => {
          const newProduct = product!;
          newProduct.categories = categ;
          setProduct(newProduct);
          setDisabled(false);
        }}
        allCategories={categories!}
        onClose={() => setIsOpen(false)}
        product={product}
        open={isOpen}
      />
    </Box>
  );
};
