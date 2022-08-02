import React, { useState,useEffect } from 'react';
import axios  from 'axios';
import { Category } from "../Category/Category";
import './Categories.css';
import {useLocation} from 'react-router-dom';


// const categories = [
//     {id:1,category_name: 'Cats', picturePaht: 'cat.jpg'},
//     {id:2,category_name: 'Dogs', picturePaht: 'dog.jfif'},
//     {id:3,category_name: 'Birs', picturePaht: 'birde.jfif'}
//   ];


export function Categories(){
    const location = useLocation();
    // Empty array in useState!
    const [data, setData] = useState([]);
    useEffect(()=>{
      axios.get('http://localhost:60359/api/Category/GetCategorys/').then((res)=>{
       
  
       const ResponseData=res.data;
      
       setData(ResponseData);
      
      })
        },[])

    
    return(

                    <div  className="d-flex justify-content-around">

{data.map((category)=>

        <Category key={category.category_id} obj={category}></Category>
  
    )}

            </div>
     
    )
}
