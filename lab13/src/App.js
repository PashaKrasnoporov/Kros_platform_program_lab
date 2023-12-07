import { BrowserRouter, Route, Switch, useHistory } from 'react-router-dom';
import { OktaAuth, toRelativeUrl } from "@okta/okta-auth-js";
import { Security, SecureRoute, LoginCallback } from "@okta/okta-react";
import Home from './components/Home';
import Profile from './components/Profile';
import Lab1 from './components/Lab1';
import Lab2 from './components/Lab2';
import Lab3 from './components/Lab3';
import oktaConfig from './oktaConfig';
import './App.css';

const oktaAuth = new OktaAuth(oktaConfig)

function App() {
  const history = useHistory();

    const restoreOriginalUri = async (_oktaAuth, originalUri) => {
        history.replace(toRelativeUrl(originalUri || "/", window.location.origin));
    };

  return(
      <Security oktaAuth={oktaAuth} restoreOriginalUri={restoreOriginalUri}>
        <Switch>
          <Route path="/" exact="true" component={Home} />
          <SecureRoute path="/profile" component={Profile} />
          <SecureRoute path="/lab1" component={Lab1} />
          <SecureRoute path="/lab2" component={Lab2} />
          <SecureRoute path="/lab3" component={Lab3} />
          <Route path="/login/callback" component={LoginCallback} />
        </Switch>
      </Security>
  );
}

export default App;
