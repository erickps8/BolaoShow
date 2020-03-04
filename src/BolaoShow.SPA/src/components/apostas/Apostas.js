import React, { Component } from 'react';

import service from '../../services/Service'
import authService from '../../services/AuthService'

class Apostas extends Component {
    constructor(props){        
        super(props)
        this.state = {
            apostas: '', 
            list:[],
            dezenasAcertadas: [], 
            listAcertos:[]  
        }         
    }

    componentDidMount(){
        service.get('Aposta/apostaConcursoVigente').then(resp => this.setState({ ...this.state, list: resp.data}))
    }   
    
    render(){       
        const renderApostas = () => {            
            const list = this.state.list;
            return list != "" &&
            list.map(apostas =>(               
                <div key={apostas.id}>
                 
                    <label style={{paddingRight:"35px"}}>Data da aposta 11/02/2020</label>       
                         
                    <div  data-toggle="buttons" className="btn-group">
                        <label className={apostas.estado_Dezena_01 ? "btn btn-success Margin_5" : "btn btn-primary Margin_5"}>
                            <input type="checkbox" value={apostas.dezena_01} />{apostas.dezena_01 < 10 ? '0' + apostas.dezena_01 : apostas.dezena_01}
                        </label>
                        <label className={apostas.estado_Dezena_02 ? "btn btn-success Margin_5" : "btn btn-primary Margin_5"}>
                            <input type="checkbox" value={apostas.dezena_02} />{apostas.dezena_02 < 10 ? '0' + apostas.dezena_02 : apostas.dezena_02}
                        </label>
                        <label className={apostas.estado_Dezena_03 ? "btn btn-success Margin_5" : "btn btn-primary Margin_5"}>
                            <input type="checkbox" value={apostas.dezena_03} />{apostas.dezena_03 < 10 ? '0' + apostas.dezena_03 : apostas.dezena_03}
                        </label>
                        <label className={apostas.estado_Dezena_04 ? "btn btn-success Margin_5" : "btn btn-primary Margin_5"}>
                            <input type="checkbox" value={apostas.dezena_04} />{apostas.dezena_04 < 10 ? '0' + apostas.dezena_04 : apostas.dezena_04}
                        </label>
                        <label className={apostas.estado_Dezena_05 ? "btn btn-success Margin_5" : "btn btn-primary Margin_5"}>
                            <input type="checkbox" value={apostas.dezena_05} />{apostas.dezena_05 < 10 ? '0' + apostas.dezena_05 : apostas.dezena_05}
                        </label>
                    </div>
                    <span style={{color:"#5cb85c", marginRight:"5px"}} className={(apostas.userId == authService.getUserInfo().data.userToken.id ? "glyphicon glyphicon-lg glyphicon-ok" : "hidden")}></span>
                </div>                    
            )) 
        }

        return(
            <div className="col-md-12 col-lg-offset-1" data-scrollreveal="enter left">
                <div>
                <label className="TagLabel">Suas apostas estão sinalizadas com <span style={{color:"#5cb85c"}} className="glyphicon glyphicon-lg glyphicon-ok"></span></label>
                    {renderApostas()}
                </div>            
            </div>
        )
    }
}

export default Apostas;