import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";

import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { UnitCalculatorComponent } from "./unit-calculator/unit-calculator.component";
import { ArmyComponent } from "./army/army.component";
import { ArmyPlanComponent } from "./army-plan/army-plan.component";
import { ArmyPlanListComponent } from "./army-plan-list/army-plan-list.component";
import { NavigatorComponent } from './navigator/navigator.component';
import { HomeComponent } from './home/home.component';

@NgModule({
  declarations: [
    AppComponent,
    UnitCalculatorComponent,
    ArmyComponent,
    ArmyPlanComponent,
    ArmyPlanListComponent,
    NavigatorComponent,
    HomeComponent
  ],
  imports: [BrowserModule, AppRoutingModule],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {}
