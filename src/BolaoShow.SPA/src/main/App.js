import React, { Component } from 'react';
import { BrowserRouter as Router } from 'react-router-dom'

import Menu from '../components/layout/Menu'
import Routes from './Routes';

import 'bootstrap/dist/css/bootstrap.min.css'
import 'izitoast/dist/css/iziToast.min.css'
import '../components/layout/css/custom.css'
import '../components/layout/scripts/scrollReveal.js'

class App extends Component {
	render() {
		return (
			<Router>
				<Menu />
				<div className="container">
					<div className="jumbotron col-md-12">
						<Routes />
					</div>
				</div>
			</Router>
		);
	}
}

export default App;
