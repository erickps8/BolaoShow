import { Component } from 'react';
import iziToast from 'izitoast'

class Base extends Component {
    
    /**
    @param types: 'info' | 'success' | 'error' | 'warning'
    @param title: title of the message
    @param message: the message itself
    @param position: 'bottomRight' | 'bottomLeft' | 'topRight' | 'topLeft' | 'topCenter' | 'bottomCenter' | 'center'
    */
    mensagem = (type, title, message, position) => {
        switch (type) {
            case 'info':
                iziToast.info({
                    title: title,
                    message: message,
                    position: position                   
                })
                break;
            case 'success':
                iziToast.success({
                    title: title,
                    message: message,
                    position: position                   
                })
                break;
            case 'error':
                iziToast.error({
                    title: title,
                    message: message,
                    position: position                   
                })
                break;
            case 'warning':
                iziToast.warning({
                    title: title,
                    message: message,
                    position: position                   
                })
                break;
            default:
                break;
        }
        
    }
}

export default Base;