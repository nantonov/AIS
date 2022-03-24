import React from 'react';
import Main from "./pages/MainPage/MainPage";
import Header from "./pages/Header/Header";
import {Provider} from 'react-redux';
import { browserHistory, store } from './core/store/index';
import { ConnectedRouter } from 'connected-react-router';

function App() {
    return (
        <Provider store={store}>
            <ConnectedRouter history={browserHistory}>
                <Header/>
                <Main/>
            </ConnectedRouter>
        </Provider>
    )}

export default App;
