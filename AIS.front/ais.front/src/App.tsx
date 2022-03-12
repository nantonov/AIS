import React, {useEffect} from 'react';
import Main from "./Components/MainPage/MainPage";
import Header from "./Components/Header/Header";
import {Provider} from 'react-redux';
import { browserHistory, store } from './store/index';
import { ConnectedRouter } from 'connected-react-router';

function App() {
    useEffect(() => {
        const _onInit = () => {
            console.log('init OK')
        }
        const _onError = (err: any) => {
            console.log('error', err)
        }
    })
    return (
        <Provider store={store}>
            <ConnectedRouter history={browserHistory}>
            <div>
                <Header/>
                <Main/>
            </div>
            </ConnectedRouter>
        </Provider>
    )
}

export default App;
