import { useState } from 'react';
import './App.css';
import Cart from './components/Cart';
import ProductListing from './components/ProductListing';

function App() {
  var products =[
    {
       "id":101,
       "name":"Pencil",
       "quantity":10,
       "price":5
   },
   {
       "id":102,
       "name":"Pen",
       "quantity":3,
       "price":25
   },
   {
       "id":103,
       "name":"Eraser",
       "quantity":7,
       "price":3
   }
]
var [cart,setCart]=useState([]);
var addToCart=(pid)=>{
  setCart([...cart,pid])
  console.log(cart)
  
}
  return (
    <div>
    <div className="container">
        <div className="row">
          <div class="col">
           <ProductListing products={products} onAddClick={addToCart}/>
          </div>
          <div className="col">
           <Cart cartItems={cart} />
          </div>
        </div>
      </div>
    </div>
  );
}

export default App;