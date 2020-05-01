import React, { Component, Fragment } from 'react'
import iziToast from 'izitoast'
import { Link } from 'react-router-dom';

import AuthService from '../../services/AuthService'
import Panel from '../layout/Panel'
import Validators from '../validators/Validators'

class Entrar extends Component {
    constructor() {
        super();
        this.state = {
            email: '',
            password: '',
            emailValid: null,
            passwordValid: null,
            formValid: false,
            errors: [],
            loading: false
        };
        this.login = this.login.bind(this);
        this.handleChange = this.handleChange.bind(this);
        this.handleErrors = this.handleErrors.bind(this);
    }

    componentDidMount() {
        this.handleErrors();
    }

    login() {
        AuthService.login(this.state)
            .then(resp => {
                if (resp.status === 200) {
                    localStorage.setItem("userInfo", JSON.stringify(resp.data))
                    window.location.reload()
                }
            }).catch(error => {
                this.setState({ ...this.state, errors: error.response.data.errors });
            });
    }

    handleChange(event) {
        const name = event.target.name
        const value = event.target.value;
        this.validateField(name, value);
        this.setState({ [name]: value })
    }

    validateField(fieldName, value) {
        switch (fieldName) {
            case 'email':
                this.setState({ ...this.state, emailValid: (Validators.validarEmail(value) ? 'has-success' : 'has-error') });
                break;
            case 'password':
                let passwordValid = value.length >= 6;
                this.setState({ ...this.state, passwordValid: (passwordValid === true ? 'has-success' : 'has-error') });
                break;
            default:
                break;
        }
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
            this.setState({ ...this.state, errors: [] })
        }
    }

    render() {
        return (
            <div className="col-md-4 col-md-offset-4" data-scrollreveal="enter down">
                {this.handleErrors()}
                <Panel title="Entrar" buttonFooter="Entrar" panelClass="panel panel-primary" labelClass="panel-title col-md-offset-4" handleClick={() => this.login.bind(this)}>
                    <form>
                        <div className={`form-group ${this.state.emailValid}`}>
                            <label htmlFor="email">E-mail</label>
                            <input type="email" id="email" name="email" value={this.state.email} onChange={this.handleChange} className="form-control" />
                        </div>
                        <div className={`form-group ${this.state.passwordValid}`}>
                            <label htmlFor="password">Senha</label>
                            <input type="password" id="password" name="password" value={this.state.password} onChange={this.handleChange} className="form-control" />
                        </div>
                    </form>
                    Não tenho <Fragment><Link to="/registrar"> Cadastro</Link></Fragment>
                </Panel>
            </div>
        )        
    }
}

export default Entrar;