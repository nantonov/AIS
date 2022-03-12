import React, {useEffect} from 'react';
import {bindActionCreators, Dispatch} from 'redux';
import {ApplicationState} from "../../store/typing";
import {connect} from "react-redux";
import {questionSetActionCreators} from "../../store/QuestionSets";
import styled from "styled-components";
import {QuestionSetItem} from '../QuestionSetItem/QuestionSetItem'
import {Button} from "@mui/material";
import AddCircleIcon from '@mui/icons-material/AddCircle';
import QuestionSetAdd from "../QuestionSet/QuestionSetAdd";

const QuestionsSets: React.FC<Props> = ({questionSets, getAllData}) => {
    const Container = styled.div`
      width: 100%;
      max-width: 1170px;
      margin: auto;
    `;

    const CircleIconContainer = styled(AddCircleIcon)`
          color: #1976d2;
          fontSize: "large";
          font-size: 3.0rem;
          display: flex;
          align-items: flex-start;
        `;

    const QuestionSetItems = styled.div`
      display: flex;
      flex-wrap: wrap;
    `;

    useEffect(() => {
        getAllData();
    }, []);

    return (
        <Container >
            <QuestionSetItems>
                {questionSets.map(item => {
                    return <QuestionSetItem key={item.id} item={item}/>
                })}
            </QuestionSetItems>
            {/*<Button onClick={OpenFromAddQuestionSet}>Test</Button>*/}
            {/*<CircleIconContainer onClick={OpenFromAddQuestionSet}/>*/}
        </Container>
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


type Props = ReturnType<typeof mapStateToProps> &
    ReturnType<typeof mapDispatchToProps>;

export default connect(mapStateToProps, mapDispatchToProps)(QuestionsSets);
