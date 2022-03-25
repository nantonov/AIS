import { AnyAction, Middleware } from 'redux';
import { ActionType, getType } from 'typesafe-actions';
import * as actions from '../ToastMessage/actions';

export const toastMiddleware: Middleware = (store) => (next) => (
    action: ActionType<AnyAction>
) => {
    const { dispatch } = store;
    if (action.type === getType(actions.setGlobalToast)) {
        dispatch(actions.setToast(action.payload));
    }

    return next(action);
};
