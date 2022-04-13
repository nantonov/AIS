import { createAction } from 'typesafe-actions';
import { TrueAnswer } from '../../interfaces/trueAnswer/trueAnswer';

const GET_BY_ID = 'GET_BY_ID';
export const getTrueAnswerById = createAction(GET_BY_ID)<TrueAnswer>();
