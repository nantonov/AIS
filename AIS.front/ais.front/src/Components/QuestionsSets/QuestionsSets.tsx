import React, {useEffect, useState} from 'react';
import {bindActionCreators, Dispatch} from 'redux';
import {ApplicationState} from "../../store/typing";
import {connect} from "react-redux";
import {questionSetActionCreators} from "../../store/QuestionSets";
import styled from "styled-components";
import {QuestionSetItem} from '../QuestionSetItem/QuestionSetItem'
import AddCircleIcon from '@mui/icons-material/AddCircle';
import Typography from "@mui/material/Typography";
import {Box, Grid, MenuItem, Modal, TextField, Tooltip} from "@mui/material";
import {questionsActionCreators} from "../../store/Questions";


const QuestionsSets: React.FC<Props> = ({questionSets, getAllData, questions,getQuestions}) => {

    const [getOpenAddMenu, setOpenAddMenu] = useState(false);

    const Container = styled.div`
      width: 100%;
      max-width: 1170px;
      margin: auto;
    `;

    const CircleIconContainer = styled(AddCircleIcon)`
      color: #1976d2;
      fontSize: "large";
      font-size: 3.5rem;
      display: flex;
      padding-left: 90%;
      opacity: 1;

      &:hover {
        color: #0d4f91;
      }`;

    const QuestionSetItems = styled.div`
      display: flex;
      flex-wrap: wrap;
    `;
    const TypographyContainer = styled(Typography)`
      align: "center";
      variant: "h3"
    `
    const ToolTipContainer = styled(Tooltip)`
      display: flex;
    `
    function openAddMenu(){
        setOpenAddMenu(true);
    }
    const handleClose = () => setOpenAddMenu(false);
    const style = {
        position: 'absolute',
        top: '50%',
        left: '50%',
        transform: 'translate(-50%, -50%)',
        width: 400,
        bgcolor: 'background.paper',
        border: '2px solid #000',
        boxShadow: 24,
        p: 4,
    };

    useEffect(() => {
        getAllData();
        getQuestions();
    }, []);

    return (
        <Grid>
            <Grid item>
                <Container>
                    <QuestionSetItems>
                        {(questionSets.length !== 0) ? questionSets.map(item => {
                            return <QuestionSetItem key={item.id} item={item}/>
                        }) : <TypographyContainer align="center" variant="h3">Something went wrong. Please refresh
                            page!!!.</TypographyContainer>}
                    </QuestionSetItems>
                </Container>
            </Grid>
            <Grid item>
                <ToolTipContainer title="Add question set" placement="left-start">
                    <CircleIconContainer onClick={openAddMenu}/>
                </ToolTipContainer>
            </Grid>
            <Grid item>
                <Modal
                    open={getOpenAddMenu}
                    onClose={handleClose}
                    aria-labelledby="modal-modal-title"
                    aria-describedby="modal-modal-description"
                >
                    <Box sx={style}>
                        <TextField
                            required
                            id="outlined-required"
                            label="Required"
                        />
                        <TextField
                            id="outlined-select-question-area"
                            select
                            label="Select"
                            // value={currency}
                            // onChange={handleChange}
                            helperText="Please select question area"
                        >
                            {questionSets.map((option) => (
                                <MenuItem key={option.id} value={option.name}>
                                    {option.name}
                                </MenuItem>
                            ))}
                        </TextField>
                        <TextField
                            id="outlined-select-question-area"
                            select
                            label="Select"
                            // value={currency}
                            // onChange={handleChange}
                            helperText="Please select question area"
                        >
                            {questions.questions.map((question) => (
                                <MenuItem key={question.id}>
                                    {question.text}
                                </MenuItem>
                            ))}
                        </TextField>
                        <Typography id="modal-modal-description" sx={{ mt: 2 }}>
                            Duis mollis, est non commodo luctus, nisi erat porttitor ligula.
                        </Typography>
                    </Box>
                </Modal>
            </Grid>
        </Grid>
    )
}


const mapStateToProps = (state: ApplicationState) => ({
    router: state.router,
    questionSets: state.questionSets.questionSets,
    questions: state.questions
});

const mapDispatchToProps = (dispatch: Dispatch) =>
    bindActionCreators({
        getAllData: questionSetActionCreators.getAllData,
        getQuestions: questionsActionCreators.getAllData
    }, dispatch);


type Props = ReturnType<typeof mapStateToProps> &
    ReturnType<typeof mapDispatchToProps>;

export default connect(mapStateToProps, mapDispatchToProps)(QuestionsSets);
