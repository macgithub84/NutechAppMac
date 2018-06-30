import React, { Component } from 'react'; 
import { Segment,Container,Header,Table,Icon,Button } from 'semantic-ui-react'  
import axios from 'axios'
import { apihostUrl } from '../Config'
import Modal from '../Modal';
import AddUpdateCar  from './AddEditCarDetails';

class CarMaster extends Component {
constructor(props){
    super(props);
    this.state = {
      Cars: [],
      isOpen: false,
      editId:0
    }
    this.handleEditClick = this.handleEditClick.bind(this);
    this.handleDeleteClick = this.handleDeleteClick.bind(this);
    this.toggleModal = this.toggleModal.bind(this);
}
toggleModal(va1) { 
    this.bind();
    this.setState({
      isOpen: !this.state.isOpen
    });
  }
  handleEditClick(id, e){ 
    const car = this.state.Cars.find((element) => { 
      return element.Id === id; 
    });
    this.setState({
      isOpen: !this.state.isOpen,
      editId:id,
      editCar:car
    });
  }
  handleDeleteClick(id, e){ 
    const rec = this.state.Cars.find((element) => { 
      return element.Id === id; 
    });
    const recordVal = `${rec.YearOfManufacture} ${rec.Manufacturer} ${rec.CarMake} ${rec.CarModel}`;
    if(window.confirm(`Are you sure you wish to delete the: \n ${recordVal}?`)){
      const apiuri =   apihostUrl +  `api/car/DeleteCarMake/${id}`;
      axios.delete(apiuri)
      .then(res => {
        const deletedId = res.data;
        const newState = this.state.Cars;
        const indexOfCarToDelete = newState.findIndex(car => {
          return car.Id == deletedId
        })
        newState.splice(indexOfCarToDelete, 1); 
        this.setState({ Cars: newState });  
      })
    }
  }
  bind(){ 
    const apiuri =   apihostUrl +  `api/car/GetAllCarDetails`
    axios.get(apiuri)
    .then(res => {
        const Cars = res.data;
        this.setState(
        { Cars: Cars,
          editCar:{}
        });
    })
  }
  componentWillMount(){  
    this.bind();
  }
  
  render() { 
    const carDetails = this.state.Cars;
    const colWidth= {
      width: '4em',
      textAlign: 'center'
     };
    return (  
     
        <Segment raised color='blue' size="mini">
         
        <Table celled striped>
        <Table.Header>
        <Table.Row>
          <Table.HeaderCell colSpan='6'>
          <Button positive onClick={this.toggleModal}>Add</Button>
          </Table.HeaderCell> 
        </Table.Row>
      </Table.Header>
      <Table.Header>
        <Table.Row>
          <Table.HeaderCell>Manufacturer</Table.HeaderCell>
          <Table.HeaderCell>Car Make</Table.HeaderCell>
          <Table.HeaderCell>Car Model</Table.HeaderCell>
          <Table.HeaderCell>Year</Table.HeaderCell>
          <Table.HeaderCell style={colWidth} ></Table.HeaderCell>
          <Table.HeaderCell style={colWidth} ></Table.HeaderCell>
        </Table.Row>
      </Table.Header>

    <Table.Body>
      {carDetails.map((car)=>(         
        <Table.Row key={car.Id}>
           <Table.Cell>{car.Manufacturer}</Table.Cell>
           <Table.Cell>{car.CarMake}</Table.Cell>
           <Table.Cell>{car.CarModel}</Table.Cell>
           <Table.Cell>{car.YearOfManufacture}</Table.Cell>
           <Table.Cell>
             <a href="#" key={car.Id} onClick={this.handleEditClick.bind(this, car.Id)}>
              <Icon name='edit' />
             </a> 
          </Table.Cell>
          <Table.Cell>
          <a href="#" key={car.Id}  onClick={this.handleDeleteClick.bind(this, car.Id)} >
              <Icon name='delete' />
             </a>
          </Table.Cell> 
        </Table.Row>
       ))}
    </Table.Body>
    </Table>
    <Modal   show={this.state.isOpen}>
      <AddUpdateCar editCar={this.state.editCar} onClose={this.toggleModal}></AddUpdateCar>
    </Modal> 
      </Segment>
      
    );
  }
}
export default CarMaster;