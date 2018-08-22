import React from 'react';


const TwoOptionsSelect = (props) => {
    return (
        <select onChange={props.onChange}
                style={props.style}
                value={props.value}
        >
            <option value="all">Wszystkie</option>
            <option value="true">+</option>
        </select>
    )
}

export default TwoOptionsSelect;