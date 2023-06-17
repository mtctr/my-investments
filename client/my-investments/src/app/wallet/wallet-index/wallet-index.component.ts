import { AfterViewInit, Component, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTable } from '@angular/material/table';
import { WalletIndexDataSource, Stock } from './wallet-index-datasource';

@Component({
  selector: 'app-wallet-index',
  templateUrl: './wallet-index.component.html',
  styleUrls: ['./wallet-index.component.css']
})
export class WalletIndexComponent implements AfterViewInit {
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  @ViewChild(MatTable) table!: MatTable<Stock>;
  dataSource: WalletIndexDataSource;

  /** Columns displayed in the table. Columns IDs can be added, removed, or reordered. */
  displayedColumns = [
    'id', 
    'name', 
    'ticker', 
    'total', 
    'unitPrice', 
    'totalPrice',     
    'unitsGoal',
    'costToGoal',
    'position',
    'goal',
    'meanPrice',
    'totalPaid',
    'gainLoss'];

  constructor() {
    this.dataSource = new WalletIndexDataSource();
  }

  ngAfterViewInit(): void {
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
    this.table.dataSource = this.dataSource;
  }
}
