import * as React from 'react';
import MenuList from '@mui/material/MenuList';
import MenuItem from '@mui/material/MenuItem';
import Paper from '@mui/material/Paper';
import ListItemIcon from '@mui/material/ListItemIcon';
import Typography from '@mui/material/Typography';
import DraftsIcon from '@mui/icons-material/Drafts';
import SendIcon from '@mui/icons-material/Send';
import PriorityHighIcon from '@mui/icons-material/PriorityHigh';
import {Menu} from "@mui/material";

export default function LeftSideBar() {
    const [anchorEl, setAnchorEl] = React.useState<null | HTMLElement>(null);
    const [mobileMoreAnchorEl, setMobileMoreAnchorEl] =
        React.useState<null | HTMLElement>(null);

    const isMenuOpen = Boolean(anchorEl);
    const isMobileMenuOpen = Boolean(mobileMoreAnchorEl);

    const handleProfileMenuOpen = (event: React.MouseEvent<HTMLElement>) => {
        setAnchorEl(event.currentTarget);
    };


    const handleMobileMenuClose = () => {
        setMobileMoreAnchorEl(null);
    };

    const handleMenuClose = () => {
        setAnchorEl(null);
        handleMobileMenuClose();
    };

    const handleMobileMenuOpen = (event: React.MouseEvent<HTMLElement>) => {
        setMobileMoreAnchorEl(event.currentTarget);
    };


    return (
        <Paper sx={{width: 230}}>
            <MenuList>
                <MenuItem>
                    <ListItemIcon>
                        <SendIcon fontSize="small"/>
                    </ListItemIcon>
                    <Typography variant="inherit">A short message</Typography>
                </MenuItem>
                <MenuItem>
                    <ListItemIcon>
                        <PriorityHighIcon fontSize="small"/>
                    </ListItemIcon>
                    <Typography variant="inherit">A very long text that overflows</Typography>
                </MenuItem>
                <MenuItem>
                    <ListItemIcon>
                        <DraftsIcon fontSize="small"/>
                    </ListItemIcon>
                    <Typography variant="inherit" noWrap> A very long text that overflows
                    </Typography>
                </MenuItem>
            </MenuList>
        </Paper>
    );
}
