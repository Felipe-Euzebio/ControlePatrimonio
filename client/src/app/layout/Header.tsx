import { AppBar, Box, List, ListItem, SxProps, Toolbar, Typography } from "@mui/material";
import { ThemeSwitch } from "./ThemeSwitch";
import { NavLink } from "react-router-dom";

interface Props {
    darkMode: boolean;
    handleThemeChange: () => void;
}

const navStyles: SxProps = {
    color: "inherit", 
    textDecoration: "none", 
    typography: "h6",
    '&:hover': {
        color: "grey.500",
    },
    "&.active": {
        color: "text.secondary",
    },
    width: "auto",
};

export default function Header({ darkMode, handleThemeChange }: Props) {
    return (
        <AppBar position="static">
            <Toolbar sx={{
                display: "flex",
                justifyContent: "space-between",
                alignItems: "center"
            }}>
                <Box display="flex" alignItems="center">
                    <Typography 
                        variant="h6"
                        component={NavLink}
                        to="/"
                        sx={navStyles}
                    >
                        Controle de Patrimônio
                    </Typography>
                    <ThemeSwitch checked={darkMode} onChange={handleThemeChange}/>
                    <List sx={{ display: "flex" }}>
                        <ListItem
                            component={NavLink}
                            to="/patrimonies"
                            sx={navStyles}
                        >
                            Patrimônios
                        </ListItem>
                    </List>
                </Box>
                <Box display="flex" alignItems="center">
                    <List sx={{ display: "flex" }}>
                        <ListItem
                            component={NavLink}
                            to="/login"
                            sx={navStyles}
                        >
                            Login
                        </ListItem>
                        <ListItem
                            component={NavLink}
                            to="/register"
                            sx={navStyles}
                        >
                            Cadastrar-se
                        </ListItem>
                    </List>
                </Box>
            </Toolbar>
        </AppBar>
    );
}