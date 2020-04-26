class Utils {

    converteData(data) {
        return new Intl.DateTimeFormat("pt-BR", {
            year: 'numeric',
            month: '2-digit', 
            day: '2-digit'
        }).format(new Date(data))
    }

}

export default new Utils()