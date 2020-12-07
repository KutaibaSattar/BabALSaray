import { Component, OnInit } from '@angular/core';

import { dbAccounts } from 'src/app/_models/adaccounts';
import { DbaccountsService } from 'src/app/_services/dbaccounts.service';

@Component({
  selector: 'app-dbaccounts-list',
  templateUrl: './dbaccounts-list.component.html',
  styleUrls: ['./dbaccounts-list.component.css']
})
export class DbaccountsListComponent implements OnInit {

  dbaccounts : dbAccounts[];
  
 

  constructor(private dbAccountsService : DbaccountsService) { }

  ngOnInit(): void {
    this.loadDbAccounts();

  }

  loadDbAccounts(){

    this.dbAccountsService.getdbAccounts().subscribe(dbaccts => {
    this.dbaccounts = dbaccts;
     console.log(dbaccts);
   
    
   

    })

  }

 
    
   
  




 

}
