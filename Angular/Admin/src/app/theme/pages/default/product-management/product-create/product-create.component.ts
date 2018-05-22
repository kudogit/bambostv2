import { Component, OnInit, Output, ViewChild, ElementRef, EventEmitter } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ProductService } from '../../../../../_services/product.service';
import { Message, GrowlModule } from 'primeng/primeng';
import { MessageService } from 'primeng/components/common/messageservice';
import { Subject } from 'rxjs';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
    selector: 'app-product-create',
    templateUrl: './product-create.component.html',
    styleUrls: ['./product-create.component.css']
})
export class ProductCreateComponent implements OnInit {

    public productCategories: ProductCategory[];
    msgs: Message[] = [];
    submitSubject = new Subject;
    productId: any;
    product: Product;

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
        id: new FormControl(this.newProduct.id, []),
        title: new FormControl(this.newProduct.title, [Validators.required]),
        investor: new FormControl(this.newProduct.investor, [Validators.required]),
        efficiency: new FormControl(this.newProduct.efficiency, [Validators.required]),
        standard: new FormControl(this.newProduct.standard, [Validators.required]),
        progress: new FormControl(this.newProduct.progress, [Validators.required]),
        description: new FormControl(this.newProduct.description, []),
        productCategoryId: new FormControl(2)
    });

    uploadedFiles: any[] = [];

    constructor(public productService: ProductService, private router: Router,
        private route: ActivatedRoute) { }

    ngOnInit() {
        this.route.params.subscribe(res => {
            this.productId = res['id'];
            if (this.productId) {
                this.productService.getProductById(this.productId).subscribe(data => {
                    this.product = data;
                    console.log("getProductById: ", data);
                    if (this.product) {
                        this.productForm.patchValue(this.product);
                    }
                });
            }
        });
        this.getProductCategories();
        this.submitSubject.debounceTime(1000).subscribe(item => {
            this.router.navigate(["/quan-ly-san-pham"]);
        });
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
            this.msgs.push({ severity: 'success', summary: 'Tạo sản phẩm thành công' });
            this.submitSubject.next();
        }, err => {
            this.msgs.push({ severity: 'error', summary: err });
        });
    }

    editProduct(event) {
        this.productService.editProduct(this.productForm.value).subscribe(data => {
            this.msgs.push({ severity: 'success', summary: 'Chỉnh sửa thành công' });
            this.submitSubject.next();
        }, err => {
            this.msgs.push({ severity: 'error', summary: err });
        });
    }

    resetForm() {
        this.productForm.reset();
    }

}
