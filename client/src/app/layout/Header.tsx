import { AppBar, Toolbar, Typography } from "@mui/material";
import { ThemeSwitch } from "./ThemeSwitch";

interface Props {
    darkMode: boolean;
    handleThemeChange: () => void;
}

export default function Header({ darkMode, handleThemeChange }: Props) {
    return (
        <AppBar position="static">
            <Toolbar>
                <Typography variant="h6">
                    Controle de Patrimônio
                </Typography>
                <ThemeSwitch checked={darkMode} onChange={handleThemeChange}/>
            </Toolbar>
        </AppBar>
    );
}