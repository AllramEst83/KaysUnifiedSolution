import React, { PropTypes } from 'react';
import { Link } from 'react-router';

const UnicornListRow = ({ unicorn }) => {
    return (
        <tr>
            <td><Link to={'unicorn/' + unicorn.Id}>{unicorn.name}</Link></td>
            <td>{unicorn.breed}</td>
            <td>{unicorn.origin}</td>
            <td>{unicorn.horntype.type}</td>
        </tr>
    );
};


UnicornListRow.propTypes = {
    unicorn: PropTypes.object.isRequired
};

export default UnicornListRow;