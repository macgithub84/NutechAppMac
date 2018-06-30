import React  from 'react'; 
import {BrowserRouter as Router} from 'react-router-dom'
import Route from 'react-router-dom/Route'
import Navbar from './Navbar'
import Home from './Home'
import CarMaster from './Car/CarMaster'
import YearlySalesReport from './Reports/YearlySalesReport'
const AppRouter = ()=> {
    return(
        <Router> 
        <div className="divNoMargin"> 
            <Navbar/>
            <Route path="/" exact component={Home}/>
            <Route path="/car-master"  component={CarMaster} />
            <Route path="/reports" component={YearlySalesReport} />
        </div>
        </Router> 
    );

};
export default AppRouter;