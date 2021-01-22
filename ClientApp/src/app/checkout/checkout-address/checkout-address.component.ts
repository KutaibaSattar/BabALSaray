import { Component, Input, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from 'src/app/_services/account.service';

@Component({
  selector: 'app-checkout-address',
  templateUrl: './checkout-address.component.html',
  styleUrls: ['./checkout-address.component.css']
})
export class CheckoutAddressComponent implements OnInit { //checkout compenet is parrent of address component 
@Input() checkoutForm: FormGroup;
  constructor( private accountService: AccountService, private toastr: ToastrService) { }

  ngOnInit(): void {
  }

 saveUserAddress () {
    this.accountService.updateUserAddress(this.checkoutForm.get('addressForm').value)
    .subscribe(() => {
        this.toastr.success('Address saved');
    }, error=> {
      this.toastr.error(error.message);
      console.log(error)
     });

  }

}