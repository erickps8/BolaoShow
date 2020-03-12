import React, { Component } from 'react';
import iziToast from 'izitoast'

import Dezenas from '../dezenas/Dezenas'
import Sorteios from '../sorteios/Sorteios'
import NovoConcurso from './NovoConcurso'

import Modal from '../layout/Modal'
import Accordion from '../layout/Accordion'

import service from '../../services/Service'
import Utils from '../utils/Utils'

class Concursos extends Component {
    
    state = {
        concurso: '',
        list: [],
        formulario: {
            descricao: '',
            numeroConcurso: 0,
            dataInicioConcurso: '',
            dataFimConcurso: ''
        },
        dezenas: [],
        objetoDezenas: {
            Dezena_01: 0,
            Dezena_02: 0,
            Dezena_03: 0,
            Dezena_04: 0,
            Dezena_05: 0,
            Dezena_06: 0,
            Dezena_07: 0,
            Dezena_08: 0,
            Dezena_09: 0,
            Dezena_10: 0
        },
        messages: []
    }

    componentDidMount() {
        service.get(`Concurso`)
               .then(resp => this.setState({ ...this.state, list: resp.data }))
    }

    async confirmModal() {
        let numeroConcurso = +this.state.formulario.numeroConcurso;
        let dataInicio = new Date(this.state.formulario.dataInicioConcurso);
        let dataFim = new Date(this.state.formulario.dataFimConcurso);

        await this.setState({ formulario: { 
            ...this.state.formulario, 
            numeroConcurso: numeroConcurso,
            dataInicioConcurso: dataInicio, 
            dataFimConcurso: dataFim} });

        service.post('Concurso', this.state.formulario)
               .then(response => {
                   this.setState({formulario: { ...this.state.formulario, descricao: '', numeroConcurso: 0, dataFimConcurso: '', dataInicioConcurso: '' }})
                   this.componentDidMount()
               })
               .catch()
    }

    onChangeInput(event) {    
        const name = event.target.name;
        const value = event.target.value;
        this.setState({formulario: { ...this.state.formulario, [name]: value }});
    }

    dezenaClicada(i, e) {
        if (this.state.dezenas.length > 0) {
            if(this.state.dezenas.some(y => y === i)) {
                let dezenas = this.state.dezenas.indexOf(i)
                this.setState({ ...this.state, ...this.state.dezenas.splice(dezenas, 1) });
            }
            else if(this.state.dezenas.length < 10){
                this.setState({ ...this.state, ...this.state.dezenas.push(i) });   
            }else{
                 iziToast.error({
                     title: 'OPS!',
                     message: 'Você só pode escolher 10 dezenas',
                     position: "topRight"                    
                 });
            }
        } else{
            this.setState({ ...this.state, ...this.state.dezenas.push(i) }); 
        }    
    }

    async cadastrarAposta() {
        await this.setState({ objetoDezenas: { ...this.state.objetoDezenas,
            Dezena_01: this.state.dezenas[0],
            Dezena_02: this.state.dezenas[1],
            Dezena_03: this.state.dezenas[2],
            Dezena_04: this.state.dezenas[3],
            Dezena_05: this.state.dezenas[4],
            Dezena_06: this.state.dezenas[5],
            Dezena_07: this.state.dezenas[6],
            Dezena_08: this.state.dezenas[7],
            Dezena_09: this.state.dezenas[8],
            Dezena_10: this.state.dezenas[9]
        } });
        service.post('Aposta', this.state.objetoDezenas)
    }

    render() {
        const renderNovoconcurso = () => {
            return (
                JSON.parse(localStorage.getItem("userInfo")).data.userToken.claims.some(x => x.type === 'Administrador') &&
                <div style={{marginBottom:"25px"}}>
                    <button type="button" className="btn btn-success" data-toggle="modal" data-target="#novoConcurso" data-scrollreveal="enter top">
                        Novo concurso
                    </button>
                    <Modal modalId="novoConcurso" title="Novo concurso" colContent="col-md-12" colBody="col-md-12" onClick={this.confirmModal.bind(this)} botaoPrimary="Criar novo concurso" modalSize="modal-sm">
                        <NovoConcurso onChangeInput={this.onChangeInput.bind(this)} formulario={this.state.formulario}/>
                    </Modal>
                </div>)
        }
        const renderAccordion = () => {
            const list = this.state.list;
            return list.map(concurso => (
                <Accordion key={concurso.id} href={"#" + concurso.id} ariaControls={concurso.id} idPanel={concurso.id} title={concurso.descricao}>
                    <div style={{ padding: "20px" }}>
                        <div className="TagLabel">
                            <div>Concurso de edição número: <b>{concurso.numeroConcurso} </b></div>
                            <div>Início: <b>{Utils.converteData(concurso.dataInicioConcurso)}</b></div>
                            <div>Fim: <b>{(Utils.converteData(concurso.dataFimConcurso))}</b></div>
                        </div>
                        <div>
                            <div>
                                <h3 className="TagLabel">Dezenas sorteadas neste concurso</h3>
                                <Sorteios concursoId={concurso.id} />
                                <h3>Boa sorte!</h3>
                            </div>
                            <div>     
                                {concurso.ativo &&    
                                <button type="button" className="btn btn-primary" data-toggle="modal" data-target={"#" + concurso.numeroConcurso}>
                                    Fazer aposta
                                </button>
                                }
                                <Modal modalId={concurso.numeroConcurso} title="Escolha suas dezenas" colContent="col-md-12" colBody="col-md-12" botaoPrimary="Confirmar" onClick={this.cadastrarAposta.bind(this)}>
                                    <Dezenas dezenas={this.state.dezenas} clicado={this.dezenaClicada.bind(this)}/>
                                </Modal>

                            </div>
                        </div>
                    </div>
                </Accordion>
            ))
        }
        return (
            <div>
                {renderNovoconcurso()}
                <div className="panel-group col-md-10" id="accordion" role="tablist" aria-multiselectable="true" data-scrollreveal="enter down">
                    {renderAccordion()}
                </div>
            </div>
        )
    }
}

export default Concursos;