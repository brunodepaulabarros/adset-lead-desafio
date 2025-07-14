import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { VeiculosRoutingModule } from './veiculos-routing.module';
import { VeiculosComponent } from './veiculos.component';
import { ListComponent } from './list/list.component';


@NgModule({
  declarations: [
    VeiculosComponent,
    ListComponent
  ],
  imports: [
    CommonModule,
    VeiculosRoutingModule
  ]
})
export class VeiculosModule { }
