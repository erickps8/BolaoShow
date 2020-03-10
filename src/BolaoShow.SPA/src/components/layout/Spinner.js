import React, { Fragment } from 'react'

import spinner from './images/spinner.gif'

const Spinner = () => 
    <Fragment>
        <img src={spinner} alt="Loading..." style={{ width: '50px', margin: 'auto', display: 'block' }}/>
    </Fragment>

export default Spinner

