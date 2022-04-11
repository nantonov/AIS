import { InitQuestionSetState } from '../reducer/questionSetReducer';
import { RootState } from '../reducer/rootReducer';

const questionSetSelector = (state: RootState): InitQuestionSetState => state.questionSet;

export default questionSetSelector;
