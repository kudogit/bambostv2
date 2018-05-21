webpackJsonp(["product-management.module"],{

/***/ "../../../../../src/app/_services/product.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return ProductService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_common_http__ = __webpack_require__("../../../common/esm5/http.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2_rxjs_Observable__ = __webpack_require__("../../../../rxjs/_esm5/Observable.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__setting_service__ = __webpack_require__("../../../../../src/app/_services/setting.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4_rxjs_add_operator_map__ = __webpack_require__("../../../../rxjs/_esm5/add/operator/map.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5_rxjs_add_operator_catch__ = __webpack_require__("../../../../rxjs/_esm5/add/operator/catch.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};






var ProductService = (function () {
    function ProductService(http, setting) {
        this.http = http;
        this.setting = setting;
    }
    ProductService.prototype.createProductCategory = function (model) {
        return this.http.post(this.setting.admin + 'api/product/category/create', model)
            .map(function (res) { return res; })
            .catch(function (err) { return __WEBPACK_IMPORTED_MODULE_2_rxjs_Observable__["a" /* Observable */].throw(err.json()); });
    };
    ProductService.prototype.getProductCategorie = function () {
        return this.http.get(this.setting.admin + 'api/product/category/gets')
            .map(function (res) { return res; })
            .catch(function (err) { return __WEBPACK_IMPORTED_MODULE_2_rxjs_Observable__["a" /* Observable */].throw(err.json()); });
    };
    ProductService.prototype.deleteProductCategory = function (id) {
        return this.http.delete(this.setting.admin + 'api/product/category/delete/' + id)
            .map(function (res) { return res; })
            .catch(function (err) { return __WEBPACK_IMPORTED_MODULE_2_rxjs_Observable__["a" /* Observable */].throw(err.json()); });
    };
    ProductService.prototype.editProductCategory = function (model) {
        return this.http.put(this.setting.admin + 'api/product/category/update', model)
            .map(function (res) { return res; })
            .catch(function (err) { return __WEBPACK_IMPORTED_MODULE_2_rxjs_Observable__["a" /* Observable */].throw(err.json()); });
    };
    ProductService.prototype.createProduct = function (model) {
        return this.http.post(this.setting.admin + 'api/product/create', model)
            .map(function (res) { return res; })
            .catch(function (err) { return __WEBPACK_IMPORTED_MODULE_2_rxjs_Observable__["a" /* Observable */].throw(err.json()); });
    };
    ProductService.prototype.getProduct = function () {
        return this.http.get(this.setting.admin + 'api/product/getall')
            .map(function (res) { return res; })
            .catch(function (err) { return __WEBPACK_IMPORTED_MODULE_2_rxjs_Observable__["a" /* Observable */].throw(err.json()); });
    };
    ProductService.prototype.deleteProduct = function (id) {
        return this.http.delete(this.setting.admin + 'api/product/delete/' + id)
            .map(function (res) { return res; })
            .catch(function (err) { return __WEBPACK_IMPORTED_MODULE_2_rxjs_Observable__["a" /* Observable */].throw(err.json()); });
    };
    ProductService.prototype.editProduct = function (model) {
        return this.http.put(this.setting.admin + 'api/product/edit/', model)
            .map(function (res) { return res; })
            .catch(function (err) { return __WEBPACK_IMPORTED_MODULE_2_rxjs_Observable__["a" /* Observable */].throw(err.json()); });
    };
    ProductService = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Injectable"])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__angular_common_http__["a" /* HttpClient */],
            __WEBPACK_IMPORTED_MODULE_3__setting_service__["a" /* SettingsService */]])
    ], ProductService);
    return ProductService;
}());



/***/ }),

