import { IQuestion } from "./IQuestion";
import { IQuestionArea } from "./IQuestionArea";

export interface IQuestionSet{
    id: number,
    name: string,
    questionAreaId: number,
    questionAreas: IQuestionArea[] | null,
    questions: IQuestion []
}
export interface IQuestionSetAdd {
    name: string,
    questionAreaIds: number[],
    questionIds: number[]
}
