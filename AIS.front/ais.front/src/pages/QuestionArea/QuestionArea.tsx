import React, { useEffect } from "react";
import {Grid, IconButton, styled, Typography} from "@mui/material";
import ExpandMoreIcon from '@mui/icons-material/ExpandMore';
import EditIcon from '@mui/icons-material/Edit';
import DeleteIcon from '@mui/icons-material/Delete';
import { IQuestionArea } from "../../core/DTO/IQuestionArea";
import { ApplicationState } from "../../core/store/typing";
import { connect } from "react-redux";
import { questionAreasActionCreators } from "../../core/store/QuestionArea";
import {bindActionCreators, Dispatch } from "redux";
import {useNavigate} from "react-router-dom";
import {MainRoutes} from "../../core/constants/mainRoutes";

const QuestionArea: React.FC<Props> = (props) =>{
    useEffect(() => {
        props.fetchQuestionAreas();
    }, []);
    const navigate = useNavigate();
    const edit = (id: number) => {
        props.fetchQuestionAreaById(id);
        console.log(id);
        navigate('/'+MainRoutes.questionAreaForm+`/${id}`);
    }
    console.log(props.questionAreas.questionAreas);
    const [expanded, setExpanded] = React.useState<boolean>(false);
    let handleExpandClick = ()=>setExpanded(!expanded);
    return (
                    <Grid container justifyContent="space=between"
                          alignItems="center">
                        <QuestionAreaTableHeader/>
                        {props.questionAreas.questionAreas.map((item)=>
                            <QuestionAreaTableRow key={item.id} qArea={item} onEdit={edit.bind(this)}/>
                        )}
                    </Grid>
    );
};

const QuestionAreaTableHeader: React.FC = () =>{
    return (
        <React.Fragment>
            <Grid item  container justifyContent = 'space-between'>
                <Grid item xs={1}><Typography>Id</Typography></Grid>
                <Grid item xs><Typography>Name</Typography></Grid>
                <Grid item xs={1}><Typography>More info</Typography></Grid>
                <Grid item xs={1}><Typography>Edit</Typography></Grid>
                <Grid item xs={1}><Typography>Delete</Typography></Grid>
            </Grid>
        </React.Fragment>
    );
};
interface  IRowProps{
    qArea: IQuestionArea,
    onEdit: (id: number)=>void,
}
const QuestionAreaTableRow: React.FC<IRowProps> = ({qArea, onEdit}) =>{

    return (
        <React.Fragment>
            <Grid item  container justifyContent = 'space-between'>
                <Grid item xs={1}><Typography>{qArea?.id}</Typography></Grid>
                <Grid item xs><Typography>{qArea?.name}</Typography></Grid>
                <Grid item xs={1}><IconButton><ExpandMoreIcon></ExpandMoreIcon></IconButton></Grid>
                <Grid item xs={1}><IconButton onClick={()=>onEdit(qArea?.id)}><EditIcon></EditIcon></IconButton></Grid>
                <Grid item xs={1}><IconButton><DeleteIcon></DeleteIcon></IconButton></Grid>
            </Grid>
        </React.Fragment>
    );
};

const mapStateToProps = (state: ApplicationState) => ({
    questionAreas: state.questionAreas
});

const mapDispatchToProps = (dispatch: Dispatch) =>
    bindActionCreators({
        createQuestionArea: questionAreasActionCreators.createQuestionArea,
        editQuestionArea: questionAreasActionCreators.editQuestionArea,
        deleteQuestionArea: questionAreasActionCreators.deleteQuestionArea,
        fetchQuestionAreaById: questionAreasActionCreators.fetchQuestionAreaById,
        fetchQuestionAreas: questionAreasActionCreators.fetchAllQuestionAreas,
    }, dispatch);

type Props = ReturnType<typeof mapStateToProps> &
    ReturnType<typeof mapDispatchToProps>;

export default connect(mapStateToProps, mapDispatchToProps)(QuestionArea);
