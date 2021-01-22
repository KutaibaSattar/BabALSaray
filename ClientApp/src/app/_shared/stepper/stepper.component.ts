import { CdkStepper } from '@angular/cdk/stepper';
import { Component, Input, OnInit } from '@angular/core';


@Component({
  selector: 'app-stepper',
  templateUrl: './stepper.component.html',
  styleUrls: ['./stepper.component.css'],
  providers: [{provide: CdkStepper , useExisting: StepperComponent}]
})
export class StepperComponent extends CdkStepper implements OnInit { // our class extended the cdkStepper
  /* let the client tell us or the child component whether or not the linear mode is selected */
  @Input() linearModeSelected: boolean;


  ngOnInit(): void {
    this.linear = this.linearModeSelected;
  }
  onClick(index: number) {
    this.selectedIndex = index;

  }



}
