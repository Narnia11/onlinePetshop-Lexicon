import React, { Component } from "react"
import './Header.css';
import logoImage from '../../media/logo.png';
export class Header extends Component {
    render() {
        return (
            <header className="container-fluid">
                <nav className="navbar navbar-expand-lg navbar-light bg-light">
                    <a className="navbar-brand" href="#"><img src={logoImage} className="img-fluid" alt="logo image" width="100px" /></a>  <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                        <span className="navbar-toggler-icon"></span>
                    </button>

                    <div className="collapse navbar-collapse" id="navbarSupportedContent">
                        <ul className="navbar-nav me-auto">
                            <li className="nav-item active">
                                <a className="nav-link" href="/">Home </a>
                            </li>
                            <li className="nav-item">
                                <a className="nav-link" href="/items">items</a>
                            </li>
                            <li className="nav-item">
                                <a className="nav-link" href="/about">About Us</a>
                            </li>

                        </ul>
                        <form className="form-inline my-2 my-lg-0 ">
                            <span>facebook</span><span>whatsapp</span><span>instagram</span>    </form>
                    </div>
                </nav>
            </header>
        )
    }
}