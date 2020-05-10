import React, { Fragment } from 'react'

import spinner from './images/spinner.gif'

const Loading = (loading) => {
    if(loading) {         
        return ( 
            <div className="loader">
                <img src={spinner} alt="Loading..." style={{ width: '50px', margin: 'auto', display: 'block' }}/>
            </div>
        ) 
    } else {
        return null
    }
}

export default Loading

