import React, {useEffect} from 'react';
import {bindActionCreators, Dispatch} from 'redux';
import {ApplicationState} from "../../core/store/typing";
import {connect} from "react-redux";
import { Button, Grid, Typography } from '@mui/material';
import { questionsActionCreators } from '../../core/store/questions';
import { QuestionComponent } from './components';
import { trueAnswerActionCreators } from '../../core/store/trueAnswer';
import AddCircleIcon from '@mui/icons-material/AddCircle';

const Questions: React.FC<Props> = ({questions, getAllData,deleteQuestion,updateQuestion,updateTrueAnswer}) => {

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
              <Typography variant="h5">Questions</Typography>
            </Grid>

            <Grid pt={1} pb={1}>
              <Button variant="contained" startIcon={<AddCircleIcon />}>
                Add question
              </Button>
            </Grid>

            {questions.map(item => {
                    return <QuestionComponent key={item.id} item={item} deleteQuestion={deleteQuestion} updateQuestion={updateQuestion} updateTrueAnswer ={updateTrueAnswer}></QuestionComponent>
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
        getAllData: questionsActionCreators.getAllData,
        deleteQuestion : questionsActionCreators.deleteQuestion,
        updateQuestion: questionsActionCreators.editQuestion,
        updateTrueAnswer: trueAnswerActionCreators.editTrueAnswer
    }, dispatch);


type Props = ReturnType<typeof mapStateToProps> &
    ReturnType<typeof mapDispatchToProps>;

export default connect(mapStateToProps, mapDispatchToProps)(Questions);
