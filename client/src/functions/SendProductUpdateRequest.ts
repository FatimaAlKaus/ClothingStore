import { ProductProps } from 'src/interfaces/ProductProps';
import { UpdateProductRequest } from 'src/interfaces/UpdateProductRequest';

import { requestApi } from './RequestApi';

export const UpdatesProducts = async (products: ProductProps[]) => {
  const request: UpdateProductRequest[] = products.map(
    p =>
      <UpdateProductRequest>{
        id: p.id,
        name: p.name,
        price: p.price,
        categories: p.categories.map(x => x.id),
      },
  );
  console.log(request);
  await requestApi('/products', {
    method: 'PUT',
    headers: { 'content-Type': 'application/json' },
    body: JSON.stringify(request),
  });
};
