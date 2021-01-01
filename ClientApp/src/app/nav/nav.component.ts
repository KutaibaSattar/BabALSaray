import { AccountService } from './../_services/account.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
model: any = {};
// currentUser$: Observable<User>;
// loggedIn : boolean

constructor(public accountService: AccountService, private router: Router ) { }

  ngOnInit(): void {
    // this.getCurrentUser();
    // this.currentUser$ = this.accountService.currentUser$;
  }

  login() {
    this.accountService.login(this.model).subscribe(() => {this.router.navigateByUrl('/dbaccounts');
   });

  }

  logout() {
    this.accountService.logout();
    this.router.navigateByUrl('/home');

  }

  /* getCurrentUser(){

      this.accountService.currentUser$.subscribe(user =>{
        this.loggedIn= !!user; // double !! transfer object to boolean

      }, error=> { console.log(error);})

  } */

}
