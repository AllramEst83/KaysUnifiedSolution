import React, { PropTypes } from 'react';
import UnicornListRow from './unicornListRow';

const UnicornList = ({ unicorns }) => {

    return (
        <div className="panel panel-default">
            <table className="table table-responsive table-bordered table-hover">
                <thead className="alert alert-info">
                    <tr>
                        <th>Name</th>
                        <th>Breed</th>
                        <th>Origin</th>
                        <th>Horntype</th>
                    </tr>
                </thead>
                <tbody>
                    {unicorns.map(unicorn =>
                        <UnicornListRow key={unicorn.Id} unicorn={unicorn} />
                    )}
                </tbody>
            </table>
        </div>
    );

};

UnicornList.propTypes = {
    unicorns: PropTypes.array.isRequired
};

export default UnicornList;