import { ProductProps } from './ProductProps';

export interface PagedResult {
  queryable: ProductProps[];
  pageCount: number;
  pageSize: number;
  currentPage: number;
  rowCount: number;
}
