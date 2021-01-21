import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent implements OnInit {
checkoutForm: FormGroup;

  constructor(private fb: FormBuilder, private accouuntService: AccountService) { }

  ngOnInit(): void {
    this.createCheckoutForm();
    this.getAddressFormValues();
  }

  createCheckoutForm() {
    this.checkoutForm = this.fb.group({
      addressForm : this.fb.group({
       line1: [null, Validators.required],
       line2: [null, Validators.required],
       region: [null, Validators.required],
       city: [null, Validators.required],
      country: [null, Validators.required],

      }),
      orderMethodForm : this.fb.group({
      orderMethod: [null, Validators.required]

      }),
      paymentForm: this.fb.group({
        nameOnCard: [null, Validators.required]
  
        })

    });

  }

  getAddressFormValues() {
    this.accouuntService.getUserAddress().subscribe(address => {
      if (address) {
       this.checkoutForm.get('addressForm').patchValue(address);

      }
    }, error => {
        console.log(error);

      }

    )
  }

}
