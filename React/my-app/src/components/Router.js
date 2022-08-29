import React from 'react';
import { Route, Routes } from 'react-router-dom';
import CategoryItems from './CategoryItems/CategoryItems';
import { Items } from './Items/Items';
import { AboutUsPage } from './Pages/AboutUsPage/AboutUsPage';
import { HomePage } from './Pages/HomePage/HomePage';


function Router(props) {
  return (
    <Routes>
     <Route exact  path='/' element={<HomePage />}></Route>
    <Route exact  path='/about' element={<AboutUsPage/>}></Route>
    <Route exact  path='/items' element={<Items />}></Route>
       <Route exact  path='/CategoryItems/:id' element={<CategoryItems/>} ></Route>


     {/* <Route exact  path='/SavePerson/' element={<SavePerson />} ></Route>  */}
      
    </Routes>

  );
}

export default Router