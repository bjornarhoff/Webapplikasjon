import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import './custom.css'
import { NewQuestion } from './components/NewQuestion';
import { QuestionList } from './components/QuestionList';

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
            <Route exact path='/' component={Home} />
            <Route exact path='/new-question' component={NewQuestion} />
            <Route exact path='/list-question' component={QuestionList} />
        </Layout>
    );
  }
}
