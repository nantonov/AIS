import { applyMiddleware, createStore } from 'redux';
import thunk from 'redux-thunk';
import toastMiddleware from './middleware/toastMiddleware';

import { rootReducer } from './reducer/rootReducer';

const middleware = [thunk, toastMiddleware];

export const store = createStore(rootReducer, applyMiddleware(...middleware));
