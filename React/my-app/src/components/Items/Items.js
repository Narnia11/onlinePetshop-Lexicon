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