/***/ "../../../../../src/app/theme/pages/default/product-management/product-create/product-create.component.css":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, ".mt-20{\r\n    margin-top: 20px;\r\n  }\r\n  .m-form.m-form--group-seperator-dashed .m-form__group{\r\n    border-bottom: none;\r\n  }", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/theme/pages/default/product-management/product-create/product-create.component.html":
/***/ (function(module, exports) {

module.exports = "<!-- BEGIN: Subheader -->\r\n<div class=\"m-subheader\" appunwraptag=\"\">\r\n    <div class=\"d-flex align-items-center\">\r\n        <div class=\"mr-auto\">\r\n            <h3 class=\"m-subheader__title m-subheader__title--separator\">\r\n                Thêm Mới Dự Án\r\n            </h3>\r\n            <ul class=\"m-subheader__breadcrumbs m-nav m-nav--inline\">\r\n                <li class=\"m-nav__item m-nav__item--home\">\r\n                    <a routerLink=\"/index\" class=\"m-nav__link m-nav__link--icon\">\r\n                        <i class=\"m-nav__link-icon la la-home\"></i>\r\n                    </a>\r\n                </li>\r\n                <li class=\"m-nav__separator\">\r\n                    -\r\n                </li>\r\n                <li class=\"m-nav__item\">\r\n                    <a href=\"#\" class=\"m-nav__link\">\r\n                        <span class=\"m-nav__link-text\">\r\n                            Dự Án\r\n                        </span>\r\n                    </a>\r\n                </li>\r\n                <li class=\"m-nav__separator\">\r\n                    -\r\n                </li>\r\n                <li class=\"m-nav__item\">\r\n                    <a href=\"#\" class=\"m-nav__link\">\r\n                        <span class=\"m-nav__link-text\">\r\n                            Thêm Mới\r\n                        </span>\r\n                    </a>\r\n                </li>\r\n            </ul>\r\n        </div>\r\n    </div>\r\n</div>\r\n<!-- END: Subheader -->\r\n<div class=\"m-content\">\r\n    <div class=\"row\">\r\n        <div class=\"col-lg-12\">\r\n            <!--begin::Portlet-->\r\n            <div class=\"m-portlet\">\r\n                <div class=\"m-portlet__head\">\r\n                    <div class=\"m-portlet__head-caption\">\r\n                        <div class=\"m-portlet__head-title\">\r\n                            <span class=\"m-portlet__head-icon m--hide\">\r\n                                <i class=\"la la-gear\"></i>\r\n                            </span>\r\n                            <h3 class=\"m-portlet__head-text text-danger\">\r\n                                Điền đầy đủ thông tin vào các trường (*)\r\n                            </h3>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n                <!--begin::Form-->\r\n                <form (ngSubmit)=\"addNewProduct($event)\" class=\"m-form m-form--fit m-form--label-align-right m-form--group-seperator-dashed\"\r\n                    [formGroup]=\"productForm\">\r\n                    <div class=\"form-group m-form__group\">\r\n                        <label for=\"Title\">Tên sản phẩm:</label>\r\n                        <span class=\"text-danger\">(*)</span>\r\n                        <input type=\"text\" class=\"form-control\" formControlName=\"title\">\r\n                    </div>\r\n                    <div class=\"form-group m-form__group\">\r\n                        <label class=\"center-block\">Loại sản phẩm:\r\n                            <select class=\"form-control\" formControlName=\"productCategoryId\">\r\n                                <option *ngFor=\"let productCategory of productCategories\" [value]=\"productCategory.id\">{{productCategory.name}}</option>\r\n                            </select>\r\n                        </label>\r\n                    </div>\r\n                    <div class=\"form-group m-form__group\">\r\n                        <label for=\"Investor\">Chủ đầu tư:</label>\r\n                        <span class=\"text-danger\">(*)</span>\r\n                        <input type=\"text\" class=\"form-control\" name=\"Investor\" formControlName=\"investor\">\r\n                    </div>\r\n                    <div class=\"form-group m-form__group\">\r\n                        <label for=\"Efficiency\">Công suất thiết kế:</label>\r\n                        <span class=\"text-danger\">(*)</span>\r\n                        <input type=\"text\" class=\"form-control\" name=\"Efficiency\" formControlName=\"efficiency\">\r\n                    </div>\r\n                    <div class=\"form-group m-form__group\">\r\n                        <label for=\"Standard\">Tiêu chuẩn xả thải:</label>\r\n                        <span class=\"text-danger\">(*)</span>\r\n                        <input type=\"text\" class=\"form-control\" name=\"Standard\" formControlName=\"standard\">\r\n                    </div>\r\n                    <div class=\"form-group m-form__group\">\r\n                        <label for=\"Progress\">Tiến độ:</label>\r\n                        <span class=\"text-danger\">(*)</span>\r\n                        <input type=\"text\" class=\"form-control\" name=\"Progress\" formControlName=\"progress\">\r\n                    </div>\r\n                    <div class=\"form-group m-form__group\">\r\n                        <label for=\"Description\">Mô tả:</label>\r\n                        <p-editor class=\"form-control\" [style]=\"{'height':'320px'}\" formControlName=\"description\"></p-editor>\r\n                    </div>\r\n                    <div class=\"form-group m-form__group\">\r\n                        <div class=\"col-lg-12\">\r\n                            <label class=\"control-label\">\r\n                                Chọn Hình ảnh :\r\n                                <span class=\"text-danger\">(*)</span>\r\n                            </label>\r\n                            <p-fileUpload mode=\"basic\" name=\"myfile[]\" customUpload=\"true\" multiple=\"true\"></p-fileUpload>\r\n                        </div>\r\n                    </div>\r\n                    <div class=\"m-portlet__foot m-portlet__no-border m-portlet__foot--fit\">\r\n                        <div class=\"m-form__actions m-form__actions--solid\">\r\n                            <div class=\"row\">\r\n                                <div class=\"col-lg-6\">\r\n                                    <button type=\"submit\" class=\"btn btn-primary\" [disabled]=\"!productForm.valid\">\r\n                                        Thêm Mới\r\n                                    </button>\r\n                                    <button id=\"create-product-btn\" type=\"button\" class=\"btn btn-secondary\" (click)=\"resetForm()\" data-dismiss=\"modal\" #cancelBtn>\r\n                                        Hủy\r\n                                    </button>\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </form>\r\n\r\n                <!--end::Form-->\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>"

/***/ }),

