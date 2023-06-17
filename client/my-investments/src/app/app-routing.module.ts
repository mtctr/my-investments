import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { WalletIndexComponent } from './wallet/wallet-index/wallet-index.component';
import { DividendMapComponent } from './wallet/dividend-map/dividend-map.component';
import { MeanPriceComponent } from './wallet/mean-price/mean-price.component';

const routes: Routes = [
  { path: 'wallet', component: WalletIndexComponent },
  { path: 'dividend-map', component: DividendMapComponent },
  { path: 'mean-price', component: MeanPriceComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }