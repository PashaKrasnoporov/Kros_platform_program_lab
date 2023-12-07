import {createRoot} from 'react-dom/client';
import {BrowserRouter} from 'react-router-dom';
import {Auth0Provider} from "@auth0/auth0-react";

import App from "./App";
import './index.css';

import config from './config';

const rootElement = document.getElementById('root');

if (rootElement) {
  const root = createRoot(rootElement);

  root.render(
    <Auth0Provider
      domain={config.Auth0.domain}
      clientId={config.Auth0.clientId}
      authorizationParams={{
        redirect_uri: window.location.origin,
        audience: config.Auth0.audience,
      }}
    >
      <BrowserRouter>
        <App/>
      </BrowserRouter>
    </Auth0Provider>
  );
}