/***/ "../../../../../src/app/theme/pages/default/product-management/product-create/product-create.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return ProductCreateComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_forms__ = __webpack_require__("../../../forms/esm5/forms.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__services_product_service__ = __webpack_require__("../../../../../src/app/_services/product.service.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};



var ProductCreateComponent = (function () {
    function ProductCreateComponent(productService) {
        this.productService = productService;
        this.reloadProducts = new __WEBPACK_IMPORTED_MODULE_0__angular_core__["EventEmitter"]();
        this.newProduct = {
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
        this.productForm = new __WEBPACK_IMPORTED_MODULE_1__angular_forms__["FormGroup"]({
            title: new __WEBPACK_IMPORTED_MODULE_1__angular_forms__["FormControl"](this.newProduct.title, [__WEBPACK_IMPORTED_MODULE_1__angular_forms__["Validators"].required]),
            investor: new __WEBPACK_IMPORTED_MODULE_1__angular_forms__["FormControl"](this.newProduct.investor, [__WEBPACK_IMPORTED_MODULE_1__angular_forms__["Validators"].required]),
            efficiency: new __WEBPACK_IMPORTED_MODULE_1__angular_forms__["FormControl"](this.newProduct.efficiency, [__WEBPACK_IMPORTED_MODULE_1__angular_forms__["Validators"].required]),
            standard: new __WEBPACK_IMPORTED_MODULE_1__angular_forms__["FormControl"](this.newProduct.standard, [__WEBPACK_IMPORTED_MODULE_1__angular_forms__["Validators"].required]),
            progress: new __WEBPACK_IMPORTED_MODULE_1__angular_forms__["FormControl"](this.newProduct.progress, [__WEBPACK_IMPORTED_MODULE_1__angular_forms__["Validators"].required]),
            description: new __WEBPACK_IMPORTED_MODULE_1__angular_forms__["FormControl"](this.newProduct.description, []),
            productCategoryId: new __WEBPACK_IMPORTED_MODULE_1__angular_forms__["FormControl"](2)
        });
        this.uploadedFiles = [];
    }
    ProductCreateComponent.prototype.ngOnInit = function () {
        this.getProductCategories();
    };
    ProductCreateComponent.prototype.onUploadFile = function (event) {
        console.log(event.files);
    };
    ProductCreateComponent.prototype.saveImage = function () {
        console.log(this.uploadedFiles);
    };
    ProductCreateComponent.prototype.getProductCategories = function () {
        var _this = this;
        this.productService.getProductCategorie().subscribe(function (data) {
            _this.productCategories = data;
            _this.productCategories.forEach(function (element) {
                element.isEdit = false;
            });
        });
    };
    ProductCreateComponent.prototype.addNewProduct = function (event) {
        var _this = this;
        this.productService.createProduct(this.productForm.value).subscribe(function (data) {
            _this.reloadProducts.emit(null);
            _this.cancelBtn.nativeElement.click();
        });
    };
    ProductCreateComponent.prototype.resetForm = function () {
        this.productForm.reset();
    };
    __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Output"])(),
        __metadata("design:type", Object)
    ], ProductCreateComponent.prototype, "reloadProducts", void 0);
    __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["ViewChild"])('cancelBtn'),
        __metadata("design:type", __WEBPACK_IMPORTED_MODULE_0__angular_core__["ElementRef"])
    ], ProductCreateComponent.prototype, "cancelBtn", void 0);
    ProductCreateComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Component"])({
            selector: 'app-product-create',
            template: __webpack_require__("../../../../../src/app/theme/pages/default/product-management/product-create/product-create.component.html"),
            styles: [__webpack_require__("../../../../../src/app/theme/pages/default/product-management/product-create/product-create.component.css")]
        }),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_2__services_product_service__["a" /* ProductService */]])
    ], ProductCreateComponent);
    return ProductCreateComponent;
}());



/***/ }),

