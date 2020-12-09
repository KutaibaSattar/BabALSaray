import { Component, Input, OnInit } from '@angular/core';
import { dbAccounts } from 'src/app/_models/adaccounts';

@Component({
  selector: 'app-dbaccount-card',
  templateUrl: './dbaccount-card.component.html',
  styleUrls: ['./dbaccount-card.component.css']
})
export class DbaccountCardComponent implements OnInit {
  
  @Input()  dbaccount : dbAccounts

  constructor() { }

  ngOnInit(): void {
  }

}
