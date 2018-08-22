import React from 'react';


const TableTwoOptionsSelect = (props) => {
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

export default TableTwoOptionsSelect;