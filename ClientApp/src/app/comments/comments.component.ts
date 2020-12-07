import { Component, Input, OnInit } from '@angular/core';
import { dbAccounts } from '../_models/adaccounts';
import { DbaccountsService } from '../_services/dbaccounts.service';

 
interface TreeNode {
	label: string;
	name :string;
	children: TreeNode[];
}
@Component({
  selector: 'comments',
  templateUrl : './comments.component.html',
  styleUrls: ['./comments.component.css']
})


export class CommentsComponent {
 
	public data  = {key: "",name :"",	children: [	]}  
	
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
		console.log(dbaccts[0]);
		//this.data = dbaccts[0];
		console.log(this.data);
		
	   
	
		})
	
	  }
	// ---
	// PUBLIC METHODS.
	// ---
 
	// I select the given tree node, and log it to the console.
	/* public selectNode( node: TreeNode ) : void {
 
		this.selectedTreeNode = node;
 
		console.group( "Selected Tree Node" );
		console.log( "Label:", node.label );
		console.log( "Children:", node.children.length );
		console.groupEnd();
 
	} */
 
}