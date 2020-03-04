import React from 'react';

const Accordion = (props) => {
    return (
        <div className="panel panel-primary col-lg-offset-3">
            <div className="panel-heading" style={{ cursor: "pointer" }} role="tab" id="headingOne" data-toggle="collapse" data-parent="#accordion" href={"#" + props.href} aria-expanded="true" aria-controls={props.ariaControls}>
                <h4 className="panel-title" >
                    <a role="button" style={{ textDecoration: "none" }}>
                        {props.title}
                    </a>
                </h4>
            </div>
            <div id={props.idPanel} className="panel-collapse collapse" role="tabpanel" aria-labelledby="headingOne">
                {props.children}
            </div>
        </div>
    );
};

export default Accordion;