import * as React from 'react';
import Box from '@mui/material/Box';
import Button from '@mui/material/Button';
import Typography from '@mui/material/Typography';
import Modal from '@mui/material/Modal';
import styled from "styled-components";
import {Grid, Input, TextField} from '@mui/material';

const Container = styled.div`
      width: 100%;
      max-width: 1170px;
      margin: auto;
    `;

const TextFieldContainer = styled(TextField)`
    required: true;
    id:"outlined-required";
    label:"Required";
    defaultValue:"Name";
`

export default function AddQuestionSet() {
    // const [open, setOpen] = React.useState(false);
    // const handleOpen = () => setOpen(true);
    // const handleClose = () => setOpen(false);
    const GridContainer = styled(Grid)
        `
      width: 100%;
      max-width: 1170px;
      margin: auto;
    `
    return (

        <Container>
          Name:<TextFieldContainer/>
        </Container>
        // <div>
        //     <Button onClick={handleOpen}>Open modal</Button>
        //     <Modal
        //         open={open}
        //         onClose={handleClose}
        //         aria-labelledby="modal-modal-title"
        //         aria-describedby="modal-modal-description"
        //     >
        //         <Box sx={style}>
        //             <Typography id="modal-modal-title" variant="h6" component="h2">
        //                 Text in a modal
        //             </Typography>
        //             <Typography id="modal-modal-description" sx={{ mt: 2 }}>
        //                 Duis mollis, est non commodo luctus, nisi erat porttitor ligula.
        //             </Typography>
        //         </Box>
        //     </Modal>
        // </div>
    );
}
