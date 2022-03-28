import React, {useEffect, useState} from 'react';
import {useDispatch} from "react-redux";
import styled from "styled-components";
import {QuestionSetItem} from "./questionSetItem/QuestionSetItem";
import {getAllData} from '../../core/store/questionSets/actionCreator';
import {getAllData as getQuestions} from '../../core/store/questions/actionCreator';
import AddCircleIcon from '@mui/icons-material/AddCircle';
import Typography from "@mui/material/Typography";
import {Grid, Tooltip} from "@mui/material";
import {useNavigate} from "react-router-dom";
import {QuestionSet} from "../../core/interfaces/questionSet";

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
  margin-left: 90%;
  opacity: 1;

  &:hover {
    color: #0d4f91;
  }
`;

const QuestionSetItems = styled.div`
  display: flex;
  flex-wrap: wrap;
`;

const ToolTipContainer = styled(Tooltip)`
  display: flex;
`;

const TypographyContainer = styled(Typography)`
  display: flex;
  align-items: center;
`;

interface Props {
    questionSets: QuestionSet[]
}

const QuestionsSets: React.FC = () => {
    const[questionSets, setQuestionSets] = useState<QuestionSet[]>([]);
    const navigate = useNavigate();
    const dispatch = useDispatch();
    const routeChange = () => {
        const path = '/addQuestionSet';
        navigate(path);
    }

    useEffect(() => {
        dispatch(getAllData());
        dispatch(getQuestions());
    }, []);

    return (
        <Grid>
            <Grid item>
                <Container>
                    <QuestionSetItems>
                        {(questionSets.length !== 0) ? questionSets.map(item => {
                            return <QuestionSetItem key={item.id} questionSet={item}/>
                        }) : <TypographyContainer align="center" variant="h3">Something went wrong. Please refresh
                            page!!!.</TypographyContainer>}
                    </QuestionSetItems>
                </Container>
            </Grid>
            <Grid item>
                <ToolTipContainer title="Add question set" placement="left-start">
                    <CircleIconContainer onClick={routeChange}/>
                </ToolTipContainer>
            </Grid>
        </Grid>
    )
}

export default QuestionsSets;
