export interface ProductProps {
  id: number;
  name: string;
  price: number;
  productImage: string;
  clickEvent: () => void;
}

export interface IDetailedProduct {
  name: string;
  price: number;
}
