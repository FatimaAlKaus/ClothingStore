import React from 'react';

import './App.css';
import { ProductCard } from './components/ProductCard';

const App: React.FC = () => (
  <div className="App">
    <ProductCard imgPath="../images/7851.970.jpg" name="Кеды с рисунком" price={3999} id={5} />
    <ProductCard imgPath="../images/7851.970.jpg" name="World" price={1000} id={5} />
  </div>
);

export default App;
