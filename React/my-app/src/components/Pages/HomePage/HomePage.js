import React, { Component } from "react"
import ReactDOM from 'react-dom';
import { Baner } from "../../Baner/Baner";
import { Categories } from "../../Categories/Categories";
import { Items } from "../../Items/Items";
import { Slider } from "../../Slider/Slider";
import './HomePage.css';
export class HomePage extends Component{
    render(){
        return(
          <div className="">
              <Slider></Slider>
              <h4>recents categories</h4>
              <Categories></Categories>
              <Baner></Baner>
              <h4>recents items</h4>
              <Items></Items>

          </div>
        )
    }
}