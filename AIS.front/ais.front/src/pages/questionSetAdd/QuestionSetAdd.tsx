import {Box, Button, FormControl, Grid, MenuItem, TextField} from "@mui/material";
import Typography from "@mui/material/Typography";
import React, {useEffect, useState} from "react";
import styled from "styled-components";
import {useDispatch} from "react-redux";
import {QuestionSet, QuestionSetAddState} from "../../core/interfaces/questionSet";
import {IQuestionSetAddDefault} from "../../core/common/defaultDTO/defaultQuestionSet";
import {QuestionSetService} from "../../core/services/questionSetService";
import {useNavigate} from "react-router-dom";
import {Question} from "../../core/interfaces/question";
import {QuestionArea} from "../../core/interfaces/questionArea";
import {getAllData} from "../../core/store/questionSets/actionCreator";
import {getAllData as getQuestions} from "../../core/store/questions/actionCreator"
import {fetchAllQuestionAreas} from "../../core/store/questionArea/actionCreators";

const BoxContainer = styled(Box)`
  display: flex;
  align-items: center;
  justify-content: space-around;
  padding-top: 20px;
`;

const GridContainer = styled(Grid)`
  width: 100%;
  max-width: 1170px;
  margin: auto;
`;

const ButtonContainer = styled(Button)`
  left: 90%;
`;

interface Props{
    questionSets: QuestionSet[],
    questions: Question[],
    questionAreas: QuestionArea[]
}

const QuestionSetAdd: React.FC = () => {

    const [questionSetModel, setQuestionSetModel] = useState<QuestionSetAddState>(IQuestionSetAddDefault)
    const [questionSets, setQuestionSets] = useState<QuestionSet[]>([]);
    const [questions, setQuestions] = useState<Question[]>([]);
    const [questionAreas, setQuestionAreas] = useState<QuestionArea[]>([]);

    const navigate = useNavigate();
    const dispatch = useDispatch();

    const routeChange = () => {
        const path = '/questionSetDescription';
        navigate(path);
    }

    function saveAction() {
        QuestionSetService.addQuestionSet(questionSetModel);
        routeChange()
    }

    const changeNameHandler = (e: React.ChangeEvent<HTMLInputElement>) => {
        setQuestionSetModel({
            ...questionSetModel,
            name: e.target.value
        });
    }

    useEffect(() => {
        dispatch(getAllData());
        dispatch(getQuestions());
        dispatch(fetchAllQuestionAreas());
    }, []);

    function addEmptyQuestionIdsArray() {
        const previousQuestionArray = [...questionSetModel.questionIds];
        previousQuestionArray.push(0);
        setQuestionSetModel({
            ...questionSetModel,
            questionIds: previousQuestionArray
        })
    }

    function getQuestionAreaOptions(id: number) {
        const idsQuestionAreas = new Set([...questionSetModel.questionAreaIds]);
        return questionAreas.filter((item) => {

            return !idsQuestionAreas.has(item.id) || item.id === id;
        })
    }

    function getQuestionOptions(id: number) {
        const idsSet = new Set([...questionSetModel.questionIds]);
        return questions.filter((item) => {
            return !idsSet.has(item.id) || item.id === id;
        });
    }

    function changeQuestionHandler(index: number, id: number) {
        const array = [...questionSetModel.questionIds];
        array[index] = id;
        setQuestionSetModel({
            ...questionSetModel,
            questionIds: array
        })
    }

    function addEmptyQuestionArea() {
        const previousQuestionAreasIdsArray = [...questionSetModel.questionAreaIds];
        previousQuestionAreasIdsArray.push(0);
        setQuestionSetModel({
            ...questionSetModel,
            questionAreaIds: previousQuestionAreasIdsArray
        })
    }

    function changeQuestionAreaHandler(index: number, id: number) {
        const array = [...questionSetModel.questionAreaIds];
        array[index] = id;
        setQuestionSetModel({
            ...questionSetModel,
            questionAreaIds: array
        })
    }

    return (
        <GridContainer>
            <Grid item>
                <BoxContainer>
                    <Typography>Question set name: </Typography>
                    <FormControl>
                        <TextField
                            required
                            id="outlined-required"
                            label="Required"
                            sx={{width: 180}}
                            value={questionSetModel.name}
                            onChange={changeNameHandler}
                        />
                    </FormControl>
                </BoxContainer>

            </Grid>
            <Grid item>
                {questionSetModel.questionAreaIds.map((item, index) => (
                    <BoxContainer key={item}>
                        <Typography>Select question area: </Typography>
                        <TextField
                            id="outlined-select-question-area"
                            select
                            label="Select"
                            helperText="Please select question area"
                            value={item}
                            onChange={(e) =>
                                changeQuestionAreaHandler(index, Number(e.target.value))
                            }>
                            {getQuestionAreaOptions(item).map((questionArea) => (
                                <MenuItem key={questionArea.id} value={questionArea.id}>
                                    {questionArea.name}
                                </MenuItem>
                            ))}
                        </TextField>
                    </BoxContainer>
                ))}
                <ButtonContainer disabled={questionSets.length <= questionSetModel.questionAreaIds.length}
                                 variant="contained" onClick={addEmptyQuestionArea}>Add question area</ButtonContainer>
            </Grid>

            <Grid item>
                {questionSetModel.questionIds.map((item, index) => (
                    <BoxContainer key={item}>
                        <Typography>Select question: </Typography>
                        <TextField
                            id="outlined-select-question"
                            select
                            label="Select"
                            helperText="Please select question"
                            value={item}
                            defaultValue={questionSetModel.questionIds[0]}
                            onChange={(e) =>
                                changeQuestionHandler(index, Number(e.target.value))
                            }
                        >
                            {getQuestionOptions(item).map((question) => (
                                <MenuItem key={question.id} value={question.id}>
                                    {question.text}
                                </MenuItem>
                            ))}
                        </TextField>
                    </BoxContainer>
                ))}
                <ButtonContainer disabled={questions.length <= questionSetModel.questionIds.length}
                                 variant="contained" onClick={addEmptyQuestionIdsArray}>Add
                    question</ButtonContainer>
            </Grid>
            <Grid item>
                <ButtonContainer variant="contained" onClick={saveAction}>Add question set</ButtonContainer>
            </Grid>
        </GridContainer>
    )
}

export default QuestionSetAdd;
