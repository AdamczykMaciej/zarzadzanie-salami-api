import React, { Component } from 'react';
import './Header.css';


export class Header extends Component {
  constructor(props){
    super(props);
  }

  render() {
    return (
      <div className="app-header">
          <a>Zarządzanie salami</a>
          <div className="app-header-right">
              <a href="#">Sali</a>
              <a href="#">Komputery</a>
          </div>
      </div>
    );
  }
}


