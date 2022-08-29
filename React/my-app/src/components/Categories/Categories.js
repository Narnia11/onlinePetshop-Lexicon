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
    const accessToken="eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJhLmtpYW4zMkB5YWhvby5jb20iLCJqdGkiOiJkM2Q0NzJmNC0zN2NjLTQ2MzQtOWM2Mi1jNTAyYmQ2NjkyOWQiLCJ1bmlxdWVfbmFtZSI6ImEua2lhbjMyQHlhaG9vLmNvbSIsImV4cCI6MTY2MTY1OTQzMywiaXNzIjoiTVY1IiwiYXVkIjoiQXBpVXNlciJ9.Ny_LUIOv2bBBlGsLOitHz6t-hYCiLW-d7HOi75WFkzk";

    axios.interceptors.request.use(
      config=>{
        config.headers.authorization=`Bearer ${accessToken}`;
        return config;
      },
      error=>{
        return Promise.reject(error);
      }
    )
    try{
      
      useEffect(()=>{
        axios.get('http://localhost:60359/api/Category/GetCategorys/').then((res)=>{
         
    
         const ResponseData=res.data;
        
         setData(ResponseData);
        
        })
          },[])

    }catch(err){
      setRequestError(err);
    }


    
    return(

                    <div  className="d-flex justify-content-around">

{data.map((category)=>

        <Category key={category.category_id} obj={category}></Category>
  
    )}

            </div>
     
    )
}
