import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

import { BehaviorSubject, ReplaySubject } from 'rxjs';
import {map} from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { IAddress } from '../_models/address';
import { User } from '../_models/user';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
   baseUrl = environment.apiUrl;
  private currentUserSource = new ReplaySubject<User>(1);

 // or private currentUserSource = new BehaviorSubject<User>(null);


  currentUser$ = this.currentUserSource.asObservable(); // $ at end as convention that is Observable

  constructor(private  http: HttpClient, private router: Router) { }


  login(model: any) {

      return  this.http.post(this.baseUrl + 'account/login', model).pipe(
        map((response: User) => {
            const user = response;
            if (user) {
              localStorage.setItem('user', JSON.stringify(user));
              this.currentUserSource.next(user); // store user token in current user source
                     }
        })

      );
    }

   setCurrentUser(user: User) {
    this.currentUserSource.next(user);

   }



  registor(model: any) {

    return this.http.post(this.baseUrl + 'account/register', model).pipe(
      map(( user: User) => {
        if (user) {
            sessionStorage.setItem('user', JSON.stringify(user));
            this.currentUserSource.next(user);
        }
      })

    );


  }

  logout() {
    localStorage.removeItem('user');
    this.currentUserSource.next(null);
    this.router.navigateByUrl('/');
  }

  checkEmailExists( email: string ) {
    return this.http.get(this.baseUrl + 'account/emailexists?email=' + email);

  }

 getUserAddress(){
    return this.http.get<IAddress>(this.baseUrl + 'users/address')

  }
  
 updateUserAddress(address: IAddress){
    return this.http.put<IAddress>(this.baseUrl + 'users/address',address)

  }




}
