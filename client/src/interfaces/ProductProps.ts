import { ICategory } from './ICategory';

export interface ProductProps {
  id: number;
  name: string;
  price: number;
  productImage: string;
  description?: string;
  categories: ICategory[];
  photos?: string[];
  clickEvent: () => void;
}
export interface SizeProps {
  id: number;
  label: string;
}
