import { Component, OnInit, Output, ViewChild, ElementRef, EventEmitter } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ProductService } from '../../../../../_services/product.service';

@Component({
  selector: 'app-product-create',
  templateUrl: './product-create.component.html',
  styleUrls: ['./product-create.component.css']
})
export class ProductCreateComponent implements OnInit {

  @Output() reloadProducts = new EventEmitter<any>();
  @ViewChild('cancelBtn') cancelBtn: ElementRef;

  public productCategories: ProductCategory[];

  public newProduct: Product = {
    id: 0,
    title: '',
    investor: '',
    efficiency: '',
    standard: '',
    progress: '',
    description: '',
    productCategoryId: 2,
    productCategoryName: ''
  };

  public productForm = new FormGroup({
    title: new FormControl(this.newProduct.title, [Validators.required]),
    investor: new FormControl(this.newProduct.investor, [Validators.required]),
    efficiency: new FormControl(this.newProduct.efficiency, [Validators.required]),
    standard: new FormControl(this.newProduct.standard, [Validators.required]),
    progress: new FormControl(this.newProduct.progress, [Validators.required]),
    description: new FormControl(this.newProduct.description, []),
    productCategoryId: new FormControl(2)
  });

  uploadedFiles: any[] = [];

  constructor(public productService: ProductService) { }

  ngOnInit() {
    this.getProductCategories();
  }


  onUploadFile(event) {
    console.log(event.files);
  }

  saveImage() {
    console.log(this.uploadedFiles);
  }

  getProductCategories() {
    this.productService.getProductCategorie().subscribe(data => {
      this.productCategories = data;
      this.productCategories.forEach(element => {
        element.isEdit = false
      });
    });
  }

  addNewProduct(event) {
    this.productService.createProduct(this.productForm.value).subscribe(data => {
      this.reloadProducts.emit(null);
      this.cancelBtn.nativeElement.click();
    });
  }

  resetForm() {
    this.productForm.reset();
  }

}
