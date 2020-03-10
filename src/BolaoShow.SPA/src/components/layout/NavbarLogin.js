import React, { Fragment, Component } from 'react';
import { Link } from 'react-router-dom';

class NavbarAuth extends Component {
    sair = () => {
        localStorage.removeItem('userInfo');
        window.location.reload();
    }

    render() {
        if (localStorage.getItem('userInfo')) {
            let userName = JSON.parse(localStorage.getItem('userInfo')).data.userToken.nome;
            return (
                <li className="dropdown">                    
                    <a href="#" className="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false"><span className="glyphicon glyphicon-user"></span> {userName} <span className="caret"></span></a>
                    <ul className="dropdown-menu">
                        <li style={{ cursor: 'pointer', textAlign: 'center'}} >
                            <span className="glyphicon glyphicon-log-out"></span>
                            <strong style={{textDecoration: 'none'}} onClick={this.sair}> Sair </strong>
                        </li>
                    </ul>
                </li>
            );
        } else {
            return (
                <Fragment>
                    <li><Link to="/registrar">Registar</Link></li>
                    <li><Link to="/entrar">Entrar</Link></li>
                </Fragment>
            );
        }
    }
}


export default NavbarAuth;