import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { WalletIndexComponent } from './wallet/wallet-index/wallet-index.component';

const routes: Routes = [
  { path: 'wallet', component: WalletIndexComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }