import { createAction } from 'typesafe-actions';
import { QuestionSet } from '../../interfaces/questionSet/questionSet';

const FETCH_ALL = 'QUESTION_SET/FETCH_ALL';
const GET_BY_ID = 'GET_BY_ID';

export const fetchAll = createAction(FETCH_ALL)<QuestionSet[]>();
export const getQuestionSetById = createAction(GET_BY_ID)<QuestionSet>();
