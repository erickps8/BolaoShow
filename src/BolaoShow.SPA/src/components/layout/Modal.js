import React from 'react';

const Modal = (props) => {
    return (
        <div key={props.id} className="modal fade" id={props.modalId} tabIndex="-1" role="dialog" aria-labelledby="myModalLabel">
            <div className={`modal-dialog ${props.modalSize}`} role="document">
                <div className={`modal-content ${props.colContent}`}>
                    <div className="modal-header">
                        <h3 className="modal-title " id="myModalLabel">{props.title}</h3>
                    </div>
                    <div className={`modal-body ${props.colContent}`}>
                        {props.children}
                    </div>
                    <div className="modal-footer col-md-12">
                        <button type="button" className="btn btn-default" data-dismiss="modal">Fechar</button>
                        <button type="button" className="btn btn-primary" onClick={props.onClick}>{props.botaoPrimary}</button>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default Modal;