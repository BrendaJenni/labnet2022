import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  Validators,
  FormControl,
} from '@angular/forms';
import { Categories } from './models/categories';
import { CategoryService } from '../services/category.service';

@Component({
  selector: 'categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css'],
})
export class CategoriesComponent implements OnInit {
  public formCategory: FormGroup;
  public updateForm: FormGroup;
  public categoriesList: Array<Categories> = [];

  public newCategory: Categories = new Categories();

  constructor(
    private readonly formBuilder1: FormBuilder,
    private readonly formBuilder2: FormBuilder,
    private categoryService: CategoryService
  ) {}

  ngOnInit(): void {
    this.getCategories();
    this.initForm();
  }
  initForm() {
    this.formCategory = this.formBuilder1.group({
      name: new FormControl('', [
        Validators.required,
        Validators.maxLength(20),
        Validators.minLength(3),
        Validators.pattern('[a-zA-Z]*'),
      ]),
    });
    this.updateForm = this.formBuilder2.group({
      newName: new FormControl('', [
        Validators.required,
        Validators.maxLength(20),
        Validators.minLength(3),
        Validators.pattern('[a-zA-Z]*'),
      ]),
    });
  }
  get categoryControl() {
    return this.formCategory.controls;
  }
  get categoryToUpdate() {
    return this.updateForm.controls;
  }
  saveForm() {
    var category = new Categories();
    category.CategoryName = this.categoryControl.name.value;

    this.categoryService.createCategory(category).subscribe(() => {
      this.formCategory.reset();
      this.getCategories();
    });
  }

  cancelForm() {
    this.formCategory.reset();
  }
  getCategories() {
    this.categoryService.getCategory().subscribe((res) => {
      this.categoriesList = res;
    });
  }
  deleteCategory(id: number) {
    this.categoryService.deleteCategory(id).subscribe(
      () => this.ngOnInit(),
      () => alert('Can not delete category')
    );
  }
  updateCategory(id: number, name: string) {
    this.newCategory.CategoryId = id;
    this.newCategory.CategoryName = name; //this.categoryToUpdate.newName.value;
    console.log(this.newCategory);
    this.categoryService.updateCategory(this.newCategory).subscribe(() => {
      this.updateForm.reset(),
        this.getCategories(),
        () => alert('Failed to update category');
    });
  }
  onSubmit(): void {
    console.log(this.formCategory.value);
  }
}
