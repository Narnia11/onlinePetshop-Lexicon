import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Category } from "../Category/Category";
import { useLocation } from 'react-router-dom';
import { useParams } from "react-router-dom";
import './CategoryItems.css';





export default function CategoryItems() {
    const location = useLocation();
    const params = useParams();
    const [data, setData] = useState([]);
    const [loading, setLoading] = useState(false);
    var imgsource;


    useEffect(() => {
        setLoading(true);
        if (params.id) {
            console.log('params.id::', params.id)
            fetch('http://localhost:60359/api/Category/GetCategory/' + params.id)
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
            <div className="category_item col-auto " >
                <div className="category_item_picture">
                    <p >{params.pathimage}</p>

                    {/* <img src={require(imgtag)} width="200px" className="img-fluid" alt="Responsive image"/>; */}
                    <img src={`data:image/jpeg;base64,${data.category_ImagePath}`} width="500px" className="img-fluid" alt={data.category_name} />



                    <div className="category_item_title">{data.category_name}</div>

                    <p className='category_item_description'>{data.category_description}</p>

                </div>

            </div> : null}
        </div>




    );

}
