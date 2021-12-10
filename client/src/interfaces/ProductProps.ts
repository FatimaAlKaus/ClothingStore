export interface ProductProps {
  id: number;
  name: string;
  price: number;
  productImage: string;
  description?: string;
  photos?: string[];
  clickEvent: () => void;
}
export interface SizeProps {
  id: number;
  label: string;
}
