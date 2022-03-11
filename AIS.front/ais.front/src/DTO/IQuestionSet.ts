import { IQuestion } from "./IQuestion";
import { IQuestionArea } from "./IQuestionArea";

export interface IQuestionSet{
    id: number,
    name: string,
    questionAreaId: number,
    questionAreas: IQuestionArea[] | null,
    questions: IQuestion []
}
