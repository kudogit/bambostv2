import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { ProductService } from '../../../../_services/product.service';

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
    }

    public productCategories: ProductCategory[] = [];
    public productCategoryModel: CreateProductCategory = {
        name: ''
    }

    filter: any;
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
            }
        })
    }

    deleteProductCategory(id) {
        this.productService.deleteProductCategory(id).subscribe(data => {
            this.productCategories = this.productCategories.filter(item => item.id != id);
        })
    }

    editProductCategory(item) {
        this.productService.editProductCategory(item).subscribe(data => {
            this.getproductCategories();
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
            console.log("delete ok");
            this.products = this.products.filter(item => item.id != productId);
        }, err => {
            console.log("delete error: ", err);
        });
    }
}
