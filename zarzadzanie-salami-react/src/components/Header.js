import React from 'react';
import './Header.css';
import { NavLink } from 'react-router-dom';


const Header = () => {
    return (
      <div className="app-header-main">
          <a>Zarządzanie salami</a>
          <div className="app-header-right">
              <NavLink to="/">Home</NavLink>
              <NavLink to="/classrooms">Sali</NavLink>
              <NavLink to="/computers">Komputery</NavLink>
          </div>
      </div>
    );
};

export default Header;





