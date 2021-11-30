import { RequestOptions } from 'src/interfaces/RequestOptions';
import { config } from 'src/config';

export async function requestApi(url: string, requestOptions?: RequestOptions) {
  const response = await fetch(`${config.homeAddress}${url}`, requestOptions);
  return await response.json();
}
