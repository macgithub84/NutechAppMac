import React from 'react';
import { Link } from 'react-router-dom' 
import { Menu } from 'semantic-ui-react' 

const Navbar = ()=>{
 return ( 
    <Menu size='mini'>
        <Menu.Item as={ Link } to="/" 
            name='home'  >
            Dash Board
        </Menu.Item> 
        <Menu.Item as={ Link } to="/car-master"  name='car-master' >
            Car Master
        </Menu.Item> 
        <Menu.Item as={ Link } to="/reports" 
            name='Reports'>
            Reports
        </Menu.Item>
    </Menu> 
  )
};
export default  Navbar;