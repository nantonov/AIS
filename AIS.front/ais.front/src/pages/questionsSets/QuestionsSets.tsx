import React, {useEffect} from 'react';
import {bindActionCreators, Dispatch} from 'redux';
import {ApplicationState} from "../../core/store/typing";
import {connect} from "react-redux";
import {questionSetActionCreators} from "../../core/store/questionSets";
import styled from "styled-components";
import {QuestionSetItem} from "../questionSetItem/QuestionSetItem";
import AddCircleIcon from '@mui/icons-material/AddCircle';
import Typography from "@mui/material/Typography";
import {Grid, Tooltip} from "@mui/material";
import {questionsActionCreators} from "../../core/store/questions";
import {useNavigate} from "react-router-dom";

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

const QuestionsSets: React.FC<Props> = ({questionSets, getAllData, getQuestions}) => {
    let navigate = useNavigate();
    const routeChange = () => {
        let path = '/addQuestionSet';
        navigate(path);
    }

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
                    <CircleIconContainer onClick={routeChange}/>
                </ToolTipContainer>
            </Grid>
        </Grid>
    )
}

const mapStateToProps = (state: ApplicationState) => ({
    router: state.router,
    questionSets: state.questionSets.questionSets,
    questions: state.questions.questions
});

const mapDispatchToProps = (dispatch: Dispatch) =>
    bindActionCreators({
        getAllData: questionSetActionCreators.getAllData,
        getQuestions: questionsActionCreators.getAllData
    }, dispatch);

type Props = ReturnType<typeof mapStateToProps> &
    ReturnType<typeof mapDispatchToProps>;

export default connect(mapStateToProps, mapDispatchToProps)(QuestionsSets);
