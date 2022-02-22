import { IQuestionSet } from "./IQuestionSet";
import { ITrueAnswer } from "./ITrueAnswer";

export interface IQuestion{
    id: number,
    text: string,
    questionSetid: number,
    questionSet: IQuestionSet | null,
    trueAnswer: ITrueAnswer | null
}