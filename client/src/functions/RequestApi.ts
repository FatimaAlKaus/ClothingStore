import { RequestOptions } from 'src/interfaces/RequestOptions';
import { config } from 'src/config';

export async function requestApi(url: string, requestOptions?: RequestOptions) {
  const response = await fetch(`${config.apiURI}${url}`, requestOptions);
  return await response.json();
}
