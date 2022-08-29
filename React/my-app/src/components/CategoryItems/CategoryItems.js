import React, { useState,useEffect } from 'react';
import axios  from 'axios';
import { Category } from "../Category/Category";
import {useLocation} from 'react-router-dom';
import { useParams } from "react-router-dom";




export default function CategoryItems(){
  const location = useLocation();
    const params = useParams();
    const [data, setData] = useState([]);
    const [loading, setLoading] = useState(false);
    var imgsource;


   useEffect(() => {
    setLoading(true);
    if(params.id){
      console.log('params.id::',params.id)
      fetch('http://localhost:60359/api/Category/GetCategory/'+params.id)
      .then((res) => res.json())
      .then((data) => {
        setData(data);

      })
      .catch((err) => {
        console.log(err);
      })
      .finally(() => {

 

        setLoading(false);
      });
    }

  }, []);

      
    
  if (loading) {
    return <p>Data is loading...</p>;
  }
console.log('data:',data);

console.log('category_ImagePath:',data.category_ImagePath);



  // var shorten =JSON.stringify(data.medias);
  // console.log('shorten::',shorten);
  // let filepath  = shorten?.substring(shorten.lastIndexOf('images')+8,shorten.lastIndexOf('media_Category_id')-3).trim();
  // console.log('filepath::',filepath);
  // imgsource='../../../../../assigment/wwwroot/media/images/'+filepath;
  // console.log('imgsource::',imgsource);
  // var imgtag="<img src='../../../../../assigment/wwwroot/media/images/'"+filepath+"/>"


  return (
<div>    {data ?   
<div className="category_item col-auto " >
                 <div className="category_item_picture">
                 <p >{params.pathimage}</p>

                 {/* <img src={require(imgtag)} width="200px" className="img-fluid" alt="Responsive image"/>; */}
                 <img src={`data:image/jpeg;base64,${data.category_ImagePath}`} alt={data.category_name} />
 


              <div className="category_item_title">{data.category_name}</div>
          


                 </div>

 </div>: null } 
 </div>




  );

}
