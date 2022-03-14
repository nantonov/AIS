import React from 'react';
import {bindActionCreators, Dispatch} from 'redux';
import {ApplicationState} from "../../store/typing";
import {connect} from "react-redux";
import {questionSetActionCreators} from "../../store/QuestionSets";
import styled from "styled-components";
import {IQuestionSet} from "../../DTO/IQuestionSet";
import {Button} from "@mui/material";
import {useNavigate} from "react-router-dom";

interface propsFromComponent {
    item: IQuestionSet;
}

interface propsFromDispatch {
}

type Props = propsFromComponent & propsFromDispatch;

export const QuestionSetItem: React.FC<Props> = ({item}: Props) => {
    let navigate = useNavigate();
    const routeChange = (id: number) => {
        let path = '/questionSet/' + id;
        navigate(path);
    }

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

    const QuestionSetFigure = styled.figure`
      width: 230px;
      height: 100px;
      display: flex;
      justify-content: center;
      align-items: center;
    `;

    const QuestionSetHeader = styled.h1`
      height: 76px;
    `;

    const QuestionSetDescriptionDiv = styled.div`
      display: flex;
      justify-content: space-between;
   
    `;

    const QuestionSetNameText = styled.text``;

    const Description = styled.button`
      padding: 10px;
      background-color: blue;
      color: #ffffff;
      border-radius: 10px;
    `;

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
