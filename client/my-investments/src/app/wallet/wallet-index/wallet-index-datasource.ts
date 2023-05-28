import { DataSource } from '@angular/cdk/collections';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { map } from 'rxjs/operators';
import { Observable, of as observableOf, merge } from 'rxjs';

// TODO: Replace this with your own data model type
export interface Stock {
  id: number;
  name: string;
  ticker: string;
  total: number;
  unitPrice: number;
  totalPrice: number;
  unitsGoal: number;
  costToGoal: number;
  position: number;
  goal: number;
  meanPrice: number;
  totalPaid: number;
  gainLoss:number;
}

// TODO: replace this with real data from your application
const EXAMPLE_DATA: Stock[] = [
  {id: 1, name: "TAESA", ticker:"TAEE4", total: 260, unitPrice: 12.52, totalPrice:3225.20, unitsGoal:315, costToGoal: 688.60, position: 26.47, goal: 32, meanPrice: 12.42, totalPaid: 3229.32, gainLoss: 25.88 },
  {id: 2, name: "Banco do Brasil", ticker:"BBAS3", total: 50, unitPrice: 44.40, totalPrice:2220, unitsGoal:50, costToGoal: 0, position: 18.05, goal: 18, meanPrice: 36.28, totalPaid: 1813.93, gainLoss: 406.07 },
  {id: 3, name: "Santander", ticker:"SANB3", total: 131, unitPrice: 13.57, totalPrice: 1777.67, unitsGoal: 155, costToGoal: 325.68, position: 14.45, goal: 17, meanPrice: 13.87, totalPaid: 1817.27, gainLoss: 406.07 },
  {id: 4, name: "Klabin", ticker:"KLBN4", total: 400, unitPrice: 4.27, totalPrice:1708, unitsGoal:145, costToGoal: -1088.85, position: 13.89, goal: 5, meanPrice: 3.71, totalPaid: 1482.14, gainLoss: 225.86 },
  {id: 5, name: "Itaúsa", ticker:"ITSA4", total: 120, unitPrice: 8.98, totalPrice:1077.60, unitsGoal:124, costToGoal: 35.92, position: 8.76, goal: 9, meanPrice: 8.35, totalPaid: 1001.69, gainLoss: 75.91 },
  {id: 6, name: "Cemig", ticker:"CMIG4", total: 74, unitPrice: 12.03, totalPrice:890.22, unitsGoal:72, costToGoal: -24.06, position: 7.24, goal: 7, meanPrice: 10.41, totalPaid: 770.56, gainLoss: 119.66 },
  {id: 7, name: "Copel", ticker:"CPLE6", total: 110, unitPrice: 7.68, totalPrice:844.80, unitsGoal:113, costToGoal: 23.04, position: 6.87, goal: 7, meanPrice: 6.82, totalPaid: 750.44, gainLoss: 94.36 },
  {id: 8, name: "Irani", ticker:"RANI3", total: 61, unitPrice: 8.61, totalPrice:525.21, unitsGoal:72, costToGoal: 94.71, position: 4.27, goal: 5, meanPrice: 8.13, totalPaid: 495.92, gainLoss: 29.29 },
];

/**
 * Data source for the WalletIndex view. This class should
 * encapsulate all logic for fetching and manipulating the displayed data
 * (including sorting, pagination, and filtering).
 */
export class WalletIndexDataSource extends DataSource<Stock> {
  data: Stock[] = EXAMPLE_DATA;
  paginator: MatPaginator | undefined;
  sort: MatSort | undefined;

  constructor() {
    super();
  }

  /**
   * Connect this data source to the table. The table will only update when
   * the returned stream emits new items.
   * @returns A stream of the items to be rendered.
   */
  connect(): Observable<Stock[]> {
    if (this.paginator && this.sort) {
      // Combine everything that affects the rendered data into one update
      // stream for the data-table to consume.
      return merge(observableOf(this.data), this.paginator.page, this.sort.sortChange)
        .pipe(map(() => {
          return this.getPagedData(this.getSortedData([...this.data ]));
        }));
    } else {
      throw Error('Please set the paginator and sort on the data source before connecting.');
    }
  }

  /**
   *  Called when the table is being destroyed. Use this function, to clean up
   * any open connections or free any held resources that were set up during connect.
   */
  disconnect(): void {}

  /**
   * Paginate the data (client-side). If you're using server-side pagination,
   * this would be replaced by requesting the appropriate data from the server.
   */
  private getPagedData(data: Stock[]): Stock[] {
    if (this.paginator) {
      const startIndex = this.paginator.pageIndex * this.paginator.pageSize;
      return data.splice(startIndex, this.paginator.pageSize);
    } else {
      return data;
    }
  }

  /**
   * Sort the data (client-side). If you're using server-side sorting,
   * this would be replaced by requesting the appropriate data from the server.
   */
  private getSortedData(data: Stock[]): Stock[] {
    if (!this.sort || !this.sort.active || this.sort.direction === '') {
      return data;
    }

    return data.sort((a, b) => {
      const isAsc = this.sort?.direction === 'asc';
      switch (this.sort?.active) {
        case 'name': return compare(a.name, b.name, isAsc);
        case 'id': return compare(+a.id, +b.id, isAsc);
        default: return 0;
      }
    });
  }
}

/** Simple sort comparator for example ID/Name columns (for client-side sorting). */
function compare(a: string | number, b: string | number, isAsc: boolean): number {
  return (a < b ? -1 : 1) * (isAsc ? 1 : -1);
}