/***/ "../../../../../src/app/theme/pages/default/product-management/product-management.component.css":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, ".m-datatable.m-datatable--default > .m-datatable__table{\r\n    min-height: auto;\r\n}\r\n.modal-dialog{\r\n    max-width: 50%;\r\n}", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/theme/pages/default/product-management/product-management.component.html":
/***/ (function(module, exports) {

module.exports = "<div class=\"m-subheader\" appunwraptag=\"\">\r\n  <div class=\"d-flex align-items-center\">\r\n    <div class=\"mr-auto\">\r\n      <h3 class=\"m-subheader__title m-subheader__title--separator\">\r\n        Quản lý sản phẩm\r\n      </h3>\r\n      <ul class=\"m-subheader__breadcrumbs m-nav m-nav--inline\">\r\n        <li class=\"m-nav__item m-nav__item--home\">\r\n          <i class=\"m-nav__link-icon la la-home\"></i>\r\n        </li>\r\n        <li class=\"m-nav__separator\">\r\n          -\r\n        </li>\r\n        <li class=\"m-nav__item\">\r\n          <span class=\"m-nav__link-text\">\r\n            Loại Sản Phẩm\r\n          </span>\r\n        </li>\r\n      </ul>\r\n    </div>\r\n  </div>\r\n</div>\r\n\r\n<div class=\"m-content\">\r\n  <div class=\"m-portlet m-portlet--mobile\">\r\n    <div class=\"m-portlet__head\">\r\n      <div class=\"m-portlet__head-caption\">\r\n        <div class=\"m-portlet__head-title\">\r\n          <h3 class=\"m-portlet__head-text\">\r\n            Danh sách loại sản phẩm\r\n          </h3>\r\n        </div>\r\n      </div>\r\n    </div>\r\n    <div class=\"m-portlet__body\">\r\n      <!--begin: Search Form -->\r\n      <div class=\"m-form m-form--label-align-right m--margin-top-20 m--margin-bottom-30\">\r\n        <div class=\"row align-items-center\">\r\n          <div class=\"col-xl-8 order-2 order-xl-1\">\r\n            <div class=\"form-group m-form__group row align-items-center\">\r\n              <div class=\"col-md-12\">\r\n                <div class=\"m-input-icon m-input-icon--left\">\r\n                  <input type=\"text\" class=\"form-control m-input m-input--solid\" placeholder=\"Search...\" [(ngModel)]=\"filter\">\r\n                  <span class=\"m-input-icon__icon m-input-icon__icon--left\">\r\n                    <span>\r\n                      <i class=\"la la-search\"></i>\r\n                    </span>\r\n                  </span>\r\n                </div>\r\n              </div>\r\n            </div>\r\n          </div>\r\n          <div class=\"col-xl-4 order-1 order-xl-2 m--align-right\">\r\n            <a href=\"#\" (click)=\"isAddNewProductCategory = true\" class=\"btn btn-accent m-btn m-btn--custom m-btn--icon m-btn--air m-btn--pill\">\r\n              <span>\r\n                <i class=\"la la-cart-plus\"></i>\r\n                <span>\r\n                  Thêm Mới\r\n                </span>\r\n              </span>\r\n            </a>\r\n            <div class=\"m-separator m-separator--dashed d-xl-none\"></div>\r\n          </div>\r\n        </div>\r\n      </div>\r\n      <!--end: Search Form -->\r\n      <!--begin: Datatable -->\r\n      <div class=\"m_datatable m-datatable m-datatable--default m-datatable--loaded\">\r\n        <table class=\"m-datatable__table\">\r\n          <thead class=\"m-datatable__head\">\r\n            <tr class=\"m-datatable__row\">\r\n              <th class=\"m-datatable__cell--center m-datatable__cell m-datatable__cell--check\" style=\"width: 5%;\">\r\n                <span>\r\n                  <label class=\"m-checkbox m-checkbox--single m-checkbox--all m-checkbox--solid m-checkbox--brand\">\r\n                    <input type=\"checkbox\">\r\n                    <span></span>\r\n                  </label>\r\n                </span>\r\n              </th>\r\n              <th class=\"m-datatable__cell m-datatable__cell--sort\" style=\"width: 70%;\">\r\n                <span>Name</span>\r\n              </th>\r\n              <th class=\"m-datatable__cell m-datatable__cell--sort\" style=\"width: 25%;\">\r\n                <span>Actions</span>\r\n              </th>\r\n            </tr>\r\n          </thead>\r\n          <tbody class=\"m-datatable__body\">\r\n            <tr class=\"m-datatable__row\" *ngIf=\"isAddNewProductCategory\">\r\n              <td class=\"m-datatable__cell--center m-datatable__cell m-datatable__cell--check\" style=\"width: 5%;\">\r\n                <span>\r\n                  <label class=\"m-checkbox m-checkbox--single m-checkbox--solid m-checkbox--brand\">\r\n                    <input type=\"checkbox\">\r\n                    <span></span>\r\n                  </label>\r\n                </span>\r\n              </td>\r\n              <td class=\"m-datatable__cell\" style=\"width: 70%;\">\r\n                <span>\r\n                  <input class=\"form-control m-input m-input--solid\" type=\"text\" placeholder=\"Tên loại dự án\" [(ngModel)]=\"productCategoryModel.name\">\r\n                </span>\r\n              </td>\r\n              <td class=\"m-datatable__cell\" style=\"width: 25%;\">\r\n                <span>\r\n                  <button class=\"btn btn-primary\" (click)=\"createProductCategery()\">Save</button>\r\n                  <button class=\"btn btn-warning\" (click)=\"isAddNewProductCategory = false; productCategoryModel.name = ''\">Cancel</button>\r\n                </span>\r\n              </td>\r\n            </tr>\r\n            <tr class=\"m-datatable__row\" *ngFor=\"let item of productCategories | filter:filter\">\r\n              <td class=\"m-datatable__cell--center m-datatable__cell m-datatable__cell--check\" style=\"width: 5%;\">\r\n                <span>\r\n                  <label class=\"m-checkbox m-checkbox--single m-checkbox--solid m-checkbox--brand\">\r\n                    <input type=\"checkbox\" value=\"item.id\">\r\n                    <span></span>\r\n                  </label>\r\n                </span>\r\n              </td>\r\n              <td class=\"m-datatable__cell\" style=\"width: 70%;\">\r\n                <span *ngIf=\"!item.isEdit\">{{item.name}}</span>\r\n                <span *ngIf=\"item.isEdit\">\r\n                  <input class=\"form-control m-input m-input--solid\" type=\"text\" [(ngModel)]=\"item.name\">\r\n                </span>\r\n              </td>\r\n              <td class=\"m-datatable__cell\" style=\"width: 25%;\">\r\n                <span>\r\n                  <button *ngIf=\"!item.isEdit\" class=\"btn btn-warning\" (click)=\"deleteProductCategory(item.id)\">Delete</button>\r\n                  <button *ngIf=\"!item.isEdit\" (click)=\"item.isEdit = true\" class=\"btn btn-primary\">Edit</button>\r\n                  <button *ngIf=\"item.isEdit\" class=\"btn btn-primary\" (click)=\"editProductCategory(item)\">Save</button>\r\n                  <button *ngIf=\"item.isEdit\" class=\"btn btn-warning\" (click)=\"item.isEdit = false\">Cancel</button>\r\n                </span>\r\n              </td>\r\n            </tr>\r\n          </tbody>\r\n        </table>\r\n        <!--    Paging here     -->\r\n      </div>\r\n      <!--end: Datatable -->\r\n    </div>\r\n  </div>\r\n</div>\r\n\r\n<div class=\"m-content\">\r\n  <div class=\"m-portlet m-portlet--mobile\">\r\n    <div class=\"m-portlet__head\">\r\n      <div class=\"m-portlet__head-caption\">\r\n        <div class=\"m-portlet__head-title\">\r\n          <h3 class=\"m-portlet__head-text\">\r\n            Danh sách sản phẩm\r\n          </h3>\r\n        </div>\r\n      </div>\r\n    </div>\r\n    <div class=\"m-portlet__body\">\r\n      <!--begin: Search Form -->\r\n      <div class=\"m-form m-form--label-align-right m--margin-top-20 m--margin-bottom-30\">\r\n        <div class=\"row align-items-center\">\r\n          <div class=\"col-xl-8 order-2 order-xl-1\">\r\n            <div class=\"form-group m-form__group row align-items-center\">\r\n              <div class=\"col-md-12\">\r\n                <div class=\"m-input-icon m-input-icon--left\">\r\n                  <input type=\"text\" class=\"form-control m-input m-input--solid\" placeholder=\"Search...\">\r\n                  <span class=\"m-input-icon__icon m-input-icon__icon--left\">\r\n                    <span>\r\n                      <i class=\"la la-search\"></i>\r\n                    </span>\r\n                  </span>\r\n                </div>\r\n              </div>\r\n            </div>\r\n          </div>\r\n          <div class=\"col-xl-4 order-1 order-xl-2 m--align-right\">\r\n            <a href=\"#\" data-toggle=\"modal\" data-target=\"#myModal\" class=\"btn btn-accent m-btn m-btn--custom m-btn--icon m-btn--air m-btn--pill\">\r\n              <span>\r\n                <i class=\"la la-cart-plus\"></i>\r\n                <span>\r\n                  Thêm Mới\r\n                </span>\r\n              </span>\r\n            </a>\r\n            <div class=\"m-separator m-separator--dashed d-xl-none\"></div>\r\n          </div>\r\n        </div>\r\n      </div>\r\n      <!--end: Search Form -->\r\n      <!--begin: Datatable -->\r\n      <div class=\"m_datatable m-datatable m-datatable--default m-datatable--loaded\">\r\n        <table class=\"m-datatable__table\">\r\n          <thead class=\"m-datatable__head\">\r\n            <tr class=\"m-datatable__row\">\r\n              <th class=\"m-datatable__cell--center m-datatable__cell m-datatable__cell--check\">\r\n                <span style=\"width: 50px;\">\r\n                  <label class=\"m-checkbox m-checkbox--single m-checkbox--all m-checkbox--solid m-checkbox--brand\">\r\n                    <input type=\"checkbox\">\r\n                    <span></span>\r\n                  </label>\r\n                </span>\r\n              </th>\r\n              <th class=\"m-datatable__cell m-datatable__cell--sort\">\r\n                <span style=\"width: 132px;\">Tên sản phẩm</span>\r\n              </th>\r\n              <th class=\"m-datatable__cell m-datatable__cell--sort\">\r\n                <span style=\"width: 132px;\">Loại sản phẩm</span>\r\n              </th>\r\n              <th class=\"m-datatable__cell m-datatable__cell--sort\">\r\n                <span style=\"width: 132px;\">Chủ đầu tư</span>\r\n              </th>\r\n              <th class=\"m-datatable__cell m-datatable__cell--sort\">\r\n                <span style=\"width: 132px;\">Công suất thiết kế</span>\r\n              </th>\r\n              <th class=\"m-datatable__cell m-datatable__cell--sort\">\r\n                <span style=\"width: 132px;\">Tiêu chuẩn</span>\r\n              </th>\r\n              <th class=\"m-datatable__cell m-datatable__cell--sort\">\r\n                <span style=\"width: 132px;\">Tiến độ</span>\r\n              </th>\r\n              <th class=\"m-datatable__cell m-datatable__cell--sort\">\r\n                <span style=\"width: 132px;\"></span>\r\n              </th>\r\n            </tr>\r\n          </thead>\r\n          <tbody class=\"m-datatable__body\">\r\n            <tr class=\"m-datatable__row\" *ngFor=\"let product of products\">\r\n              <td class=\"m-datatable__cell--center m-datatable__cell m-datatable__cell--check\">\r\n                <span style=\"width: 50px;\">\r\n                  <label class=\"m-checkbox m-checkbox--single m-checkbox--solid m-checkbox--brand\">\r\n                    <input type=\"checkbox\" value=\"item.id\">\r\n                    <span></span>\r\n                  </label>\r\n                </span>\r\n              </td>\r\n              <td class=\"m-datatable__cell\">\r\n                <span style=\"width: 132px;\">{{product.title}}</span>\r\n              </td>\r\n              <td class=\"m-datatable__cell\">\r\n                <span style=\"width: 132px;\">{{getProductCategoryName(product.productCategoryId)}}</span>\r\n              </td>\r\n              <td class=\"m-datatable__cell\">\r\n                <span style=\"width: 132px;\">{{product.investor}}</span>\r\n              </td>\r\n              <td class=\"m-datatable__cell\">\r\n                <span style=\"width: 132px;\">{{product.efficiency}}</span>\r\n              </td>\r\n              <td class=\"m-datatable__cell\">\r\n                <span style=\"width: 132px;\">{{product.standard}}</span>\r\n              </td>\r\n              <td class=\"m-datatable__cell\">\r\n                <span style=\"width: 132px;\">{{product.progress}}</span>\r\n              </td>\r\n              <td class=\"m-datatable__cell\">\r\n                <span style=\"width: 132px;\">\r\n                  <button class=\"btn-warning\" (click)=\"deleteProduct(product.id)\">Delete</button>\r\n                  <button (click)=\"item.isEdit = true\" class=\"btn-primary\" data-toggle=\"modal\" (click)=\"selectEditProduct(product)\" data-target=\"#editProductModal\">Edit</button>\r\n                </span>\r\n              </td>\r\n            </tr>\r\n          </tbody>\r\n        </table>\r\n        <!--    Paging here     -->\r\n      </div>\r\n      <!--end: Datatable -->\r\n    </div>\r\n  </div>\r\n</div>\r\n\r\n<!--Popup-->\r\n<div class=\"modal fade\" id=\"myModal\" role=\"dialog\">\r\n  <div class=\"modal-dialog\">\r\n\r\n    <!-- Modal content-->\r\n    <div class=\"modal-content\">\r\n      <div class=\"modal-header\">\r\n        <button type=\"button\" class=\"close\" data-dismiss=\"modal\">&times;</button>\r\n      </div>\r\n      <app-product-create (reloadProducts)=\"getProducts()\"></app-product-create>\r\n    </div>\r\n\r\n  </div>\r\n</div>\r\n<div class=\"modal fade\" id=\"editProjectModal\" role=\"dialog\">\r\n  <div class=\"modal-dialog\">\r\n\r\n    <!-- Modal content-->\r\n    <div class=\"modal-content\">\r\n      <div class=\"modal-header\">\r\n        <button type=\"button\" class=\"close\" data-dismiss=\"modal\">&times;</button>\r\n      </div>\r\n      <!-- <app-project-edit [editProjectParam]=\"editProject\" (reloadProjects)=\"getProjects()\"></app-project-edit> -->\r\n    </div>\r\n\r\n  </div>\r\n</div>"

/***/ }),

