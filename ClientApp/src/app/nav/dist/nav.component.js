"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
exports.__esModule = true;
exports.NavComponent = void 0;
var core_1 = require("@angular/core");
var NavComponent = /** @class */ (function () {
    function NavComponent(accountService) {
        this.accountService = accountService;
        this.model = {};
    }
    NavComponent.prototype.ngOnInit = function () {
        this.getCurrentUser();
    };
    NavComponent.prototype.login = function () {
        var _this = this;
        console.log(this.model);
        this.accountService.login(this.model).subscribe(function (res) {
            console.log(res);
            _this.loggedIn = true;
        }, function (err) { return (console.log(err)); });
    };
    NavComponent.prototype.logout = function () {
        this.accountService.logout();
        this.loggedIn = false;
    };
    NavComponent.prototype.getCurrentUser = function () {
        var _this = this;
        this.accountService.currentUser$.subscribe(function (user) {
            _this.loggedIn = !!user;
        }, function (error) { console.log(error); });
    };
    NavComponent = __decorate([
        core_1.Component({
            selector: 'app-nav',
            templateUrl: './nav.component.html',
            styleUrls: ['./nav.component.css']
        })
    ], NavComponent);
    return NavComponent;
}());
exports.NavComponent = NavComponent;
