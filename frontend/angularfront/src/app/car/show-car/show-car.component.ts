import { Component, OnInit } from '@angular/core';
import { ServService } from 'src/app/serv.service';

@Component({
  selector: 'app-show-car',
  templateUrl: './show-car.component.html',
  styleUrls: ['./show-car.component.css']
})
export class ShowCarComponent {
dataItem: any;

  constructor(private service:ServService) { }
  CarId?:string;


  CarList:any=[];
  ModalTitle?:string;
  ActivateAddEditCarComp:boolean=false;
  cr:any;

  ngOnInit(): void{
    this.refreshCarList();

  }

  addClick(){
    this.cr={
      CarId:0,
      CarName:""
    }
    this.ModalTitle="Add Car";
    this.ActivateAddEditCarComp=true;
  }

  editClick(item: any){
    this.cr=item;
    this.ModalTitle="Edit Car";
    this.ActivateAddEditCarComp=true;
  }



  deleteClick(item: any){
    if(confirm('Are you sure?')){
      this.service.deleteCar(item.CarId).subscribe(data=>{
        alert(data.toString());
        this.refreshCarList();
      })
    }
  }



  closeClick(){
    this.ActivateAddEditCarComp=false;
    this.refreshCarList();
  }


  refreshCarList(){
    this.service.getCarList().subscribe(data=>{
      this.CarList=data;
    });
  }

}
