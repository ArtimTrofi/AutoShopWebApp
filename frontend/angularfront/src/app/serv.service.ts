import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ServService {
  readonly APIUrl="http://ec2-18-236-148-10.us-west-2.compute.amazonaws.com";
  constructor(private http:HttpClient) { }

  getCarList():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/GetCars');
  }

  addCar(carData: any): Observable<any> {
    return this.http.post(this.APIUrl + '/AddCar', carData, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    });
  }


 /* updateCar(val:any){
    return this.http.put(this.APIUrl+'/UpdateCar/WithID',val);
  }*/
  updateCar(carData: any): Observable<any> {
    return this.http.put(this.APIUrl + '/UpdateCar/WithID', carData, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    });
  }


 /* deleteCar(val:any){
    return this.http.delete(this.APIUrl+'/DeleteCar?CarId=',val);
  }*/

  deleteCar(carId: any): Observable<any> {
    return this.http.delete(this.APIUrl + '/DeleteCar?', carId);
  }



  getOwnerList():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/GetOwner');
  }

  addOwner(val:any){
    return this.http.post(this.APIUrl+'/AddOwner',val);
  }

  updateOwner(val:any){
    return this.http.put(this.APIUrl+'/UpdateOwner/WithID',val);
  }

  deleteOwner(val:any){
    return this.http.delete(this.APIUrl+'/DeleteOwner',val);
  }

  getAllCarNames():Observable<any[]>{
    return this.http.get<any[]>(this.APIUrl+'/Owner/GetAllCarNames')
  }
}
