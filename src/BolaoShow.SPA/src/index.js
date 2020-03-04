import React from 'react';
import ReactDOM from 'react-dom';

import App from './main/App';

import 'bootstrap/dist/css/bootstrap.min.css'
import 'izitoast/dist/css/iziToast.min.css'
import $ from 'jquery/src/jquery'
import Popper from 'popper.js'
import 'bootstrap/dist/js/bootstrap.min.js'
import 'izitoast/dist/js/iziToast.min.js'

ReactDOM.render(
	<App />,
	document.getElementById('root')
);
