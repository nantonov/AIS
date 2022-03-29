import React from 'react';
import {bindActionCreators, Dispatch} from 'redux';
import {ApplicationState} from "../../../core/store/typing";
import {connect} from "react-redux";
import {questionSetActionCreators} from "../../../core/store/questionSets";
import styled from "styled-components";
import {QuestionSet} from "../../../core/interfaces/questionSet";
import {useNavigate} from "react-router-dom";

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

const QuestionSetNameText = styled.text``;


interface propsFromComponent {
    item: QuestionSet;
}

interface propsFromDispatch {
}

type Props = propsFromComponent & propsFromDispatch;

export const QuestionSetItem: React.FC<Props> = ({item}) => {
    const navigate = useNavigate();
    const routeChange = (id: number) => {
        const path = `/questionSetDescription/${id}`;
        navigate(path);
    }
    return (
        <QuestionSetContainer onClick={() => {
            routeChange(item.id)
        }}>
            <QuestionSetHeader>{item.name}</QuestionSetHeader>
            <QuestionSetDescriptionDiv>
                <QuestionSetNameText>{item.name}</QuestionSetNameText>
            </QuestionSetDescriptionDiv>
        </QuestionSetContainer>
    )
}

const mapStateToProps = (state: ApplicationState) => ({
    router: state.router,
    questionSets: state.questionSets.questionSets
});

const mapDispatchToProps = (dispatch: Dispatch) =>
    bindActionCreators({
        getAllData: questionSetActionCreators.getAllData
    }, dispatch);

connect(mapStateToProps, mapDispatchToProps)(QuestionSetItem);
