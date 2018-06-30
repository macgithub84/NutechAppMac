import React, { Component } from 'react'; 
import './App.css'; 
import Layout from './Layout'
import AppRouter from './AppRouter' 
import 'semantic-ui-css/semantic.min.css';


class App extends Component {
  render() {
    return (
      <div className="App">
       <Layout/>
       <AppRouter> 
      </AppRouter>
      </div>
     
    );
  }
}

export default App;
