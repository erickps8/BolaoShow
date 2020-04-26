import React, { Component } from 'react';

class Dezenas extends Component {
    constructor(props) {
        super(props)
        this.state = { index: [] };
    }
 
    render() {
        const renderAccordion = (x) => {
            let constante = [];
            for (let i = 1; i <= x; i++) {
                constante.push(
                    <div key={i} data-toggle="buttons" className={"btn-group"} >
                        <label className={(this.props.dezenas.some(y => y === i)) ? "Margin_1 bolaDezenas btn btn-success" : "Margin_1 bolaDezenas btn btn-primary"} onClick={(e) => this.props.clicado(i, e)}>
                        <input type="checkbox" name={`Dezena_0${i+1}`} value={i} />{i < 10 ? '0' + i : i}
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