import React, {useEffect} from "react";
import {Grid} from "@mui/material";
import {connect} from "react-redux";
import {bindActionCreators, Dispatch} from "redux";
import {useNavigate} from "react-router-dom";
import {MainRoutes} from "../../core/constants/mainRoutes";
import QuestionAreaTableHeader from "./components/questionAreaTableHeader/QuestionAreaTableHeader";
import QuestionAreaTableRow from "./components/questionAreaTableRow/QuestionAreaTableRow";
import {questionAreasActionCreators} from "../../core/store/questionArea";
import {ApplicationState} from "../../core/store/typing";

const QuestionArea: React.FC<Props> = ({fetchQuestionAreas, fetchQuestionAreaById, questionAreas}) => {
    useEffect(() => {
        fetchQuestionAreas();
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
        fetchQuestionAreaById: questionAreasActionCreators.fetchQuestionAreaById,
        fetchQuestionAreas: questionAreasActionCreators.fetchAllQuestionAreas,
    }, dispatch);

type Props = ReturnType<typeof mapStateToProps> &
    ReturnType<typeof mapDispatchToProps>;

export default connect(mapStateToProps, mapDispatchToProps)(QuestionArea);
