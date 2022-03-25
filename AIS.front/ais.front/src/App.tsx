import React from 'react';
import Main from "./pages/mainPage/MainPage";
import Header from "./core/components/header/Header";
import {Provider} from 'react-redux';
import { browserHistory, store } from './core/store/index';
import { ConnectedRouter } from 'connected-react-router';

const App: React.FC = () => {
    return (
        <Provider store={store}>
            <ConnectedRouter history={browserHistory}>
                <Header/>
                <Main/>
            </ConnectedRouter>
        </Provider>
    )}

export default App;
