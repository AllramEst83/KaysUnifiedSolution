import 'babel-polyfill';
import React from 'react';
import { render } from 'react-dom';
import { Router, browserHistory } from 'react-router';
import routes from './router';
import './styles/styles.css'; //Webpack can import CSS files too!
import '../node_modules/bootstrap/dist/css/bootstrap.min.css';
import configureStore from './store/configureStore';
import { Provider } from 'react-redux';
import { loadUnicorns } from './actions/unicornActions';
import { loadHornTypes } from './actions/hornActions';

const store = configureStore();
store.dispatch(loadUnicorns());
store.dispatch(loadHornTypes());

render(
  <Provider store={store}>
    <Router history={browserHistory} routes={routes} />
  </Provider>,

  document.getElementById('app')
);
