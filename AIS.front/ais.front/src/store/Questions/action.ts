import { IQuestion } from './../../DTO/IQuestion';
import {createAction} from "typesafe-actions";

const FETCH_ALL="FETCH_ALL"

export const fetchAll = createAction(FETCH_ALL)<IQuestion[]>();