/***/ "../../../../../src/app/theme/pages/default/product-management/product-management.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return ProductManagementComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__services_product_service__ = __webpack_require__("../../../../../src/app/_services/product.service.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};


var ProductManagementComponent = (function () {
    function ProductManagementComponent(productService) {
        this.productService = productService;
        this.productCategories = [];
        this.productCategoryModel = {
            name: ''
        };
        this.isAddNewProductCategory = false;
        this.products = [];
    }
    ProductManagementComponent.prototype.ngOnInit = function () {
        this.getproductCategories();
        this.getProducts();
    };
    ProductManagementComponent.prototype.createProductCategery = function () {
        var _this = this;
        this.productService.createProductCategory(this.productCategoryModel).subscribe(function (data) {
            if (data != undefined) {
                _this.productCategories.push({
                    id: data,
                    name: _this.productCategoryModel.name,
                    isEdit: false
                });
                _this.productCategoryModel.name = '';
            }
        });
    };
    ProductManagementComponent.prototype.deleteProductCategory = function (id) {
        var _this = this;
        this.productService.deleteProductCategory(id).subscribe(function (data) {
            _this.productCategories = _this.productCategories.filter(function (item) { return item.id != id; });
        });
    };
    ProductManagementComponent.prototype.editProductCategory = function (item) {
        var _this = this;
        this.productService.editProductCategory(item).subscribe(function (data) {
            _this.getproductCategories();
        });
    };
    ProductManagementComponent.prototype.getproductCategories = function () {
        var _this = this;
        this.productService.getProductCategorie().subscribe(function (data) {
            _this.productCategories = data;
            _this.productCategories.forEach(function (element) {
                element.isEdit = false;
            });
        });
    };
    ProductManagementComponent.prototype.getProducts = function () {
        var _this = this;
        this.productService.getProduct().subscribe(function (data) {
            _this.products = data;
        });
    };
    ProductManagementComponent.prototype.getProductCategoryName = function (productCategoryId) {
        var productCategorie = this.productCategories.find(function (item) { return item.id == productCategoryId; });
        return productCategorie.name;
    };
    ProductManagementComponent.prototype.deleteProduct = function (productId) {
        var _this = this;
        this.productService.deleteProduct(productId).subscribe(function (data) {
            console.log("delete ok");
            _this.products = _this.products.filter(function (item) { return item.id != productId; });
        }, function (err) {
            console.log("delete error: ", err);
        });
    };
    ProductManagementComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Component"])({
            selector: 'app-product-management',
            template: __webpack_require__("../../../../../src/app/theme/pages/default/product-management/product-management.component.html"),
            encapsulation: __WEBPACK_IMPORTED_MODULE_0__angular_core__["ViewEncapsulation"].None,
            styles: [__webpack_require__("../../../../../src/app/theme/pages/default/product-management/product-management.component.css")]
        }),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__services_product_service__["a" /* ProductService */]])
    ], ProductManagementComponent);
    return ProductManagementComponent;
}());



