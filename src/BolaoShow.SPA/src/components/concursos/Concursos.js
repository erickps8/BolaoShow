import React, { Fragment } from 'react';

import Dezenas from '../dezenas/Dezenas'
import Sorteios from '../sorteios/Sorteios'
import NovoConcurso from './NovoConcurso'

import Modal from '../layout/Modal'
import Accordion from '../layout/Accordion'

import service from '../../services/Service'
import Utils from '../utils/Utils'
import Base from '../../main/Base'

class Concursos extends Base {
    
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
               .then(resp => this.setState({ ...this.state, list: resp.data }));        
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
                   this.mensagem('success', 'Sucesso', 'Dados salvos com sucesso', 'topRight');
               })
               .catch(response => {
                   this.mensagem('error', 'Erro', 'Erro ao salvar os dados', 'topRight');
               })
    }

    onChangeInput(event) {    
        const name = event.target.name;
        const value = event.target.value;
        this.setState({formulario: { ...this.state.formulario, [name]: value }});
    }

    dezenaClicada(i) {
        this.marcarDezena(i)
    }

    marcarDezena(numero) {
        if (this.state.dezenas.length > 0) {
            if(this.state.dezenas.some(y => y === numero)) {
                let dezenas = this.state.dezenas.indexOf(numero)
                this.setState({ ...this.state, ...this.state.dezenas.splice(dezenas, 1) });
            }
            else if(this.state.dezenas.length < 10){
                this.setState({ ...this.state, ...this.state.dezenas.push(numero) });   
            }else{
                this.mensagem('error', 'OPS', 'Você só pode escolher 10 dezenas', 'topRight');
            }
        } else{
            this.setState({ ...this.state, ...this.state.dezenas.push(numero) }); 
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
               .then(response => {
                    this.mensagem('success', 'Sucesso', 'Sua aposta foi realizada com sucesso', 'topRight');
               })
    }

    surpresinha() {
        let aux = [];
        if (this.state.dezenas.length === 10) {
            this.setState({ ...this.state, dezenas: [] });
        } else {
            for (let i = 0; i < 10;) {
                let numero = Math.floor(Math.random() * 80) + 1;
                if (!aux.some(x => x === numero)) {                
                    this.marcarDezena(numero)     
                    aux.push(numero)
                    i++;
                }               
            }
        }
    }

    render() {
        const renderNovoconcurso = () => {
            return (
                JSON.parse(localStorage.getItem("userInfo")).data.userToken.claims.some(x => x.type === 'Administrador') &&
                <Fragment>
                    <div style={{marginBottom:"25px"}}>
                        <button type="button" className="btn btn-success" data-toggle="modal" data-target="#novoConcurso" data-scrollreveal="enter top">
                            Novo concurso
                        </button>
                        <Modal modalId="novoConcurso" title="Novo concurso" colContent="col-md-12" colBody="col-md-12" modalSize="modal-sm">
                            <NovoConcurso onChangeInput={this.onChangeInput.bind(this)} formulario={this.state.formulario}/>
                            <div className="modal-footer col-md-12">
                                <button type="button" className="btn btn-default" data-dismiss="modal">Fechar</button>
                                <button type="button" className="btn btn-success" data-toggle="modal" data-target="#confirmar" data-scrollreveal="enter top">Criar novo concurso</button>
                            </div>
                        </Modal>                    
                    </div>
                    <Modal modalId="confirmar" icon="glyphicon glyphicon-warning-sign" title="Atenção" colContent="col-lg-8 col-lg-offset-2" colBody="col-lg-12" modalSize="modal-md">
                        Deseja realmente criar um novo concurso?
                        <div className="modal-footer col-md-12">
                            <button type="button" className="btn btn-default" data-dismiss="modal">Não</button>
                            <button type="button" className="btn btn-success" data-toggle="modal" onClick={this.confirmModal.bind(this)} data-target="#confirmar" data-scrollreveal="enter top">Sim</button>
                        </div>
                    </Modal>
                </Fragment>
            )
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
                                <Modal modalId={concurso.numeroConcurso} title={`Escolha suas dezenas`} colContent="col-md-12" colBody="col-md-12">
                                    <Dezenas dezenas={this.state.dezenas} clicado={this.dezenaClicada.bind(this)}/>
                                    <div className="modal-footer col-md-12">
                                        <button type="button" className="btn btn-default" data-dismiss="modal">Fechar</button>
                                        <button type="button" className="btn btn-info" onClick={this.surpresinha.bind(this)}>Surpresinha</button>
                                        <button type="button" className="btn btn-primary" data-toggle="modal" data-target="#confirmarAposta" data-scrollreveal="enter top">Confirmar</button>
                                    </div>
                                </Modal>
                                <Modal modalId="confirmarAposta" icon="glyphicon glyphicon-warning-sign" title="Atenção" colContent="col-lg-8 col-lg-offset-2" colBody="col-lg-12" modalSize="modal-md">
                                    Deseja realmente confirmar esta aposta?
                                    <div className="modal-footer col-md-12">
                                        <button type="button" className="btn btn-default" data-dismiss="modal">Não</button>
                                        <button type="button" className="btn btn-success" data-toggle="modal" onClick={this.cadastrarAposta.bind(this)} data-target="#confirmarAposta" data-scrollreveal="enter top">Sim</button>
                                    </div>
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