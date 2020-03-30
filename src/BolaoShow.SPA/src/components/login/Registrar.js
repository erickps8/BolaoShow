import React, { Component } from 'react';
import iziToast from 'izitoast'

import Panel from '../layout/Panel'
import Validators from '../validators/Validators'
import AuthService from '../../services/AuthService'
import ModelRegistrar from '../../models/ModelRegistrar'

class Registrar extends Component {
    model = ModelRegistrar;
    state = {
        nome: '',
        email: '',
        password: '',
        confirmPassword: '',
        validator: {
            nomeValido: '',
            emailValido: '',
            validPassword: '',
            validConfirmPassword: '',
            formValido: true
        },
        user: {},
        errors: [],
        loading: false
    }

    handleErrors() {
        if (this.state.errors.length > 0) {
            const listErrors = this.state.errors
            listErrors.map(element => {
                return iziToast.error({
                    title: 'Erro!',
                    message: element,
                    position: "topRight"
                });
            })
            this.setState({errors: { ...this.state, errors: [] } })
        }
    }

    handleChange = (e) => {
        const name  = e.target.name;
        const value = e.target.value;
        this.validateField(name, value);
        this.setState({ [name]: value })
    }

    validateField(fieldName, value) {
        switch (fieldName) {
            case 'nome':
                this.setState({ validator: { ...this.state.validator, nomeValido: ( value.length > 0 ? 'has-success' : 'has-error') } });
                this.model = Object.assign({ModelRegistrar}, this.state)
                break;
            case 'email':
                this.setState({ validator: { ...this.state.validator, emailValido: (Validators.validarEmail(value) ? 'has-success' : 'has-error') } });
                break;
            case 'password':
                let validPassword = value.length >= 6;
                this.setState({ validator: { ...this.state.validator, validPassword: (validPassword === true ? 'has-success' : 'has-error') } });
                break;
            case 'confirmPassword':
                let senhasIguais = this.state.password === value;
                this.setState({ validator: { ...this.state.validator, validConfirmPassword: ((value.length >= 6 && senhasIguais) ? 'has-success' : 'has-error') } });
                break;
            default:
                break;
        }
    }

    async registrar() {
        this.setState({ ...this.state, loading: true }) 
        let cadastro = await AuthService.registrarUsuario(this.state)
                                        .catch(error => this.setState({ ...this.state, loading: false, errors: error.response.data.errors }),
                                                this.handleErrors())
        if (cadastro.status === 200) {
            localStorage.setItem("userInfo", JSON.stringify(cadastro.data))
            window.location.reload()
        }
        this.setState({ ...this.state, loading: false });
    }

    render() {
        return (
            <div className="col-md-4 col-md-offset-4" data-scrollreveal="enter down">
                {this.handleErrors()}
                <Panel title="Registrar" buttonFooter="Registrar" panelClass="panel panel-primary" labelClass="panel-title col-md-offset-4" handleClick={() => this.registrar.bind(this)}>
                    <form>
                        <div className={`form-group ${this.state.validator.nomeValido}`}>
                            <label htmlFor="Name">Nome</label>
                            <input type="text" name="nome" value={this.state.nome} onChange={this.handleChange} className="form-control" />
                        </div>
                        <div className={`form-group ${this.state.validator.emailValido}`}>
                            <label htmlFor="Email">E-mail</label>
                            <input type="email" name="email" value={this.state.email} onChange={this.handleChange} className="form-control" />
                        </div>
                        <div className={`form-group ${this.state.validator.validPassword}`}>
                            <label htmlFor="Password">Senha</label>
                            <input type="password" name="password" value={this.state.password} onChange={this.handleChange} className="form-control" />
                        </div>
                        <div className={`form-group ${this.state.validator.validConfirmPassword}`}>
                            <label htmlFor="Password">Confirma senha</label>
                            <input type="password" name="confirmPassword" value={this.state.confirmPassword} onChange={this.handleChange} className="form-control" />
                        </div>
                    </form>
                </Panel>
            </div>
        )
    }
}

export default Registrar;