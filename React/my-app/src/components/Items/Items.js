import React, { useEffect, useState } from "react";
import { Item } from '../Item/Item';
import './Items.css';
import axios  from 'axios';
import {useLocation} from 'react-router-dom';

// const items = [
//     {id:1,category_name: 'Cats', picturePaht: 'cat.jpg'},
//     {id:2,category_name: 'Dogs', picturePaht: 'dog.jfif'},
//     {id:3,category_name: 'Birs', picturePaht: 'birde.jfif'}


//   ];
export function Items(){

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
    
    useEffect(()=>{
      axios.get('http://localhost:60359/api/Item/GetRecentItems').then((res)=>{
       
  
       const ResponseData=res.data;
      
       setData(ResponseData);
      
      })
        },[])

    

        return(
            <div  className="d-flex justify-content-around">

            {data.map((item)=>
            
                    <Item key={item.id} obj={item}></Item>
              
                )}
            
                        </div>
        )
    
}