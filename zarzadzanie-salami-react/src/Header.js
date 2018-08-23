import React from 'react';
import injectSheet, { jss, ThemeProvider } from "react-jss";
import { NavLink } from 'react-router-dom';

const styles = theme => ({
    header: {
        padding: 15,
        background: theme.background,
        overflow: "hidden"

    },
    header_right: {
        float: "right",
        '&:hover':{
            background: "#ff3333",
            color: "white"
        },
    },
    title: {
        font: {
            size: 18,
            weight: 900,

        },
        textAlign: "center",
        padding: 12,
        textDecoration: "none",
        borderRadius: 4,
        color: theme.color
    },
    '@media (max-width: 500px)': {
        title: {
            float: "none",
            display: "block",
            textAlign: "left"
        },
        header_right: {
            float: "none"
        }
    }

});

const Comp = ({ classes }) => (
    <div className={classes.header}>
        <a className={classes.title}>Zarządzanie salami</a>
        <div className={classes.header_right}>
            <NavLink to="/">Home</NavLink>
            <NavLink to="/classrooms">Sali</NavLink>
            <NavLink to="/computers">Komputery</NavLink>
        </div>
    </div>

);

const StyledComp = injectSheet(styles)(Comp);

const theme = {
    background: "#c40f11",
    color: "white"
};

const Header = () =>
    <ThemeProvider theme={theme}>
        <StyledComp />
    </ThemeProvider>

export default Header;





