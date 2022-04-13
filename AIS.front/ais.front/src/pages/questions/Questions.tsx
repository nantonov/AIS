import React, { useEffect } from 'react';
import { connect } from 'react-redux';
import { Button, Grid, Typography } from '@mui/material';
import AddCircleIcon from '@mui/icons-material/AddCircle';
import { bindActionCreators, Dispatch } from 'redux';
import { AddQuestionDialog } from './components/AddQuestionDialog';
import { ApplicationState } from '../../core/store/typing';
import { questionsActionCreators } from '../../core/store/questions';
import { trueAnswerActionCreators } from '../../core/store/trueAnswer';
import { QuestionComponent } from './components';

const Questions: React.FC<Props> = ({
  questions,
  getAllData,
  deleteQuestion,
  updateQuestion,
  updateTrueAnswer,
}) => {
  const [open, setOpen] = React.useState(false);

  const handleClickOpen = () => {
    setOpen(true);
  };

  useEffect(() => {
    getAllData();
  }, []);

  return (
    <Grid container direction="column" justifyContent="center" alignItems="center">
      <Grid pt={1} pb={1}>
        <Typography variant="h5">Questions</Typography>
      </Grid>

      <Grid pt={1} pb={1}>
        <Button variant="contained" startIcon={<AddCircleIcon />} onClick={handleClickOpen}>
          Add question
        </Button>

        <AddQuestionDialog open={open} setOpen={setOpen} />
      </Grid>

      {questions.map((item) => (
        <QuestionComponent
          key={item.id}
          item={item}
          deleteQuestion={deleteQuestion}
          updateQuestion={updateQuestion}
          updateTrueAnswer={updateTrueAnswer}
        />
      ))}
    </Grid>
  );
};

const mapStateToProps = (state: ApplicationState) => ({
  questions: state.questions.questions,
});

const mapDispatchToProps = (dispatch: Dispatch) =>
  bindActionCreators(
    {
      getAllData: questionsActionCreators.getAllData,
      deleteQuestion: questionsActionCreators.deleteQuestion,
      updateQuestion: questionsActionCreators.editQuestion,
      updateTrueAnswer: trueAnswerActionCreators.editTrueAnswer,
    },
    dispatch
  );

type Props = ReturnType<typeof mapStateToProps> & ReturnType<typeof mapDispatchToProps>;

export default connect(mapStateToProps, mapDispatchToProps)(Questions);
