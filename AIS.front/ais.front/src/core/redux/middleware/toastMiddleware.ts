import { AnyAction, Middleware } from 'redux';
import { ActionType, getType } from 'typesafe-actions';
import * as actions from '../actionCreators/toastMessageAction';

const toastMiddleware: Middleware = (store) => (next) => (action: ActionType<AnyAction>) => {
  const { dispatch } = store;
  dispatch(actions.setToastMessageStart());
  if (action.type === getType(actions.setToastMessageGlobalSet)) {
    dispatch(actions.setToastMessageSuccess(action.payload));
  }

  return next(action);
};

export default toastMiddleware;
