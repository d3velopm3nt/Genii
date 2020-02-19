import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material';
import { [Entity]EntityService } from '../services/[entity-d].entity.service';
import { [Entity] } from '../models/[entity-d].model';
import { RemoveDialogComponent } from 'app/shared/components/remove-dialog/remove-dialog.component';
import { baseUrl } from 'environments/environment';
import { AppRoutes } from 'app/shared/constants/app-routes';
@Component({
  selector: '[entity-d]-config',
  templateUrl: './[entity-d]-config.component.html',
  styleUrls: ['./[entity-d]-config.component.scss']
})
export class [Entity]ConfigComponent implements OnInit {
  [entity-cc]:[Entity];
  configType:string = "New";
  myForm:FormGroup;
  imagePath:string;

  constructor(
    private service:[Entity]EntityService,
    private router:Router,
    private formBuilder: FormBuilder,
    public dialog: MatDialog) { }
  ngOnInit() {
   this.[entity-cc] = new [Entity]();
    if(this.service.[Entity-cc]){
      this.configType = "Update";
      this.[entity-cc] = this.service.[Entity-cc];
      if(this.[entity-cc].imagePath)
      this.imagePath = baseUrl + this.[Entity-cc].imagePath;
    }
    this.myForm = this.formBuilder.group({
      name: [this.[entity-cc].name, Validators.required],
      description:[this.[entity-cc].description],
      }
    )
  }

   // convenience getter for easy access to form fields
   get f() { return this.myForm.controls; }

  onSubmit(){
    if (this.myForm.invalid)
    return;
    this.[entity-cc].name = this.myForm.value.name;
    this.[entity-cc].description = this.myForm.value.description;
    if(this.[entity-cc].id){
      this.service.update(this.[entity-cc]).subscribe(result =>{
        this.router.navigate([AppRoutes.[entity-cc]List]);
      })
    } 
    else{
      this.service.add(this.[entity-cc]).subscribe(result =>{
        this.router.navigate([AppRoutes.[entity-cc]List]);
      })
    }
  }

  onDelete(){
  const dialogRef = this.dialog.open(RemoveDialogComponent);

  dialogRef.afterClosed().subscribe(result =>{
    if(result === 'Yes'){
      this.service.delete(this.[entity-cc]);
      this.router.navigate([AppRoutes.[entity-cc]List]);
    }
  })
  }

}
