import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { ProductService } from '../../../../_services/product.service';
import { Message } from 'primeng/primeng';
import { Subject } from 'rxjs';

@Component({
    selector: 'app-product-management',
    templateUrl: './product-management.component.html',
    encapsulation: ViewEncapsulation.None,
    styleUrls: ['./product-management.component.css']
})
export class ProductManagementComponent implements OnInit {

    constructor(public productService: ProductService) { }

    ngOnInit() {
        this.getproductCategories();
        this.getProducts();
        this.clearMsgSubject.debounceTime(2000).subscribe(item => {
            this.msgs = [];
        });
    }

    public productCategories: ProductCategory[] = [];
    public productCategoryModel: CreateProductCategory = {
        name: ''
    }

    filter: any;
    msgs: Message[] = [];
    clearMsgSubject = new Subject;
    public isAddNewProductCategory: boolean = false;
    public editProduct: Product;
    public products: Product[] = [];

    createProductCategery() {
        this.productService.createProductCategory(this.productCategoryModel).subscribe(data => {
            if (data != undefined) {
                this.productCategories.push({
                    id: data,
                    name: this.productCategoryModel.name,
                    isEdit: false
                });
                this.productCategoryModel.name = '';
                this.msgs.push({ severity: 'success', summary: 'Thêm mới thành công' });
                this.clearMsgSubject.next();
            }
        })
    }

    deleteProductCategory(id) {
        this.productService.deleteProductCategory(id).subscribe(data => {
            this.productCategories = this.productCategories.filter(item => item.id != id);
            this.msgs.push({ severity: 'success', summary: 'Xóa thành công' });
            this.clearMsgSubject.next();
        })
    }

    editProductCategory(item) {
        this.productService.editProductCategory(item).subscribe(data => {
            this.getproductCategories();
            this.msgs.push({ severity: 'success', summary: 'Chỉnh sửa thành công' });
            this.clearMsgSubject.next();
        })
    }

    getproductCategories() {
        this.productService.getProductCategorie().subscribe(data => {
            this.productCategories = data;
            this.productCategories.forEach(element => {
                element.isEdit = false
            });
        });
    }

    getProducts() {
        this.productService.getProduct().subscribe(data => {
            this.products = data;
        })
    }

    getProductCategoryName(productCategoryId) {
        var productCategorie = this.productCategories.find(item => item.id == productCategoryId);
        return productCategorie.name;
    }

    deleteProduct(productId) {
        this.productService.deleteProduct(productId).subscribe(data => {
            this.msgs.push({ severity: 'success', summary: 'Xóa thành công' });
            this.clearMsgSubject.next();
            this.products = this.products.filter(item => item.id != productId);
        }, err => {
            this.msgs.push({ severity: 'error', summary: err });
            this.clearMsgSubject.next();
        });
    }
}