/***/ }),

/***/ "../../../../../src/app/theme/pages/default/product-management/product-management.module.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ProductManagementModule", function() { return ProductManagementModule; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_common__ = __webpack_require__("../../../common/esm5/common.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__angular_router__ = __webpack_require__("../../../router/esm5/router.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__angular_forms__ = __webpack_require__("../../../forms/esm5/forms.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__product_management_component__ = __webpack_require__("../../../../../src/app/theme/pages/default/product-management/product-management.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5__default_component__ = __webpack_require__("../../../../../src/app/theme/pages/default/default.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_6__layouts_layout_module__ = __webpack_require__("../../../../../src/app/theme/layouts/layout.module.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_7_primeng_primeng__ = __webpack_require__("../../../../primeng/primeng.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_7_primeng_primeng___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_7_primeng_primeng__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_8__angular_common_http__ = __webpack_require__("../../../common/esm5/http.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_9_ng2_search_filter__ = __webpack_require__("../../../../ng2-search-filter/ng2-search-filter.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_10_primeng_components_editor_editor__ = __webpack_require__("../../../../primeng/components/editor/editor.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_10_primeng_components_editor_editor___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_10_primeng_components_editor_editor__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_11__services_product_service__ = __webpack_require__("../../../../../src/app/_services/product.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_12__product_create_product_create_component__ = __webpack_require__("../../../../../src/app/theme/pages/default/product-management/product-create/product-create.component.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};













var routes = [
    {
        path: '',
        component: __WEBPACK_IMPORTED_MODULE_5__default_component__["a" /* DefaultComponent */],
        children: [
            {
                path: '',
                component: __WEBPACK_IMPORTED_MODULE_4__product_management_component__["a" /* ProductManagementComponent */],
            },
            {
                path: 'tao-san-pham',
                component: __WEBPACK_IMPORTED_MODULE_12__product_create_product_create_component__["a" /* ProductCreateComponent */],
            },
        ],
    },
];
var ProductManagementModule = (function () {
    function ProductManagementModule() {
    }
    ProductManagementModule = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["NgModule"])({
            imports: [
                __WEBPACK_IMPORTED_MODULE_1__angular_common__["CommonModule"],
                __WEBPACK_IMPORTED_MODULE_3__angular_forms__["FormsModule"],
                __WEBPACK_IMPORTED_MODULE_3__angular_forms__["ReactiveFormsModule"],
                __WEBPACK_IMPORTED_MODULE_2__angular_router__["RouterModule"].forChild(routes),
                __WEBPACK_IMPORTED_MODULE_6__layouts_layout_module__["a" /* LayoutModule */],
                __WEBPACK_IMPORTED_MODULE_8__angular_common_http__["b" /* HttpClientModule */],
                __WEBPACK_IMPORTED_MODULE_9_ng2_search_filter__["a" /* Ng2SearchPipeModule */],
                __WEBPACK_IMPORTED_MODULE_7_primeng_primeng__["DropdownModule"],
                __WEBPACK_IMPORTED_MODULE_7_primeng_primeng__["FileUploadModule"],
                __WEBPACK_IMPORTED_MODULE_10_primeng_components_editor_editor__["EditorModule"]
            ],
            declarations: [
                __WEBPACK_IMPORTED_MODULE_4__product_management_component__["a" /* ProductManagementComponent */],
                __WEBPACK_IMPORTED_MODULE_12__product_create_product_create_component__["a" /* ProductCreateComponent */]
            ],
            providers: [
                __WEBPACK_IMPORTED_MODULE_8__angular_common_http__["a" /* HttpClient */],
                __WEBPACK_IMPORTED_MODULE_11__services_product_service__["a" /* ProductService */]
            ]
        })
    ], ProductManagementModule);
    return ProductManagementModule;
}());



/***/ }),

/***/ "../../../../ng2-search-filter/ng2-search-filter.es5.js":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return Ng2SearchPipeModule; });
/* unused harmony export Ng2SearchPipe */
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");

