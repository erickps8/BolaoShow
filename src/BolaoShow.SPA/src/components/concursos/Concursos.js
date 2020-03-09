import React, { Component } from 'react';
import iziToast from 'izitoast'

import Dezenas from '../dezenas/Dezenas'
import Sorteios from '../sorteios/Sorteios'
import NovoConcurso from './NovoConcurso'

import Modal from '../layout/Modal'
import Accordion from '../layout/Accordion'

import service from '../../services/Service'
import Concurso from '../../models/Concurso';

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
            dezenas: [],
            objetoDezenas: {
                Dezena_01: 0,
                Dezena_02: 0,
                Dezena_03: 0,
                Dezena_04: 0,
                Dezena_05: 0,
            },
            messages: []
        }
        this.confirmModal = this.confirmModal.bind(this)
        this.onChangeInput = this.onChangeInput.bind(this)
        this.dezenaClicada = this.dezenaClicada.bind(this);
        this.cadastrarAposta = this.cadastrarAposta.bind(this);
    }

    componentDidMount() {
        service.get(`Concurso`)
               .then(resp => this.setState({ ...this.state, list: resp.data }))
    }

    confirmModal() {
        this.state.formulario.numeroConcurso = parseInt(this.state.formulario.numeroConcurso);
        this.state.formulario.dataInicioConcurso = new Date(this.state.formulario.dataInicioConcurso);
        this.state.formulario.dataFimConcurso = new Date(this.state.formulario.dataFimConcurso); 
        let objecto = Object.assign({Concurso, ...this.state.formulario})
        service.post('Concurso', objecto)
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
                this.setState({objetoDezenas: { ...this.state.objetoDezenas, [event.target.name]: event.target.value }});
            }
            else if(this.state.dezenas.length < 5){
                this.setState({ ...this.state, ...this.state.dezenas.push(i) }); 
                this.setState({objetoDezenas: { ...this.state.objetoDezenas, Dezena_01: +e.target.innerText }});   
            }else{
                 iziToast.error({
                     title: 'OPS!',
                     message: 'Você só pode escolher 5 dezenas',
                     position: "topRight"                    
                 });
            }
        } else{
            this.setState({ ...this.state, ...this.state.dezenas.push(i) }); 
        }    
    }

    async cadastrarAposta() {
        this.state.objetoDezenas.Dezena_01 = this.state.dezenas[0];
        this.state.objetoDezenas.Dezena_02 = this.state.dezenas[1];
        this.state.objetoDezenas.Dezena_03 = this.state.dezenas[2];
        this.state.objetoDezenas.Dezena_04 = this.state.dezenas[3];
        this.state.objetoDezenas.Dezena_05 = this.state.dezenas[4];
        await service.post('Aposta', this.state.objetoDezenas)
    }

    render() {
        const renderNovoconcurso = () => {
            return (
                JSON.parse(localStorage.getItem("userInfo")).data.userToken.claims.some(x => x.type === 'Administrador') &&
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
                                <Modal modalId={concurso.numeroConcurso} title="Escolha suas dezenas" colContent="col-md-12" colBody="col-md-12" botaoPrimary="Confirmar" onClick={this.cadastrarAposta}>
                                    <Dezenas dezenas={this.state.dezenas} clicado={this.dezenaClicada}/>
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