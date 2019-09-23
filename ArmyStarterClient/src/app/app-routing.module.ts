import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { UnitCalculatorComponent } from "./unit-calculator/unit-calculator.component";
import { ArmyPlanComponent } from "./army-plan/army-plan.component";
import { HomeComponent } from "./home/home.component";

const routes: Routes = [
  { path: "Calculator", component: UnitCalculatorComponent },
  { path: "ArmyPlan", component: ArmyPlanComponent },
  { path: "Home", redirectTo: "", pathMatch: "full" },
  { path: "", component: HomeComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
