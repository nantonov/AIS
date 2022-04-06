import { AnyAction, Middleware } from 'redux';
import { ActionType, getType } from 'typesafe-actions';
import * as actions from '../actionCreators/toastMessageAction';

const toastMiddleware: Middleware = (store) => (next) => (action: ActionType<AnyAction>) => {
  const { dispatch } = store;
  dispatch(actions.toastMessageStart());
  if (action.type === getType(actions.toastMessageGlobalSet)) {
    dispatch(actions.toastMessageSuccess(action.payload));
  }

  return next(action);
};

export default toastMiddleware;
