import { IQuestionSet } from "./IQuestionSet";

export interface IQuestionArea{
    id: number,
    name: string,
    questionSets: IQuestionSet[]
}