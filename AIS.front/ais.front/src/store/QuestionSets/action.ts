import {IQuestionSet} from "../../DTO/IQuestionSet";
import {createAction} from "typesafe-actions";

const FETCH_ALL="FETCH_ALL"
const GET_BY_ID= "GET_BY_ID"

export const fetchAll = createAction(FETCH_ALL)<IQuestionSet[]>();
export const getQuestionSetById = createAction(GET_BY_ID)<IQuestionSet>();
