import React from 'react'

import spinner from './images/spinner.gif'

const Spinner = () => 
    <div className="loader">
        <img src={spinner} alt="Loading..." style={{ width: '50px', margin: 'auto', display: 'block' }}/>
    </div>

export default Spinner

