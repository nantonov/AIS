import { createAction } from 'typesafe-actions';
import { Question } from '../../interfaces/question/question';

const FETCH_ALL = 'QUESTIONS/FETCH_ALL';
// eslint-disable-next-line  import/prefer-default-export
export const fetchAll = createAction(FETCH_ALL)<Question[]>();
