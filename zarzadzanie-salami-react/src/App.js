import React, { Component } from 'react';
import Header from "./components/Header";
import {BrowserRouter, Route, Switch} from "react-router-dom";
import {Welcome} from "./components/Welcome";
import {Classrooms} from "./components/Classrooms";



export class App extends Component{
    render() {
        return (
            <div>
                <BrowserRouter>
                    <div>
                        <Header/>
                        <Switch>
                            <Route path="/" component={Welcome} exact />
                            <Route path="/classrooms" component={Classrooms} />
                        </Switch>
                    </div>
                </BrowserRouter>
            </div>
        )
    }
}