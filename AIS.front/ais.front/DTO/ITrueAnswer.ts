import { IQuestion } from "./IQuestion";

export interface ITrueAnswer{
    id: number,
    text: string,
    questionId: number,
    question: IQuestion | null
}