import {createAction} from "typesafe-actions";
import {Question} from "../../interfaces/question";

const FETCH_ALL="QUESTIONS/FETCH_ALL"

export const fetchAll = createAction(FETCH_ALL)<Question[]>();
