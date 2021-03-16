import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { Introduce } from './components/Introduce';
import { Name } from './components/Name';

import './custom.css'

export default class App extends Component
{
	static displayName = App.name;

	render()
	{
		return (
			<Layout>
				<Route exact path='/' component={Home} />
				<Route path='/name' component={Name} />
				<Route path='/introduce' component={Introduce} />
			</Layout>
		);
	}
}
