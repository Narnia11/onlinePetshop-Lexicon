import React, { Component } from "react"
import './Baner.css';
import BanerImage from '../../media/baner.jfif';

export class Baner extends Component{
    render(){
        return(
           <div className="col">
               <img src={BanerImage} className="img-fluid w-100" alt="baner image"/>
           </div>
        )
    }
}