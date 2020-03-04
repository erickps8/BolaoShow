import React, { Fragment } from 'react';
import { Link } from 'react-router-dom';

import NavbarAuth from './NavbarAuth'

const Menu = () => {
    return (
            <nav className="navbar navbar-default Menu-principal">
                <div className="container-fluid">
                    <div className="navbar-header">
                        <button type="button" className="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1" aria-expanded="false">
                            <span className="sr-only">Toggle navigation</span>
                        </button>

                        <a className="navbar-brand" href="#"><p className="col-md-2">BOLÃO SHOW</p></a>
                    </div>
                    <div className="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                        <ul className="nav navbar-nav">
                            <li><Link to="/concursos">Concursos</Link></li>
                            <li><Link to="/apostas">Apostas concorrendo</Link></li>
                            <li><Link to="/sobre">Sobre</Link></li>
                        </ul>
                        <ul className="nav navbar-nav navbar-right">                            
                            <NavbarAuth/>
                        </ul>
                    </div>
                </div>
            </nav>
    );
};

export default Menu;