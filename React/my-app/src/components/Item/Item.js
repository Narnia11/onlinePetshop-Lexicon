import React, { Component } from 'react';
import './Item.css';


export function Item(props) {
    console.log('props^^', props);
    var pathimage = props.obj.medias[0].media_path.split('\\').pop();
    console.log('pathimage:' / pathimage);
    //alert(pathimage);
    return (

        <div className="category_item col-auto " >
            <div className="category_item_picture">
                <img src={require('../../../../../assigment/wwwroot/media/images/' + pathimage)} width="200px" className="img-fluid" alt="Responsive image" />
            </div>
            <div className="category_item_title">
                <a href={"/GetItemDetails/" + props.obj.item_id}>{props.obj.item_Name}  </a>
                <p className='category-item-description'>{props.obj.item_description}</p>


            </div>
        </div>

    )

}