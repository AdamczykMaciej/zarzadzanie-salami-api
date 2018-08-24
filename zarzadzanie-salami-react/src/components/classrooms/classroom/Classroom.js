import React, {Component} from 'react';
import {getClassroomById} from "../Requests";
import ClassroomView from "./ClassroomView";

export class Classroom extends Component {
    state = {
        classroom: {},
    };

    async componentDidMount() {
        const result = await getClassroomById(1);
        if (result.error) {

        } else {
            this.setState(
                {
                    classroom: result.data
                })
        }
    }

    render() {
        return (
            <div className="container-classroom" style={{padding: 10}}>
                <ClassroomView classroom={this.state.classroom}/>
            </div>
        )
    }


}