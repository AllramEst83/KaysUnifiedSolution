import React, { PropTypes } from 'react';
import { Link, IndexLink } from 'react-router';
import Music from './Music';
//import LoadingDots from './LoadingDots';

const Header = () => {
  return (
    <div className="topBar">    
         
      <div className="mainText">
        Best Unicorn Store on the web
        <div className="Muybridge">
          🐎
        </div>
      </div>

      {/* <Music /> */}

      <div className="navElement">
        <nav>
          <IndexLink to="/" activeClassName="active">Home</IndexLink>
          {" | "}
          <Link to="/about" activeClassName="active">About</Link>
          {" | "}
          <Link to="/unicorns" activeClassName="active">Unicorn shop</Link>
        </nav>
      </div>

    </div>
  );
};

export default Header;
