import { Component, OnInit } from '@angular/core';
import { dbAccounts } from '../_models/adaccounts';
import { DbaccountsService } from '../_services/dbaccounts.service';

@Component({
  selector: 'app-recursion',
  templateUrl: './recursion.component.html',
  styleUrls: ['./recursion.component.css']
})
export class RecursionComponent implements OnInit {

  public data = {id:0, parentId:0 ,key: "",name :"", lvl:0,children: [	]}  
	

	
	dbaccounts : dbAccounts;

  constructor(private dbAccountsService : DbaccountsService) { }

  ngOnInit(): void {
  }

  private isLeaf(): boolean {
    return this.dbaccounts.children.length === 0;
  }

  loadDbAccounts(){

		this.dbAccountsService.getdbAccounts().subscribe(dbaccts => {
		this.dbaccounts = dbaccts : any;
		this.data= this.dbaccounts[0];
		console.log(dbaccts[0]);
		//this.data = dbaccts[0];
		console.log(this.data);
		
	   
	
		})

}
