// import React, { useState,useEffect } from 'react';

// import axios  from 'axios';
// import 'bootstrap/dist/css/bootstrap.min.css';
// import { useParams } from "react-router-dom";




// export default  function CategoryItems(){
//   const params = useParams();
//   console.log(params); 
//   // Empty array in useState!
//   const [data, setData] = useState([]);
//   var url;

//   useEffect(()=>{
//     axios.get('http://localhost:60359/api/Category/GetCategory/'+params.id).then((res)=>{
//      setData(res.data);
      
//      console.log('data::',data);
//      console.log('data.medias::');

//   var shorten =JSON.stringify(data.medias);
//   console.log('shorten::',shorten);
//   let filepath  = shorten?.substring(shorten.lastIndexOf('images')+8,shorten.lastIndexOf('media_Category_id')-3).trim();
//   console.log('filepath::',filepath);
//   let imgsource='../../../../../assigment/wwwroot/media/images/'+filepath;
//   console.log('imgsource::',imgsource);
//  url=imgsource;
//     })
//       },[data])


// console.log('url',url);
//       return(
// <div>
//   <h3>Categories {data.category_name} Detail</h3>

//   <div className="category_item col-auto " >
//                 <div className="category_item_picture">

//       {/* <p>{shorten}</p>
//       <h3>{filepath}</h3>
//       <h4>{imgsource}</h4> */}
 

//       <img  src={require(`${url}`)}    width="200px" className="img-fluid" alt="Responsive image"/>  

// {/* <p>{data.medias[0].media_path}</p> */}



// {/* <img  src={require('../../../../../assigment/wwwroot/media/images/'+filepath)}    width="200px" className="img-fluid" alt="Responsive image"/>   */}
//                   {/* <img  src={require('../../../../../assigment/wwwroot/media/images/3ed1f20f-1602-473b-b8b4-22845bcc546a_profile_picture.png')}    width="200px" className="img-fluid" alt="Responsive image"/>   */}
//                 </div>
//                 <div className="category_item_title">{data.category_name}</div>
//                 </div>

// </div>

//       )
  
// }



