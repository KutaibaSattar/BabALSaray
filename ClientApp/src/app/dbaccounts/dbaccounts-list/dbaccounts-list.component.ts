import { Component, OnInit } from '@angular/core';
import { dbAccounts } from 'src/app/_models/adaccounts';
import { DbaccountsService } from 'src/app/_services/dbaccounts.service';

interface TreeNode {
	label: string;
	name :string;
	children: TreeNode[];
}

@Component({
  selector: 'app-dbaccounts-list',
  templateUrl: './dbaccounts-list.component.html',
  styleUrls: ['./dbaccounts-list.component.css']
})



export class DbaccountsListComponent implements OnInit {

  public data = {id:0, parentId:0 ,key: "",name :"", lvl:0,children: [	]}
	public selectedTreeNode: TreeNode | null;

	dbaccounts : dbAccounts[];

	// I initialize the app component.
	constructor(private dbAccountsService : DbaccountsService) {}

	ngOnInit(): void {
	this.loadDbAccounts();
	this.selectedTreeNode = null;

	  }

	  loadDbAccounts(){

		this.dbAccountsService.getdbAccounts().subscribe(dbaccts => {
		this.dbaccounts = dbaccts;
		this.data= this.dbaccounts[0];

		})

	  }
	// ---
	// PUBLIC METHODS.
	// ---

	// I select the given tree node, and log it to the console.
	public selectNode( node: TreeNode ) : void {

		this.selectedTreeNode = node;

		console.group( "Selected Tree Node" );
		console.log( "Label:", node.label );
		console.log( "Children:", node.children.length );
		console.groupEnd();

	}






}
