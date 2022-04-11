import { combineReducers } from 'redux';
import questionAreaReducer from './questionAreaReducer';
import questionReducer from './questionReducer';
import questionSetReducer from './questionSetReducer';
import toastMessageReducer from './toastMessageReducer';

export const rootReducer = combineReducers({
  questionArea: questionAreaReducer,
  questionSet: questionSetReducer,
  question: questionReducer,
  toast: toastMessageReducer,
});

export type RootState = ReturnType<typeof rootReducer>;