var Ng2SearchPipe = /** @class */ (function () {
    function Ng2SearchPipe() {
    }
    /**
     * @param {?} items object from array
     * @param {?} term term's search
     * @return {?}
     */
    Ng2SearchPipe.prototype.transform = function (items, term) {
        if (!term || !items)
            return items;
        return Ng2SearchPipe.filter(items, term);
    };
    /**
     *
     * @param {?} items List of items to filter
     * @param {?} term  a string term to compare with every property of the list
     *
     * @return {?}
     */
    Ng2SearchPipe.filter = function (items, term) {
        var /** @type {?} */ toCompare = term.toLowerCase();
        return items.filter(function (item) {
            for (var /** @type {?} */ property in item) {
                if (item[property] === null) {
                    continue;
                }
                if (item[property].toString().toLowerCase().includes(toCompare)) {
                    return true;
                }
            }
            return false;
        });
    };
    return Ng2SearchPipe;
}());
Ng2SearchPipe.decorators = [
    { type: __WEBPACK_IMPORTED_MODULE_0__angular_core__["Pipe"], args: [{
                name: 'filter',
                pure: false
            },] },
    { type: __WEBPACK_IMPORTED_MODULE_0__angular_core__["Injectable"] },
];
/**
 * @nocollapse
 */
Ng2SearchPipe.ctorParameters = function () { return []; };
var Ng2SearchPipeModule = /** @class */ (function () {
    function Ng2SearchPipeModule() {
    }
    return Ng2SearchPipeModule;
}());
Ng2SearchPipeModule.decorators = [
    { type: __WEBPACK_IMPORTED_MODULE_0__angular_core__["NgModule"], args: [{
                declarations: [Ng2SearchPipe],
                exports: [Ng2SearchPipe]
            },] },
];
/**
 * @nocollapse
 */
Ng2SearchPipeModule.ctorParameters = function () { return []; };
/**
 * Generated bundle index. Do not edit.
 */

//# sourceMappingURL=ng2-search-filter.es5.js.map


/***/ })

});
//# sourceMappingURL=product-management.module.chunk.js.map