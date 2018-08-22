import React from 'react';


const TableSelects = (props) => {
    return (
        <select onChange={props.onChange}
                style={props.style}
                value={props.value}
        >
            <option value="all">Wszystkie</option>
            <option value="lessThan_10">{'<'}10</option>
            <option value="from_10_to_15">10-15</option>
            <option value="from_16_to_20">16-20</option>
            <option value="greaterThan_20">{'>'}20</option>
        </select>
    )
}

export default TableSelects;