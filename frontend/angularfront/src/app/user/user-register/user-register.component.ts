import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, ValidationErrors, Validators } from '@angular/forms';
import { User } from 'src/app/model/user';

@Component({
  selector: 'app-user-register',
  templateUrl: './user-register.component.html',
  styleUrls: ['./user-register.component.css']
})
export class UserRegisterComponent implements OnInit {
  registrationForm!: FormGroup;
  user!:User;
  userSubmitted!:boolean;
  constructor(private fb: FormBuilder) { }

  ngOnInit() {
    /*this.registrationForm = new FormGroup({
      userName: new FormControl(null, Validators.required),
      password: new FormControl(null, [Validators.required, Validators.minLength(4)]),
      confirmPassword: new FormControl(null, [Validators.required])
    },this.passwordMatchingValidator);*/
    this.createRegistrationForm();
  }

  createRegistrationForm(){
    this.registrationForm = this.fb.group({
      userName: [null, Validators.required],
      password: [null, [Validators.required, Validators.minLength(4)]],
      confirmPassword: [null, Validators.required]
    }, {validators: this.passwordMatchingValidator})
  }

  passwordMatchingValidator(fc: AbstractControl): ValidationErrors | null {
    return fc.get('password')?.value === fc.get('confirmPassword')?.value ? null :
      { notmatched: true }
  };

  get userName(){
    return this.registrationForm.get('userName') as FormControl;
  }
  get password(){
    return this.registrationForm.get('password') as FormControl;
  }
  get confirmPassword(){
    return this.registrationForm.get('confirmPassword') as FormControl;
  }

  onSubmit(){
    console.log(this.registrationForm);
    this.userSubmitted = true;
    if (this.registrationForm.valid){

    //this.user = Object.assign(this.user, this.registrationForm.value);
    this.addUser(this.userData());
    this.registrationForm.reset();
    this.userSubmitted = false;

    }

  }

  userData(): User{
    return this.user = {
      userName: this.userName.value,
      password: this.password.value
    }
  }

  addUser(user: User) {
    let users = [];
    if(localStorage.getItem('Users')) {
      users = JSON.parse(localStorage.getItem('Users') as string);
    }
    users.push(user);
    localStorage.setItem('Users', JSON.stringify(users))
  }

}
