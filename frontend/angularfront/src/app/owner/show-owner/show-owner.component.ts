import { Component, OnInit } from '@angular/core';
import { ServService } from 'src/app/serv.service';

@Component({
  selector: 'app-show-owner',
  templateUrl: './show-owner.component.html',
  styleUrls: ['./show-owner.component.css']
})
export class ShowOwnerComponent {
  constructor(private service:ServService) { }

  OwnerList:any=[];
  ModalTitle?:string;
  ActivateAddEditOwnComp:boolean=false;
  own:any;

  ngOnInit(): void{
    this.refreshOwnerList();

  }

  addClick(){
    this.own={
      OwnerId:0,
      OwnerName:"",
      Car:"",
      DateOfPurchase:""
    }
    this.ModalTitle="Add Owner";
    this.ActivateAddEditOwnComp=true;
  }

  editClick(item: any){
    this.own=item;
    this.ModalTitle="Edit Owner";
    this.ActivateAddEditOwnComp=true;
  }

  deleteClick(item: any){
    if(confirm('Are you sure?')){
      this.service.deleteOwner(item.OwnerId).subscribe(data=>{
        alert(data.toString());
        this.refreshOwnerList();
      })
    }
  }

  closeClick(){
    this.ActivateAddEditOwnComp=false;
    this.refreshOwnerList();
  }


  refreshOwnerList(){
    this.service.getOwnerList().subscribe(data=>{
      this.OwnerList=data;
    });
  }
}
