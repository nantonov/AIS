import { Question } from "./question";
import { QuestionArea } from "./questionArea";

export interface QuestionSet{
    id: number,
    name: string,
    questionAreaId: number,
    questionAreas: QuestionArea[] | null,
    questions: Question []
}
export interface QuestionSetAddState {
    name: string,
    questionAreaIds: number[],
    questionIds: number[]
}
