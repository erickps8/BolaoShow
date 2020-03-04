import React from 'react';

import Label from './Label'

const Panel = (props) => {
    return (
        <div className={props.panelClass}>
            <div className="panel-heading "><Label labelClass={props.labelClass} title={props.title}></Label></div>
            <div className="panel-body">
                {props.children}
            </div>
            <div className="panel-footer">
                <button type="submit" className="btn btn-success col-md-offset-4" onClick={props.handleClick()}>{props.buttonFooter}</button>
            </div>
        </div>
    );
};

export default Panel;