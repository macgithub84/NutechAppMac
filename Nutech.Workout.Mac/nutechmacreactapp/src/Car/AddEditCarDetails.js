import React, { Component } from 'react';
import ReactDOM from 'react-dom' ;
import axios from 'axios'
import { Button, Form } from 'semantic-ui-react'
import { apihostUrl } from '../Config'
  
class AddEditCarDetails extends Component{
    constructor(props){
        super(props);
        this.state={
            recId:0 
        } 
    }
    AddUpdateData(method,apiuri,data){ 
        
        axios({
            method: method,
            url: apiuri,
            data: data,
            config: { headers: {'Content-Type': 'multipart/form-data' }}
        })
            .then(res => {
                this.props.onClose(true); 
            })
            .catch(res => {
                 console.log(res);
            })
    }
    handleClick = (e) => { 
        //alert(this.state.recId)
        var postapiuri =   apihostUrl;
        var body = {
            Id: this.props.editCar.Id,
            Manufacturer: this.Manufacturer.value,
            CarMake: this.Make.value,
            CarModel: this.Model.value,
            YearOfManufacture: this.Year.value
         }
        if(this.props.editCar.Id > 0){
            postapiuri = `${postapiuri}api/car/UpdateCarMake`;
            this.AddUpdateData('put',postapiuri,body)
        }
        else{
            postapiuri = `${postapiuri}api/car/CreateANewCarMake`;
            this.AddUpdateData('post',postapiuri,body)
        }
        
        
         
        }
    
    render(){ 
        return( 
        <Form onSubmit={this.handleClick} >
             <Form.Group widths='equal'>
            <Form.Field>
              <label>Manufacturer</label>
              <input ref={node => (this.Manufacturer = node)} defaultValue={this.props.editCar.Manufacturer} name="Manufacturer" placeholder='Manufacturer' />
            </Form.Field>
            <Form.Field>
              <label>Car Make</label>
              <input ref={node => (this.Make = node)} defaultValue={this.props.editCar.CarMake} placeholder='Car Make' />
            </Form.Field>
            </Form.Group>
            <Form.Group widths='equal'>
            <Form.Field>
              <label>Car Model</label>
              <input ref={node => (this.Model = node)} defaultValue={this.props.editCar.CarModel} placeholder='Car Model' />
            </Form.Field>
            <Form.Field>
              <label>Year</label>
              <input ref={node => (this.Year = node)} defaultValue={this.props.editCar.YearOfManufacture} placeholder='Year' />
            </Form.Field>
            </Form.Group>
            <Button type='submit' primary>Submit</Button>
            <Button onClick={this.props.onClose}>Close</Button>
          </Form>
         
        );
    }
} 
export default AddEditCarDetails;