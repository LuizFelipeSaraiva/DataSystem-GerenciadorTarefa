import React from 'react';
import './App.css';
import {BrowserRouter as Router, Route, Switch} from 'react-router-dom'
import ListaDeTarefasComponent from './components/ListaDeTarefasComponent';
import HeaderComponent from './components/HeaderComponent';
import CriarTarefaComponent from './components/CriarTarefaComponent';

function App() {
  return (
    <div>
        <Router>
              <HeaderComponent />
                <div className="container">
                    <Switch> 
                          <Route path = "/" exact component = {ListaDeTarefasComponent}></Route>
                          <Route path = "/tarefas" component = {ListaDeTarefasComponent}></Route>
                          <Route path = "/manter/:id" component = {CriarTarefaComponent}></Route>
                    </Switch>
                </div>
        </Router>
    </div>
    
  );
}

export default App;
