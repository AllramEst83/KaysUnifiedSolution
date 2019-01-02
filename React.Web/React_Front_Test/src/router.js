import React from 'react';
import { Route, IndexRoute } from 'react-router';
import App from './components/app';
import HomePage from './components/home/homePage';
import AboutPage from './components/about/aboutPage';
import UnicornsPage from './components/unicorn/unicorns';
import ManageUnicornPage from './components/unicorn/manageUnicornPage';

export default (
  <Route path="/" component={App}>
    <IndexRoute component={HomePage} />
    <Route path="about" component={AboutPage} />
    <Route path="unicorns" component={UnicornsPage} />
    
    <Route path="unicorn" component={ManageUnicornPage} />
    <Route path="unicorn/:id" component={ManageUnicornPage} />
  </Route>
);
