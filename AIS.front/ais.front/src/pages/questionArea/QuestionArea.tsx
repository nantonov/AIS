import React, {useEffect} from "react";
import {Grid} from "@mui/material";
import {connect, useDispatch} from "react-redux";
import {bindActionCreators, Dispatch} from "redux";
import {useNavigate} from "react-router-dom";
import {MainRoutes} from "../../core/constants/mainRoutes";
import QuestionAreaTableHeader from "./components/questionAreaTableHeader/QuestionAreaTableHeader";
import QuestionAreaTableRow from "./components/questionAreaTableRow/QuestionAreaTableRow";
import {ApplicationState} from "../../core/store/typing";
import {fetchAllQuestionAreas, fetchQuestionAreaById} from "../../core/store/questionArea/actionCreators";
import {QuestionArea as questionArea} from "../../core/interfaces/questionArea";

interface Props{
    questionAreas: questionArea[]
}

const QuestionArea: React.FC<Props> = ({questionAreas}) => {
    const dispatch = useDispatch();

    useEffect(() => {
        dispatch(fetchAllQuestionAreas());
    }, []);

    const navigate = useNavigate();
    const edit = (id: number) => {
        fetchQuestionAreaById(id);
        navigate(`/${MainRoutes.questionAreaForm}/${id}`);
    }

    return (
        <Grid container justifyContent="space=between"
              alignItems="center">
            <QuestionAreaTableHeader/>
            {questionAreas.map((item) =>
                <QuestionAreaTableRow key={item.id} qArea={item} onEdit={edit.bind(this)}/>
            )}
        </Grid>
    );
};


const mapStateToProps = (state: ApplicationState) => ({
    questionAreas: state.questionAreas.questionAreas
});

const mapDispatchToProps = (dispatch: Dispatch) =>
    bindActionCreators({
    }, dispatch);

export default connect(mapStateToProps, mapDispatchToProps)(QuestionArea);
