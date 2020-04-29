import { __decorate } from "tslib";
import { Component } from '@angular/core';
//change this to include external template, maybe use polymer for this later
let AppComponent = class AppComponent {
    constructor() {
        this.title = 'Vote on the songs you like or dislike';
    }
};
AppComponent = __decorate([
    Component({
        selector: 'app-model',
        templateUrl: "./app.component.html",
        styles: []
    })
], AppComponent);
export { AppComponent };
//# sourceMappingURL=app.component.js.map