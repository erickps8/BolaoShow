import React, { Component } from 'react';
import iziToast from 'izitoast';

class Dezenas extends Component {
    constructor(props) {
        super(props)
        this.state = { index: [] };
        this.clicado = this.clicado.bind(this)
    }
 
    clicado(i) {
        if (this.state.index.length > 0) {
            if(this.state.index.some(y => y === i)) {
                let index = this.state.index.indexOf(i)
                this.setState({ ...this.state, ...this.state.index.splice(index, 1) });               
            }
            else if(this.state.index.length < 5){
                this.setState({ ...this.state, ...this.state.index.push(i) });               
            }else{
                 iziToast.error({
                     title: 'OPS!',
                     message: 'Você só pode escolher 5 dezenas',
                     position: "topRight"
                     
                 });
            }
        } else{
            this.setState({ ...this.state, ...this.state.index.push(i) });           
        }        
    }
 
    render() {
        const renderAccordion = (x) => {
            let constante = [];
            for (let i = 1; i <= x; i++) {
                constante.push(
                    <div key={i} data-toggle="buttons" className={"btn-group"} >
                        <label className={(this.state.index.some(y => y === i)) ? "Margin_5 btn btn-success" : "Margin_5 btn btn-primary"} onClick={() => this.clicado(i)}>
                            <input type="checkbox" value={i} />{i < 10 ? '0' + i : i}
                        </label>
                    </div>
                )
 
            }
            return constante;
        }
 
        return (
 
            <div className="col-md-12 row">
                <div className="col-md-12">
                    {renderAccordion(80)}
                </div>
            </div>
 
        )
    }
}

Dezenas.propTypes = {

};

export default Dezenas;