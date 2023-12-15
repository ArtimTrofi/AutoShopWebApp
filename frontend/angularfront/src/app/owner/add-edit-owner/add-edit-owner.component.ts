import { Component, Input, OnInit } from '@angular/core';
import { ServService } from 'src/app/serv.service';

@Component({
  selector: 'app-add-edit-owner',
  templateUrl: './add-edit-owner.component.html',
  styleUrls: ['./add-edit-owner.component.css']
})
export class AddEditOwnerComponent {
  @Input() own: any;
  constructor(private service:ServService) { }

  OwnerId?:string;
  OwnerName?:string;
  Car?:string;
  DateOfPurchase?:string;

  CarsList:any=[];

  ngOnInit(){
   this.loadCarsList();
  }

  loadCarsList(){
    this.service.getAllCarNames().subscribe((data:any)=>{
      this.CarsList=data;

      this.OwnerId=this.own.OwnerId;
      this.OwnerName=this.own.OwnerName;
      this.Car=this.own.Car;
      this.DateOfPurchase=this.own.DateOfPurchase;
    });
  }

  addOwner(){
    var val = {OwnerId:this.OwnerId,
                OwnerName:this.OwnerName,
                Car:this.Car,
                DateOfPurchase:this.DateOfPurchase};

    this.service.addOwner(val).subscribe(res=>{
      alert(res.toString());
    }

    );
  }


  UpdateOwner(){
    var val = {OwnerId:this.OwnerId,
      OwnerName:this.OwnerName,
      Car:this.Car,
      DateOfPurchase:this.DateOfPurchase};

    this.service.updateOwner(val).subscribe(res=>{
      alert(res.toString());
    });
  }
}
