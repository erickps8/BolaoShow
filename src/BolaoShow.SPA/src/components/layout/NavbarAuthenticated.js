import React, { Component, Fragment } from 'react';
import { Link } from 'react-router-dom'

class NavbarAuthenticated extends Component {

    render() {
        return (
            localStorage.getItem('userInfo') &&
            <Fragment>
                <li><Link to="/concursos">Concursos</Link></li>
                <li><Link to="/apostas">Apostas</Link></li>
            </Fragment>
        );
    }
}

export default NavbarAuthenticated;