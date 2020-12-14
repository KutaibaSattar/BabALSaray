import { AccountService } from './../_services/account.service';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  @Output() cancelRegister = new EventEmitter();

  model : any ={};


  constructor(private accountService : AccountService, private toastr : ToastrService ) { }

  ngOnInit(): void {
  }


  register(){
    this.accountService.registor(this.model).subscribe(Response =>

      {
        console.log(Response)
        this.cancel();

      }/* , error => {console.log(error);
        this.toastr.error(error.error) }*/

        );

  }

  cancel(){
    this.cancelRegister.emit(false);

  }

}


