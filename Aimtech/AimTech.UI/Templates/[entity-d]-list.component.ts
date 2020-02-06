import { Component, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { Router } from '@angular/router';
import { MatSort, MatPaginator, MatTableDataSource, MatDialog } from '@angular/material';
import { [Entity] } from '../models/[entity:d].model';
import { [Entity]EntityService } from '../services/[entity:d].entity.service';
import { baseUrl } from 'environments/environment';
import { fuseAnimations } from '@fuse/animations';
import { RemoveDialogComponent } from 'app/shared/components/remove-dialog/remove-dialog.component';
import { AppRoutes } from 'app/shared/constants/app-routes';
@Component({
  selector: 'app-[entity:d]-list',
  templateUrl: './[entity:d]-list.component.html',
  styleUrls: ['./[entity:d]-list.component.scss'],
  animations: fuseAnimations,
  encapsulation: ViewEncapsulation.None
})
export class [Entity]ListComponent implements OnInit {

  displayedColumns = ['image', 'name','createddate','updateddate', 'status', 'action'];
  baseUrl = baseUrl;
  dataSource = new MatTableDataSource<[Entity]>();
  @ViewChild(MatSort, { static: false }) sort: MatSort;
  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;
  constructor(
    private service: [Entity]EntityService,
    private router: Router,
    public dialog: MatDialog) { }

  ngOnInit() {
    this.service.getAll();
    this.service.entities$.pipe().subscribe(devices => {
      this.dataSource.data = devices;
    })
  }

  ngAfterViewInit() {
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
  }

  doFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  edit([entity:d]) {
    if ([entity:d])
      this.service.[Entity] = [entity:d];
    this.router.navigate(['/configuration/[entity:d]-config']);
  }

  new[Entity]() {
    this.service.[Entity] = undefined;
    this.router.navigate(['/configuration/[entity:d]-config']);
  }

  getImagePath(path) {
    return baseUrl + path;
  }

  openDeleteDialog([entity:d]){
    const dialogRef = this.dialog.open(RemoveDialogComponent);

    dialogRef.afterClosed().subscribe(result =>{
      if(result === 'Yes'){
        this.service.delete([entity:d]);
        this.router.navigate([AppRoutes.[entity:d]List]);
      }
    })
  }


}
