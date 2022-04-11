import React, { useEffect } from 'react';
import { useDispatch } from 'react-redux';
import { Button, Grid, Modal } from '@mui/material';
import { useTranslation } from 'react-i18next';
import { getAllQuestionSets } from '../../core/redux/thunk/questionSetThunk';
import QuestionSetItem from './questionSetItem/QuestionSetItem';
import { useTypedSelector } from '../../core/hooks/useTypedSelector';
import QuestionSetItems from '../../core/components/itemsContainer/ItemsContainer';
import Container from '../../core/components/container/Container';
import CircleIconContainer from '../../core/components/circleIconContainer/CircleIconContainer';
import ToolTipContainer from '../../core/components/toolTipContainer/ToolTipContainer';
import TypographyContainer from '../../core/components/typographyContainer/TypographyContainer';
import questionSetSelector from '../../core/redux/selectors/questionSetSelector';
import { BoxContainer, BoxStyle } from './style/BoxContainer';
import QuestionSetAdd from '../questionSetAdd/QuestionSetAdd';

const QuestionsSets: React.FC = () => {
  const [open, setOpen] = React.useState(false);
  const handleOpen = () => setOpen(true);
  const handleClose = () => setOpen(false);
  const { questionSets } = useTypedSelector(questionSetSelector);
  const dispatch = useDispatch();

  const { t } = useTranslation();

  useEffect(() => {
    dispatch(getAllQuestionSets());
  }, [dispatch]);

  return (
    <Grid>
      <Grid item>
        <Container>
          <QuestionSetItems>
            {questionSets.length ? (
              questionSets.map((item) => <QuestionSetItem key={item.id} questionSet={item} />)
            ) : (
              <TypographyContainer align="center" variant="h3">
                {t('somethingWentWrongPleaseRefreshPage')}
              </TypographyContainer>
            )}
          </QuestionSetItems>
        </Container>
      </Grid>
      <Grid item>
        <ToolTipContainer title={t('addQuestionSet').toString()} placement="left-start">
          <Button onClick={handleOpen}>
            <CircleIconContainer />
          </Button>
        </ToolTipContainer>
      </Grid>
      <Modal
        open={open}
        onClose={handleClose}
        aria-labelledby="modal-modal-title"
        aria-describedby="modal-modal-description"
      >
        <BoxContainer sx={BoxStyle}>
          <QuestionSetAdd />
        </BoxContainer>
      </Modal>
    </Grid>
  );
};

export default QuestionsSets;
