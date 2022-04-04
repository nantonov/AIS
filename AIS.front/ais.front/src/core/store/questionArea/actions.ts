import { createAction } from 'typesafe-actions';
import { QuestionArea } from '../../interfaces/questionArea/questionArea';
import { FETCH_ALL, FETCH_BY_ID } from './constants';

export const fetchAll = createAction(FETCH_ALL)<QuestionArea[]>();
export const fetchById = createAction(FETCH_BY_ID)<QuestionArea>();
