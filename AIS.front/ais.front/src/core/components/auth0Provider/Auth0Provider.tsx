import React from 'react';
import ReactDOM from 'react-dom';
import { Auth0Provider } from '@auth0/auth0-react';
import App from '../../../App';

ReactDOM.render(
  <Auth0Provider
    domain="dev---aps9vw.us.auth0.com"
    clientId="PBqz8sdZeHcyMd06RfKiIZAoDaP73q5G"
    redirectUri={window.location.origin}
  >
    <App />
  </Auth0Provider>,
  document.getElementById('root')
);
