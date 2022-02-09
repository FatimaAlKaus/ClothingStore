import { RequestOptions } from 'src/interfaces/RequestOptions';
import { config } from 'src/config';
import { ProductProps } from 'src/interfaces/ProductProps';
import { PagedResult } from 'src/interfaces/PagedResult';

export async function requestApi(url: string, requestOptions?: RequestOptions) {
  const response = await fetch(`${config.apiURI}${url}`, requestOptions);
  return await response.json();
}
export async function getAllProducts(): Promise<ProductProps[]> {
  const response = await fetch(`${config.apiURI}/products/`);
  const pagedResult: PagedResult = await response.json();
  return pagedResult.queryable;
}
