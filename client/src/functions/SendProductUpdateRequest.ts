import { ProductProps } from 'src/interfaces/ProductProps';

import { requestApi } from './RequestApi';

export const UpdatesProducts = async (products: ProductProps[]) => {
  console.log(products);
  await requestApi('/products', {
    method: 'PUT',
    headers: { 'content-Type': 'application/json' },
    body: JSON.stringify(products),
  });
};
