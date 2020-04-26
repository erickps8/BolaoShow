import React from 'react';

const Modal = (props) => {
    return (
        <div key={props.id} className="modal fade" id={props.modalId} tabIndex="-1" role="dialog" aria-labelledby="myModalLabel">
            <div className={`modal-dialog ${props.modalSize}`} role="document">
                <div className={`modal-content ${props.colContent}`}>
                    <div className="modal-header">
                        <span className={props.icon} aria-hidden="true"></span>
                        <h3 className="modal-title " id="myModalLabel">{props.title}</h3>
                    </div>
                    <div className={`modal-body ${props.colContent}`}>
                        {props.children}
                    </div>                    
                </div>
            </div>
        </div>
    );
};

export default Modal;