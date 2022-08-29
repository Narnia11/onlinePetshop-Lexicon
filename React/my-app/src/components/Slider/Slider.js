import React,{Component} from "react";
import './Slider.css';
import slider1 from '../../media/bridge.jpg';
import slider2 from '../../media/collosseum.jpg';



export class Slider extends Component{
    render(){
        return(
            <div>

<div id="carouselExampleControls" className="carousel slide" data-ride="carousel">
  <div className="carousel-inner">
    <div className="carousel-item active">
      <img src={slider1} className="img-fluid d-block w-100" alt="logo image"/>
    </div>
    <div className="carousel-item">
      <img src={slider2} className="img-fluid d-block w-100" alt="logo image" />
    </div>

  </div>
  <a className="carousel-control-prev" href="#carouselExampleControls" role="button" data-slide="prev">
    <span className="carousel-control-prev-icon" aria-hidden="true"></span>
    <span className="sr-only">Previous</span>
  </a>
  <a className="carousel-control-next" href="#carouselExampleControls" role="button" data-slide="next">
    <span className="carousel-control-next-icon" aria-hidden="true"></span>
    <span className="sr-only">Next</span>
  </a>
</div>
            </div>
        )
    }
}