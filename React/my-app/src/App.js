import React from 'react';
import logo from './logo.svg';
import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import Router from './components/Router';
import { Header } from './components/Header/Header';
import { Footer } from './components/Footer/Footer';


function App() {
    return (
        <div className="App">
            <Header></Header>
            <Router></Router>
            <Footer></Footer>
        </div>
    );
}

export default App;
