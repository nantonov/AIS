import { createAction } from 'typesafe-actions';
import { IQuestionArea} from '../../DTO/IQuestionArea'
import { FETCH_ALL, FETCH_BY_ID} from './constants';

export const fetchAll = createAction(FETCH_ALL)<IQuestionArea[]>();
export const fetchById = createAction(FETCH_BY_ID)<IQuestionArea>();
