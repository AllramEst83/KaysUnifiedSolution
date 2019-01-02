import React, { PropTypes } from 'react';
import AddUnicorn from '../addunicorn/addunicorn.js';

class UnicornsPage extends React.Component {
  render() {
    return (
      <div>
        <h1>Unicorns</h1>
        <AddUnicorn/>
      </div>
      );
  }
}

export default UnicornsPage;
