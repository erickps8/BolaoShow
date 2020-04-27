import React, { Component, Fragment } from 'react';
import { Link } from 'react-router-dom'

class NavbarAuthenticated extends Component {

    render() {
        return (
            localStorage.getItem('userInfo') &&
            <Fragment>
                <li><Link to="/concursos">Faça sua aposta</Link></li>
                <li><Link to="/apostas">Acompanhe as apostas</Link></li>
            </Fragment>
        );
    }
}

export default NavbarAuthenticated;