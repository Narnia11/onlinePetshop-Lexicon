import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Category } from "../Category/Category";
import { useLocation } from 'react-router-dom';
import { useParams } from "react-router-dom";
import './ItemDetails.css';





export default function ItemDetails() {
    const location = useLocation();
    const params = useParams();
    const [data, setData] = useState([]);
    const [loading, setLoading] = useState(false);
    var imgsource;


    useEffect(() => {
        setLoading(true);
        if (params.id) {
            console.log('params.id::', params.id)
            fetch('http://localhost:60359/api/Item/GetItem/' + params.id)
                .then((res) => res.json())
                .then((data) => {
                    setData(data);
                    console.log('data::', data);

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

    return (
        <div>    {data ?
            <div className="item-details col-auto  p-4" >
                <div className="item-details_picture">
                    <img src={`data:image/jpeg;base64,${data.item_ImagePath}`} width="500px" className="img-fluid" alt={data.category_name} />



                    <div className="item-details_title"><span className='mr-1'>Title:</span>{data.item_Name}</div>

                    <p className='item-details_price'><span className='mr-1'>Price:</span>{data.Item_price}</p>

                    <p className='item-details_description'><span className='mr-1'>Description:</span>{data.item_description}</p>

                </div>

            </div> : null}
        </div>




    );

}
