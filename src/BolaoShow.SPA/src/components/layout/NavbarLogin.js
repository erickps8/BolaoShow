import React, { Fragment, Component } from 'react';
import { Link } from 'react-router-dom';

const SpanClasses = props => {
    return(
        <span className={props.estilos}></span>
    );
}

class NavbarAuth extends Component {
    sair = () => {
        localStorage.removeItem('userInfo');
        window.location.reload();
    }

    render() {
        if (localStorage.getItem('userInfo')) {
            let userName = JSON.parse(localStorage.getItem('userInfo')).data.userToken.nome;
            return (
                <ul>
                    <li className="drop">
                        <a href="#"><SpanClasses estilos={"glyphicon glyphicon-user"}/> {userName} </a>
                        <div className="dropdownContain">
                            <div className="dropOut">
                                <div className="triangle"></div>
                                <ul>
                                    <li onClick={this.sair}><SpanClasses estilos={"glyphicon glyphicon-log-out"}/> Sair</li>
                                </ul>
                            </div>
                        </div>
                    </li>
                </ul>
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