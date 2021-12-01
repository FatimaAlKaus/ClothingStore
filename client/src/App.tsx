import React from 'react';

import './App.css';
import { ProductList } from './components/ProductCard/ProductList';
import { ProductProps } from './interfaces/ProductProps';

const App: React.FC = () => {
  const list: ProductProps[] = [
    {
      id: 1,
      name: 'Шапка ушанка',
      imgPath: 'https://www.bingostore.ru/wa-data/public/shop/products/53/00/53/images/75229/75229.0x900.jpg',
      price: 499,
    },
    {
      id: 2,
      name: 'Кеды с рисунком',
      imgPath:
        'https://lp2.hm.com/hmgoepprod?set=quality%5B79%5D%2Csource%5B%2Fa4%2F21%2Fa4215639d03ba59819394fc655171fe62213dab4.jpg%5D%2Corigin%5Bdam%5D%2Ccategory%5B%5D%2Ctype%5BDESCRIPTIVESTILLLIFE%5D%2Cres%5Bm%5D%2Chmver%5B2%5D&call=url[file:/product/main]',
      price: 2999,
    },
    {
      id: 3,
      name: 'Валенки',
      imgPath: 'https://fapsiz.ru/upload/iblock/f3e/f3e8e6a2f05a92057fd1cfd54b104b09.jpeg',
      price: 99999,
    },
    {
      id: 4,
      name: 'Пиджак',
      imgPath: 'https://static1.boscooutlet.ru/upload/iblock/2b0/2b0e94659c2b1bed9ab698447123aab4_1221_1607.jpg',
      price: 5200,
    },
    {
      id: 5,
      name: 'Панама',
      imgPath: 'https://www.bosco.ru/upload/iblock/195/19502f3d56a97e4724e2ef8f026041fe.jpg',
      price: 500,
    },
    {
      id: 6,
      name: 'Панамsdfsafsidfhasdfuia\n\n\nsdfuiduiadsfguiagiduidа',
      imgPath: 'https://www.bosco.ru/upload/iblock/195/19502f3d56a97e4724e2ef8f026041fe.jpg',
      price: 50044,
    },
    {
      id: 7,
      name: 'Панамsdfsafsidfhasdfuia\n\n\nsdfuiduiadsfguiagiduidа',
      imgPath: 'https://klike.net/uploads/posts/2020-04/1587719791_1.jpg',
      price: 50044,
    },
    {
      id: 7,
      name: 'Панамsdfsafsidfhaвапвапвапвапвапвап\n\n\nsdfuia\n\n\nsdfuiduiadsfguiagiduidа',
      imgPath: 'https://cs8.pikabu.ru/post_img/big/2016/02/04/7/145458292112119207.jpg',
      price: 50044,
    },
  ];
  return (
    <div className="App">
      <ProductList cards={list} />
    </div>
  );
};

export default App;
