import React, {useEffect, useState} from 'react';
import {bindActionCreators, Dispatch} from 'redux';
import {ApplicationState} from "../../core/store/typing";
import {connect} from "react-redux";
import { Button, Dialog, DialogActions, DialogContent, DialogContentText, DialogTitle, Grid, TextField, Typography } from '@mui/material';
import { questionsActionCreators } from '../../core/store/questions';
import { QuestionComponent } from './components';
import { trueAnswerActionCreators } from '../../core/store/trueAnswer';
import AddCircleIcon from '@mui/icons-material/AddCircle';
import { defaultTrueAnswer } from '../../core/common/defaultDTO/defaultTrueAnswer';
import { TrueAnswer } from '../../core/interfaces/trueAnswer';
import { Question } from '../../core/interfaces/question';
import { defaultQuestion } from '../../core/common/defaultDTO/defaultQuestion';
import { AddQuestionDialog } from './components/AddQuestionDialog';

const Questions: React.FC<Props> = ({questions, getAllData,deleteQuestion,updateQuestion,updateTrueAnswer}) => {
  
  const [open, setOpen] = React.useState(false);

  const handleClickOpen = () => {
    setOpen(true);
  };

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

            <Grid pt={1} pb={1} >
              <Button variant="contained" startIcon={<AddCircleIcon />} onClick={handleClickOpen}>
                Add question
              </Button>

              <AddQuestionDialog open={open} setOpen={setOpen}></AddQuestionDialog>

              {/* <Dialog open={open} onClose={handleClose} 
              PaperProps={{ sx: { width: "75%", height: "50%" } }}>

                <DialogTitle color='primary'>New question</DialogTitle>

                <DialogContent>
                  
                  <Typography>Question</Typography>
                  <TextField 
                      fullWidth
                      autoFocus
                      type='text'
                      value={question.text}
                      onChange={(event) => {
                        setQuestion((prev: Question) => ({ ...prev, text: event.target.value }))
                      }}
                    />
        
                  <Typography pt={2}>True Answer</Typography>
                  <TextField
                    id="standard-multiline-flexible"
                    fullWidth
                    multiline
                    maxRows={8}
                    value={trueAnswer.text}
                    onChange={(event) => {
                      setTrueAnswer((prev: TrueAnswer) => ({ ...prev, text: event.target.value }))
                    }}
                  />

                </DialogContent>
                <DialogActions>
                  <Button onClick={handleClose} variant="contained">Cancel</Button>
                  <Button onClick={handleClose} variant="contained">Add</Button>
                </DialogActions>
              </Dialog> */}
              
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
