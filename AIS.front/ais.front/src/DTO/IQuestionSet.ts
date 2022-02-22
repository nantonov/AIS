import { IQuestion } from "./IQuestion";
import { IQuestionArea } from "./IQuestionArea";

export interface IQuestionSet{
    id: number,
    name: string,
    questionAreaId: number,
    questionArea: IQuestionArea | null,
    questions: IQuestion []
}