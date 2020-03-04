import React, { Component } from 'react';

import Panel from '../layout/Panel'

class Registrar extends Component {
    render() {
        return (
            <div className="col-md-4 col-md-offset-4" data-scrollreveal="enter down">
                <Panel title="Registrar" buttonFooter="Registrar" panelClass="panel panel-primary" labelClass="panel-title col-md-offset-4" handleClick={() => null}>
                    <div className="form-group">
                        <label htmlFor="Name">Nome</label>
                        <input type="name" className="form-control" />
                    </div>
                    <div className="form-group">
                        <label htmlFor="Email">E-mail</label>
                        <input type="email" className="form-control" />
                    </div>
                    <div className="form-group">
                        <label htmlFor="Password">Senha</label>
                        <input type="password" className="form-control" />
                    </div>
                    <div className="form-group">
                        <label htmlFor="Password">Confirma senha</label>
                        <input type="password" className="form-control" />
                    </div>
                </Panel>
            </div>
        )
    }
}

Registrar.propTypes = {

};

export default Registrar;