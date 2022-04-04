import React from 'react';
import { useNavigate } from 'react-router-dom';
import { QuestionSet } from '../../../core/interfaces/questionSet/questionSet';
import QuestionSetContainer from '../../../core/components/itemContainer/ItemContainer';
import { QuestionSetDescriptionDiv, QuestionSetHeader, QuestionSetNameText } from './style';
import MainRoutes from '../../../core/constants/mainRoutes';

interface Props {
  questionSet: QuestionSet;
}

const QuestionSetItem: React.FC<Props> = ({ questionSet }) => {
  const navigate = useNavigate();
  const routeChange = (id: number) => () => {
    const path = `/${MainRoutes.questionSet}/${id}`;
    navigate(path);
  };
  return (
    <QuestionSetContainer onClick={routeChange(questionSet.id)}>
      <QuestionSetHeader>{questionSet.name}</QuestionSetHeader>
      <QuestionSetDescriptionDiv>
        <QuestionSetNameText>{questionSet.name}</QuestionSetNameText>
      </QuestionSetDescriptionDiv>
    </QuestionSetContainer>
  );
};

export default QuestionSetItem;
