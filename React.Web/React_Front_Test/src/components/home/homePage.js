import React from 'react';
import { Link } from 'react-router';

class HomePage extends React.Component {

  render() {
    return (
      <div className="jumbotron">
        <h1>Unicorn shop</h1>
        <p>This will be the best place to shop for unicorns</p>
        <Link to="about" className="btn btn-primary btn-lg">Learn more</Link>
      </div>
    );
  }
}

export default HomePage;
