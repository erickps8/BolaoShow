
class Validators{    
    validarEmail(email) {
        return email.match(/^([\w.%+-]+)@([\w-]+\.)+([\w]{2,})$/i) ? true : false;
    }
}

export default new Validators()