import { RequestOptions } from 'src/interfaces/RequestOptions';

export async function requestApi(url: string, requestOptions?: RequestOptions) {
  const response = await fetch('/api/${url}', requestOptions);
  return await response.json();
}
