import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DbaccountsService } from 'src/app/_services/dbaccounts.service';
import { dbAccounts } from 'src/app/_models/adaccounts';

@Component({
  selector: 'app-dbaccount-detail',
  templateUrl: './dbaccount-detail.component.html',
  styleUrls: ['./dbaccount-detail.component.css']
})
export class DbaccountDetailComponent implements OnInit {

  dbaccount : dbAccounts;

  constructor( private dbaccountsService : DbaccountsService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.loadDbAccount();
  }

 loadDbAccount(){

  this.dbaccountsService.getdbAccount(this.route.snapshot.paramMap.get('id')).subscribe(dbaccount =>{
    this.dbaccount = dbaccount

  } )

 }

}
