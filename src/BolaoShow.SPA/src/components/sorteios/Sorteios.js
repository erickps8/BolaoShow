import React, { Component } from 'react';

import service from "../../services/Service";

class Sorteios extends Component {
    constructor(props){        
        super(props)
        this.state = {sorteios: '', list:[]}         
    }

    componentDidMount(){        
        service.getById('Sorteio', this.props.concursoId).then(resp => this.setState({ ...this.state, list: resp.data}))
    }   

    render(){       
        const renderSorteios = () => {
            const list = this.state.list;            
            return list.map(sorteios =>(
                    <div key={sorteios.id}> 
                        <label style={{paddingRight:"35px"}}>Dia 11/02/2020</label>                  
                        <div  data-toggle="buttons">
                            <label className="btn btn-primary Margin_1 bolaDezenasSorteio" style={{}}>
                                <input type="checkbox" value={sorteios.dezena_01} />{sorteios.dezena_01 < 10 ? '0' + sorteios.dezena_01 : sorteios.dezena_01}
                            </label>
                            <label className="btn btn-primary Margin_1 bolaDezenasSorteio">
                                <input type="checkbox" value={sorteios.dezena_02} />{sorteios.dezena_02 < 10 ? '0' + sorteios.dezena_02 : sorteios.dezena_02}
                            </label>
                            <label className="btn btn-primary Margin_1 bolaDezenasSorteio">
                                <input type="checkbox" value={sorteios.dezena_03} />{sorteios.dezena_03 < 10 ? '0' + sorteios.dezena_03 : sorteios.dezena_03}
                            </label>
                            <label className="btn btn-primary Margin_1 bolaDezenasSorteio">
                                <input type="checkbox" value={sorteios.dezena_04} />{sorteios.dezena_04 < 10 ? '0' + sorteios.dezena_04 : sorteios.dezena_04}
                            </label>
                            <label className="btn btn-primary Margin_1 bolaDezenasSorteio">
                                <input type="checkbox" value={sorteios.dezena_05} />{sorteios.dezena_05 < 10 ? '0' + sorteios.dezena_05 : sorteios.dezena_05}
                            </label>
                        </div>
                    </div>                    
                ))
        }
        return(
            <div className="col-md-12">
                <div>
                    {renderSorteios()}
                </div>            
            </div>
        )
    }
}

Sorteios.propTypes = {

};

export default Sorteios;