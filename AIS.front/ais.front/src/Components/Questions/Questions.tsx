import React, {useEffect} from 'react';
import {bindActionCreators, Dispatch} from 'redux';
import {ApplicationState} from "../../store/typing";
import {connect} from "react-redux";
import styled from "styled-components";
import { Grid } from '@mui/material';
import { questionActionCreators } from '../../store/Questions';
import { Question } from '../Question';


const Questions: React.FC<Props> = ({questions, getAllData,deleteQuestion}) => {
    const Container = styled.div`
      width: 100%;
      max-width: 1170px;
      margin: auto;
    `;

    const QuestionSetItems = styled.div`
      display: flex;
      flex-wrap: wrap;
    `;

    useEffect(() => {
        getAllData();
    }, []);


    return (
        <Grid
        container
        direction="column"
        justifyContent="center"
        alignItems="center"
        >
            {questions.map(item => {
                    return <Question key={item.id} item={item} deleteQuestion={deleteQuestion}></Question>
                })}
            

            {/* {questions.map(item => {
                return <Question id={item.id} text={item.text} questionSetid={0} questionSet={null} trueAnswer={null}>
                })} */}

            {/* <Question id={1} text={'Describe props in react?'} questionSetid={0} questionSet={null} trueAnswer={null}></Question>
            <Question id={2} text={'Describe Component in react?'} questionSetid={0} questionSet={null} trueAnswer={null}></Question> */}
        </Grid>

        // <Container>
        //     <QuestionSetItems>
        //         {questions.map(item => {
        //             return <QuestionSetItem key={item.id} item={item} />
        //         })}
        //     </QuestionSetItems>
        // </Container>
    )
}


const mapStateToProps = (state: ApplicationState) => ({
    router: state.router,
    questions: state.questions.questions
});

const mapDispatchToProps = (dispatch: Dispatch) =>
    bindActionCreators({
        getAllData: questionActionCreators.getAllData,
        deleteQuestion : questionActionCreators.deleteQuestion
    }, dispatch);


type Props = ReturnType<typeof mapStateToProps> &
    ReturnType<typeof mapDispatchToProps>;

export default connect(mapStateToProps, mapDispatchToProps)(Questions);
