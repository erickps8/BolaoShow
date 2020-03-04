import React from 'react';
import InputMask from 'react-input-mask'

const NovoConcurso = (props) => {
    return (
        <div className="col-md-12">
            <form>
                <div className="form-group">
                    <label htmlFor="desc">Descrição</label>
                    <input type="text" id="desc" name="descricao" value={props.formulario.descricao} className="form-control" onChange={props.onChangeInput} />
                </div>
                <div className="form-group">
                    <label htmlFor="numero">Número</label>
                    <input type="number" id="numero" name="numeroConcurso" value={props.formulario.numeroConcurso} className="form-control" onChange={props.onChangeInput} />
                </div>
                <div className="form-group">
                    <label htmlFor="data_i">Data de início</label>
                    <InputMask mask="99/99/9999" value={props.formulario.dataInicioConcurso}  onChange={props.onChangeInput}>
                        {(inputProps) => <input {...inputProps} type="text" id="data_i" name="dataInicioConcurso" className="form-control" />}
                    </InputMask>
                </div>
                <div className="form-group">
                    <label htmlFor="data_f">Data de encerramento</label>
                    <InputMask mask="99/99/9999" value={props.formulario.dataFimConcurso} onChange={props.onChangeInput}>
                        {(inputProps) => <input {...inputProps} type="text" id="data_f" name="dataFimConcurso" className="form-control" />}
                    </InputMask>
                </div>
            </form>
        </div>
    );
};

export default NovoConcurso;