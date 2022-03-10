import React, {useEffect} from 'react';
import {bindActionCreators, Dispatch} from 'redux';
import {ApplicationState} from "../../store/typing";
import {connect} from "react-redux";
import {questionSetActionCreators} from "../../store/QuestionSets";
import styled from "styled-components";
import {QuestionSetItem} from '../QuestionSetItem/QuestionSetItem'


const QuestionsSets: React.FC<Props> = ({questionSets, getAllData}) => {
    const Container = styled.div`
      width: 100%;
      max-width: 1170px;
      margin: auto;
    `;

    const QuestionSetItems = styled.div`
      display: flex;
      flex-wrap: wrap;
    `;

    useEffect(() => {
        getAllData();
    }, []);

    return (
        <Container>
            <QuestionSetItems>
                {questionSets.map(item => {
                    return <QuestionSetItem key={item.id} item={item} />
                })}
            </QuestionSetItems>
        </Container>
    )
}


const mapStateToProps = (state: ApplicationState) => ({
    router: state.router,
    questionSets: state.questionSets.questionSets
});

const mapDispatchToProps = (dispatch: Dispatch) =>
    bindActionCreators({
        getAllData: questionSetActionCreators.getAllData
    }, dispatch);


type Props = ReturnType<typeof mapStateToProps> &
    ReturnType<typeof mapDispatchToProps>;

export default connect(mapStateToProps, mapDispatchToProps)(QuestionsSets);
