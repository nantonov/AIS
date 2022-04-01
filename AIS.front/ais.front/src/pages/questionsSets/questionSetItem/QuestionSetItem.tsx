import React from 'react';
import styled from 'styled-components';
import { useNavigate } from 'react-router-dom';
import { QuestionSet } from '../../../core/interfaces/questionSet/questionSet';

const QuestionSetContainer = styled.div`
  background-color: #ffffff;
  box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2);
  padding: 10px;
  margin: 15px;
  cursor: pointer;
  flex: 0 0 25%;
  opacity: 1;

  &:hover {
    background-color: #c5bebe;
  }
`;

const QuestionSetHeader = styled.h1`
  height: 76px;
`;

const QuestionSetDescriptionDiv = styled.div`
  display: flex;
  justify-content: space-between;
`;

const QuestionSetNameText = styled.div``;

interface Props {
  questionSet: QuestionSet;
}

const QuestionSetItem: React.FC<Props> = ({ questionSet }) => {
  const navigate = useNavigate();
  const routeChange = (id: number) => () => {
    const path = `/questionSetDescription/${id}`;
    navigate(path);
  };
  return (
    <QuestionSetContainer
      onClick={routeChange(questionSet.id)}
    >
      <QuestionSetHeader>{questionSet.name}</QuestionSetHeader>
      <QuestionSetDescriptionDiv>
        <QuestionSetNameText>{questionSet.name}</QuestionSetNameText>
      </QuestionSetDescriptionDiv>
    </QuestionSetContainer>
  );
};

export default QuestionSetItem;
