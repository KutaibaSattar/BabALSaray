import { Component, Input, OnInit } from '@angular/core';
import { dbAccounts } from '../_models/adaccounts';
import { DbaccountsService } from '../_services/dbaccounts.service';
interface Tree {
	root: TreeNode;
}
 
interface TreeNode {
	label: string;
	children: TreeNode[];
}
@Component({
  selector: 'comments',
  templateUrl : './comments.component.html',
  styleUrls: ['./comments.component.css']
})


export class CommentsComponent {
 
	public data : Tree;
	public selectedTreeNode: TreeNode | null;
	dbaccounts : dbAccounts[];
	// I initialize the app component.
	constructor(private dbAccountsService : DbaccountsService) {		
		
		this.selectedTreeNode = null;
	
	
		this.data = {
			root: {
				label: "first",
				children: [
					{
						label: "second-a",
						children: [
							{
								label: "third-first",
								children: [
									{
										label: "ferth",
										children: [
											{
												label: "fiver",
												children: []
											}
										]
									}
								]
							}
						]
					},
					{
						label: "second-b",
						children: [
							{
								label: "third",
								children: []
							}
						]
					}
				]
			} 
		}
 
	}
 
	ngOnInit(): void {
		this.loadDbAccounts();
	
	  }

	  loadDbAccounts(){

		this.dbAccountsService.getdbAccounts().subscribe(dbaccts => {
		this.dbaccounts = dbaccts;
		 console.log(dbaccts);
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