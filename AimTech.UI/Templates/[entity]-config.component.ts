import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material';
import { CategoryEntityService } from '../services/category.entity.service';
import { Category } from '../models/category.model';
import { RemoveDialogComponent } from 'app/shared/components/remove-dialog/remove-dialog.component';
import { baseUrl } from 'environments/environment';
import { AppRoutes } from 'app/shared/constants/app-routes';
@Component({
  selector: 'app-category-config',
  templateUrl: './category-config.component.html',
  styleUrls: ['./category-config.component.scss']
})
export class CategoryConfigComponent implements OnInit {
  category:Category;
  configType:string = "New";
  myForm:FormGroup;
  imagePath:string;

  constructor(
    private service:CategoryEntityService,
    private router:Router,
    private formBuilder: FormBuilder,
    public dialog: MatDialog) { }
  ngOnInit() {
   this.category = new Category();
    if(this.service.Category){
      this.configType = "Update";
      this.category = this.service.Category;
      if(this.category.imagePath)
      this.imagePath = baseUrl + this.category.imagePath;
    }
    this.myForm = this.formBuilder.group({
      name: [this.category.name, Validators.required],
      description:[this.category.description],
      }
    )
  }

   // convenience getter for easy access to form fields
   get f() { return this.myForm.controls; }

  onSubmit(){
    if (this.myForm.invalid)
    return;
    this.category.name = this.myForm.value.name;
    this.category.description = this.myForm.value.description;
    if(this.category.id){
      this.service.update(this.category).subscribe(result =>{
        this.router.navigate([AppRoutes.categoryList]);
      })
    } 
    else{
      this.service.add(this.category).subscribe(result =>{
        this.router.navigate([AppRoutes.categoryList]);
      })
    }
  }

  onDelete(){
  const dialogRef = this.dialog.open(RemoveDialogComponent);

  dialogRef.afterClosed().subscribe(result =>{
    if(result === 'Yes'){
      this.service.delete(this.category);
      this.router.navigate([AppRoutes.categoryList]);
    }
  })
  }

}
