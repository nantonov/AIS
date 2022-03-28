import React, {useEffect} from 'react';
import {bindActionCreators, Dispatch} from 'redux';
import {ApplicationState} from "../../store/typing";
import {connect} from "react-redux";
import styled from "styled-components";
import { Grid, Typography } from '@mui/material';
import { questionActionCreators } from '../../store/Questions';
import { Question } from '../Question';


const Questions: React.FC<Props> = ({questions, getAllData,deleteQuestion,updateQuestion}) => {
    const Container = styled.div`
      text-algi
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
            <Grid pt={1} pb={1}>
            <   Typography variant="h5" >Questions</Typography>
            </Grid>
            {questions.map(item => {
                    return <Question key={item.id} item={item} deleteQuestion={deleteQuestion} updateQuestion={updateQuestion}></Question>
                })}
        </Grid>
    )
}


const mapStateToProps = (state: ApplicationState) => ({
    router: state.router,
    questions: state.questions.questions
});

const mapDispatchToProps = (dispatch: Dispatch) =>
    bindActionCreators({
        getAllData: questionActionCreators.getAllData,
        deleteQuestion : questionActionCreators.deleteQuestion,
        updateQuestion:questionActionCreators.editQuestion
    }, dispatch);


type Props = ReturnType<typeof mapStateToProps> &
    ReturnType<typeof mapDispatchToProps>;

export default connect(mapStateToProps, mapDispatchToProps)(Questions);
