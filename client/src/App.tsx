import React from 'react';

import './App.css';
import { ProductCard } from './components/ProductCard';

const App: React.FC = () => (
  <div className="App">
    <ProductCard
      imgPath="https://lp2.hm.com/hmgoepprod?set=quality%5B79%5D%2Csource%5B%2Fa4%2F21%2Fa4215639d03ba59819394fc655171fe62213dab4.jpg%5D%2Corigin%5Bdam%5D%2Ccategory%5B%5D%2Ctype%5BDESCRIPTIVESTILLLIFE%5D%2Cres%5Bm%5D%2Chmver%5B2%5D&call=url[file:/product/main]"
      name="Кеды с рисунком"
      price={3999}
      id={5}
    />
    <ProductCard
      imgPath="https://lp2.hm.com/hmgoepprod?set=quality%5B79%5D%2Csource%5B%2Fa6%2F6f%2Fa66fcb6caf63e5004f1339d0d8235acce93c5c0d.jpg%5D%2Corigin%5Bdam%5D%2Ccategory%5B%5D%2Ctype%5BDESCRIPTIVESTILLLIFE%5D%2Cres%5Bm%5D%2Chmver%5B2%5D&call=url[file:/product/main]"
      name="Брюки"
      price={1000}
      id={5}
    />
  </div>
);

export default App;
