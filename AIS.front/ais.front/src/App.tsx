import React from 'react';
import Main from "./Components/MainPage/MainPage";
import Header from "./Components/Header/Header";
import {Provider} from 'react-redux';
import { browserHistory, store } from './store/index';
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
