import { Component, Input, OnInit } from '@angular/core';
import { ServService } from 'src/app/serv.service';

@Component({
  selector: 'app-add-edit-car',
  templateUrl: './add-edit-car.component.html',
  styleUrls: ['./add-edit-car.component.css']
})
export class AddEditCarComponent {
  CarList?: any[];

  constructor(private service:ServService) { }


  @Input() cr: any;
  CarId?:string;
  CarName?:string;

  ngOnInit(){
    this.CarId=this.cr.CarId;
    this.CarName=this.cr.CarName;
  }

  addCar(){
    var val = {CarId:this.CarId,CarName:this.CarName};
    this.service.addCar(val).subscribe(res=>{
      alert(res.toString());
    }

    );
  }

  UpdateCar(){
    var val = {CarId:this.CarId,CarName:this.CarName};
    this.service.updateCar(val).subscribe(res=>{
      alert(res.toString());
    });
  }

}
