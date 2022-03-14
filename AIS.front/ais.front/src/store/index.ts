import thunk from "redux-thunk";
import {
    connectRouter,
    routerMiddleware as createRouterMiddleware,
} from 'connected-react-router';
import {BrowserHistory, createBrowserHistory} from "history";
import {
    createStore,
    applyMiddleware,
    combineReducers,
    AnyAction,
    compose,
} from 'redux';
import { toastMiddleware } from './toastMiddleware/toastMiddleware';
import {ApplicationState} from "./typing";
import {questionSetReducer} from "./QuestionSets/reducer";
import {questionsReducer} from "./Questions/reducer";

export const browserHistory = createBrowserHistory();

const routerMiddleware = createRouterMiddleware(browserHistory);

const middlewares = [toastMiddleware, thunk, routerMiddleware];

const enhancer = compose(applyMiddleware(...middlewares));

const rootReducer = (history: BrowserHistory) =>
    combineReducers<ApplicationState>({
        router: connectRouter(history),
        questionSets: questionSetReducer,
        questions: questionsReducer,
    });

export const store = createStore<ApplicationState, AnyAction, unknown, unknown>(
    rootReducer(browserHistory),
    {} as ApplicationState,
    enhancer
);

