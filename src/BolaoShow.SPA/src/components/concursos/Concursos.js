import React, { Component } from 'react';

import Dezenas from '../dezenas/Dezenas'
import Sorteios from '../sorteios/Sorteios'
import NovoConcurso from './NovoConcurso'

import Modal from '../layout/Modal'
import Accordion from '../layout/Accordion'

import service from '../../services/Service'

class Concursos extends Component {
    constructor(props) {
        super(props)
        this.state = {
            concurso: '',
            list: [],
            formulario: {
                descricao: '',
                numeroConcurso: 0,
                dataInicioConcurso: '',
                dataFimConcurso: ''
            },
            messages: []
        }
        this.confirmModal = this.confirmModal.bind(this)
        this.onChangeInput = this.onChangeInput.bind(this)
    }

    componentDidMount() {
        service.get(`Concurso`)
               .then(resp => this.setState({ ...this.state, list: resp.data }))
    }

    confirmModal() {
        this.state.formulario.numeroConcurso = parseInt(this.state.formulario.numeroConcurso);
        this.state.formulario.dataInicioConcurso = new Date(this.state.formulario.dataInicioConcurso);
        this.state.formulario.dataFimConcurso = new Date(this.state.formulario.dataFimConcurso); 
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

    handleMessage() {
        
    }

    render() {
        const renderNovoconcurso = () => {
            return (
                <div>
                    <button type="button" className="btn btn-success" data-toggle="modal" data-target="#novoConcurso" data-scrollreveal="enter top">
                        Novo concurso
                    </button>
                    <Modal modalId="novoConcurso" title="Novo concurso" colContent="col-md-12" colBody="col-md-12" onClick={this.confirmModal} botaoPrimary="Criar novo concurso" modalSize="modal-sm">
                        <NovoConcurso onChangeInput={this.onChangeInput} formulario={this.state.formulario}/>
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
                            <div>Início: <b>{concurso.dataInicioConcurso}</b></div>
                            <div>Fim: <b>{concurso.dataFimConcurso}</b></div>
                        </div>
                        <div>
                            <div>
                                <h3 className="TagLabel">Dezenas sorteadas neste concurso</h3>
                                <Sorteios concursoId={concurso.id} />
                                <h3>Boa sorte!</h3>
                            </div>
                            <div>
                                <button type="button" className="btn btn-primary" data-toggle="modal" data-target={"#" + concurso.numeroConcurso}>
                                    Fazer aposta
                                </button>
                                <Modal modalId={concurso.numeroConcurso} title="Escolha suas dezenas" colContent="col-md-12" colBody="col-md-12" botaoPrimary="Confirmar">
                                    <Dezenas />
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