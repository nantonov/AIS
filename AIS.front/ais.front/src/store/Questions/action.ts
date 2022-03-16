import {createAction} from "typesafe-actions";
import {IQuestion} from "../../DTO/IQuestion";

const FETCH_ALL="QUESTIONS/FETCH_ALL"

export const fetchAll = createAction(FETCH_ALL)<IQuestion[]>();
