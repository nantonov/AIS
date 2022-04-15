import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter } from 'react-router-dom';
import { Auth0Provider } from '@auth0/auth0-react';
import App from './App';
import { GlobalStyle } from './GlobalStyle';

// @ts-ignore
ReactDOM.render(
  <React.StrictMode>
    <Auth0Provider
      domain="dev---aps9vw.us.auth0.com"
      clientId="PBqz8sdZeHcyMd06RfKiIZAoDaP73q5G"
      redirectUri={window.location.origin}
      audience="https://localhost:5001"
      scope="read:current_user update:current_user_metadata"
    >
      <BrowserRouter>
        <GlobalStyle />
        <App />
      </BrowserRouter>
    </Auth0Provider>
  </React.StrictMode>,
  document.getElementById('root')
);
