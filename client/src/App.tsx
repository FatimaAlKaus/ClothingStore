import React from 'react';

import './App.css';
import { DetailedProductCard } from './components/DetailedProductCatd';

const App: React.FC = () => (
  <div className="App">
    <DetailedProductCard name="Туфли" price={900} />
  </div>
);

export default App;
