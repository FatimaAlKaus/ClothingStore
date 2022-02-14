import { RequestOptions } from 'src/interfaces/RequestOptions';
import { config } from 'src/config';
import { PagedResult } from 'src/interfaces/PagedResult';

export async function requestApi(url: string, requestOptions?: RequestOptions) {
  const response = await fetch(`${config.apiURI}${url}`, requestOptions);
  return await response.json();
}
export async function getProducts(pageNumber?: number, pageSize?: number, filter?: string): Promise<PagedResult> {
  const params = [];
  if (pageNumber !== undefined) {
    params.push(`PageNumber=${pageNumber}`);
  }
  if (pageSize !== undefined) {
    params.push(`PageSize=${pageSize}`);
  }
  if (filter !== undefined) {
    params.push(`filter=${filter}`);
  }
  const query = `${config.apiURI}/products${params.length !== 0 ? `?${params.join('&')}` : ''}`;
  const response = await fetch(query);
  return await response.json();
}
