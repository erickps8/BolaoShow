
class Validators{    
    validarEmail(email) {
        return email.match(/^([\w.%+-]+)@([\w-]+\.)+([\w]{2,})$/i) ? true : false;
    }

    validarDatas(dataMinima, dataMaxima) {
        
    }
}

export default new Validators()