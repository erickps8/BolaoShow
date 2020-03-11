import React from 'react';
import { Link } from 'react-router-dom';

import NavbarLogin from './NavbarLogin'
import NavbarAuthenticated from './NavbarAuthenticated';

const Menu = () => {
    return (
            <nav className="navbar navbar-default Menu-principal">
                <div className="container">
                    <div className="navbar-header">
                        <button type="button" className="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1" aria-expanded="false">
                            <span className="sr-only">Toggle navigation</span>
                        </button>

                        <a className="navbar-brand" href="/home"><p>BOLÃO SHOW</p></a>
                    </div>
                    <div className="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                        <ul className="nav navbar-nav">
                        <li><Link to="/home">Home</Link></li>
                            <NavbarAuthenticated/>                            
                            <li><Link to="/sobre">Sobre</Link></li>
                        </ul>
                        <ul className="nav navbar-nav navbar-right">                            
                            <NavbarLogin/>
                        </ul>
                    </div>
                </div>
            </nav>
    );
};

export default Menu;