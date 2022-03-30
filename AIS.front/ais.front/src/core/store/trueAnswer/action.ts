import { TrueAnswer } from './../../interfaces/trueAnswer';
import {createAction} from "typesafe-actions";

const GET_BY_ID= "GET_BY_ID"
export const getTrueAnswerById = createAction(GET_BY_ID)<TrueAnswer>();
