import logo from './logo.svg';
import './App.css';
import RegisterUser from './components/RegisterUser';

function App() {
  //var scores = [90,100,56,89,73];
  return (
   //<div className="App">
    //       <div className="container text-center">
    //     <div className="row">
    //       <div className="col">
    //         <Products/> 
    //       </div>
    //       <div className="col">
    //         <AddProduct/>
    //       </div>
    //     </div>
    // </div>
    //   <div>
    //       {scores.map((score)=>
    //         <li key={score}>{score}</li>
    //       )}
    //   </div>
      <div>
        <RegisterUser/>
      </div>
  );
}

export default App;