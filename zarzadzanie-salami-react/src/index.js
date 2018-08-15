import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import {Header} from './Header.jsx';
import {Classrooms} from "./Classrooms.jsx";


ReactDOM.render(<Header />, document.getElementById('header'));
ReactDOM.render(<Classrooms />, document.getElementById('classrooms'));

