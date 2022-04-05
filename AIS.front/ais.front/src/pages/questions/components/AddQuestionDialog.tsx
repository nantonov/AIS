import React, {useEffect, useState} from 'react';
import { Button, Dialog, DialogActions, DialogContent, DialogContentText, DialogTitle, Grid, TextField, Typography } from '@mui/material';
import { Question } from '../../../core/interfaces/question';
import { defaultQuestion } from '../../../core/common/defaultDTO/defaultQuestion';
import { defaultTrueAnswer } from '../../../core/common/defaultDTO/defaultTrueAnswer';
import { TrueAnswer } from '../../../core/interfaces/trueAnswer';

interface propsFromComponent {
    open: boolean;
    setOpen: (open:boolean) => void,
    // updateQuestion:(question :Question) =>void
    // updateTrueAnswer:(trueAnswer :TrueAnswer) =>void
}
interface propsFromDispatch { 
}

type Props = propsFromComponent & propsFromDispatch;

export const AddQuestionDialog: React.FC<Props> = ({setOpen,open}) => {
  const [question, setQuestion] = useState<Question>(defaultQuestion);
  const [trueAnswer, setTrueAnswer] = useState<TrueAnswer>(defaultTrueAnswer);

  const handleClose = () => {
    setOpen(false);
  };
    // useEffect(() => {
    //     getAllData();
    // }, []);

    return (
        <Dialog open={open} onClose={handleClose} 
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
            </Dialog>    
    )
}


// const mapStateToProps = (state: ApplicationState) => ({
//     router: state.router,
//     questions: state.questions.questions
// });

// const mapDispatchToProps = (dispatch: Dispatch) =>
//     bindActionCreators({
//         getAllData: questionsActionCreators.getAllData,
//         deleteQuestion : questionsActionCreators.deleteQuestion,
//         updateQuestion: questionsActionCreators.editQuestion,
//         updateTrueAnswer: trueAnswerActionCreators.editTrueAnswer
//     }, dispatch);


// type Props = ReturnType<typeof mapStateToProps> &
//     ReturnType<typeof mapDispatchToProps>;

// export default connect(mapStateToProps, mapDispatchToProps)(AddQuestionDialog);