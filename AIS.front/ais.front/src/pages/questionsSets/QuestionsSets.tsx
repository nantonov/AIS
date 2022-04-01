import React, { useEffect } from 'react';
import { useDispatch } from 'react-redux';
import { Grid } from '@mui/material';
import { useNavigate } from 'react-router-dom';
import { getAllData } from '../../core/store/questionSets/actionCreator';
import QuestionSetItem from './questionSetItem/QuestionSetItem';
import { useTypedSelector } from '../../core/hooks/useTypedSelector';
import QuestionSetItems from '../../core/components/itemsContainer/ItemsContainer';
import Container from '../../core/components/container/Container';
import CircleIconContainer from '../../core/components/circleIconContainer/CircleIconContainer';
import ToolTipContainer from '../../core/components/toolTipContainer/ToolTipContainer';
import TypographyContainer from '../../core/components/typographyContainer/TypographyContainer';
import MainRoutes from '../../core/constants/mainRoutes';

const QuestionsSets: React.FC = () => {
  const questionSets = useTypedSelector((state) => state.questionSets.questionSets);
  const navigate = useNavigate();
  const dispatch = useDispatch();
  const routeChange = () => {
    const path = `/${MainRoutes.addQuestionSet}`;
    navigate(path);
  };

  useEffect(() => {
    dispatch(getAllData());
  }, [dispatch]);

  return (
    <Grid>
      <Grid item>
        <Container>
          <QuestionSetItems>
            {questionSets.length !== 0 ? (
              questionSets.map((item) => <QuestionSetItem key={item.id} questionSet={item} />)
            ) : (
              <TypographyContainer align="center" variant="h3">
                Something went wrong. Please refresh page!!!.
              </TypographyContainer>
            )}
          </QuestionSetItems>
        </Container>
      </Grid>
      <Grid item>
        <ToolTipContainer title="Add question set" placement="left-start">
          <CircleIconContainer onClick={routeChange} />
        </ToolTipContainer>
      </Grid>
    </Grid>
  );
};

export default QuestionsSets;
