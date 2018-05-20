import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { SettingsService } from './setting.service';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
@Injectable()
export class ProductService {
    constructor(
        private http: HttpClient,
        private setting: SettingsService) {

    }

    createProductCategory(model: CreateProductCategory): Observable<any> {
        return this.http.post(this.setting.admin + 'api/product/category/create', model)
            .map(res => { return res })
            .catch(err => Observable.throw(err.json()));
    }

    getProductCategorie(): Observable<ProductCategory[]> {
        return this.http.get(this.setting.admin + 'api/product/category/gets')
            .map(res => { return res })
            .catch(err => Observable.throw(err.json()));
    }

    deleteProductCategory(id: number): Observable<any> {
        return this.http.delete(this.setting.admin + 'api/product/category/delete/' + id)
            .map(res => { return res })
            .catch(err => Observable.throw(err.json()));
    }

    editProductCategory(model: ProductCategory): Observable<any> {
        return this.http.put(this.setting.admin + 'api/product/category/update', model)
            .map(res => { return res })
            .catch(err => Observable.throw(err.json()));
    }


    createProduct(model: Product): Observable<number> {
        return this.http.post(this.setting.admin + 'api/product/create', model)
            .map(res => { return res })
            .catch(err => Observable.throw(err.json()));
    }

    getProduct(): Observable<Product[]> {
        return this.http.get(this.setting.admin + 'api/product/getall')
            .map(res => { return res })
            .catch(err => Observable.throw(err.json()));
    }

    deleteProduct(id: number): any {
        return this.http.delete(this.setting.admin + 'api/product/delete/' + id)
            .map(res => { return res })
            .catch(err => Observable.throw(err.json()));
    }

    editProduct(model: Product): any {
        return this.http.put(this.setting.admin + 'api/product/edit/', model)
            .map(res => { return res })
            .catch(err => Observable.throw(err.json()));
    }

}