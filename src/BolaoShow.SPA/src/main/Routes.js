import React from 'react';
import { Route, Switch, Redirect } from 'react-router-dom';

import Home from '../components/home/Home'
import Concursos from '../components/concursos/Concursos'
import NovoConcurso from '../components/concursos/NovoConcurso'
import Apostas from '../components/apostas/Apostas'
import Sobre from '../components/sobre/Sobre'
import Registrar from '../components/login/Registrar'
import Entrar from '../components/login/Entrar'

const PrivateRoute = ({ component: Component, ...props }) => {
    return (
        localStorage.getItem('userInfo') ? (
            <Component { ...props }/>
        ) : (
            <Redirect to={{ pathname: "/entrar",
                           state: { from: props.location }
                        }}  
            />
        )
    )
}

const UnauthenticateRoute = ({ component: Component, ...props }) => {
    return (
        !localStorage.getItem('userInfo') ? (
            <Component { ...props }/>
        ) : (
            <Redirect to={{ pathname: "/home",
                           state: { from: props.location }
                        }}  
            />
        )
    )
}

const Routes = () => (
    <Switch>
        <Route exact path='/home' component={Home} />
        <PrivateRoute exact path='/concursos' component={Concursos} />
        <PrivateRoute exact path='/novo-concurso' component={NovoConcurso} />
        <PrivateRoute exact path='/apostas' component={Apostas} />
        <Route exact path='/sobre' component={Sobre} />
        <UnauthenticateRoute exact path='/registrar' component={Registrar} />
        <UnauthenticateRoute exact path='/entrar' component={Entrar} />
        <Redirect to='/home' component={Home} />
    </Switch>
);

export default Routes;