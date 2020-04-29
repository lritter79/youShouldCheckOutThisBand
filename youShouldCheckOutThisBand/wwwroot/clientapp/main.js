(window["webpackJsonp"] = window["webpackJsonp"] || []).push([["main"],{

/***/ "./$$_lazy_route_resource lazy recursive":
/*!******************************************************!*\
  !*** ./$$_lazy_route_resource lazy namespace object ***!
  \******************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

function webpackEmptyAsyncContext(req) {
	// Here Promise.resolve().then() is used instead of new Promise() to prevent
	// uncaught exception popping up in devtools
	return Promise.resolve().then(function() {
		var e = new Error("Cannot find module '" + req + "'");
		e.code = 'MODULE_NOT_FOUND';
		throw e;
	});
}
webpackEmptyAsyncContext.keys = function() { return []; };
webpackEmptyAsyncContext.resolve = webpackEmptyAsyncContext;
module.exports = webpackEmptyAsyncContext;
webpackEmptyAsyncContext.id = "./$$_lazy_route_resource lazy recursive";

/***/ }),

/***/ "./ClientApp/app/app.component.ts":
/*!****************************************!*\
  !*** ./ClientApp/app/app.component.ts ***!
  \****************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

Object.defineProperty(exports, "__esModule", { value: true });
const tslib_1 = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
const core_1 = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");
//change this to include external template, maybe use polymer for this later
let AppComponent = class AppComponent {
    constructor() {
        this.title = 'Votes on your favorite songs';
    }
};
AppComponent = tslib_1.__decorate([
    core_1.Component({
        selector: 'app-model',
        template: tslib_1.__importDefault(__webpack_require__(/*! raw-loader!./app.component.html */ "./node_modules/raw-loader/dist/cjs.js!./ClientApp/app/app.component.html")).default
    })
], AppComponent);
exports.AppComponent = AppComponent;


/***/ }),

/***/ "./ClientApp/app/app.module.ts":
/*!*************************************!*\
  !*** ./ClientApp/app/app.module.ts ***!
  \*************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

Object.defineProperty(exports, "__esModule", { value: true });
const tslib_1 = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
const platform_browser_1 = __webpack_require__(/*! @angular/platform-browser */ "./node_modules/@angular/platform-browser/__ivy_ngcc__/fesm2015/platform-browser.js");
const core_1 = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");
//see documentation on safe pipe here: https://www.npmjs.com/package/safe-pipe
const safe_pipe_1 = __webpack_require__(/*! safe-pipe */ "./node_modules/safe-pipe/__ivy_ngcc__/fesm2015/safe-pipe.js");
const artists_component_1 = __webpack_require__(/*! ./artists/artists.component */ "./ClientApp/app/artists/artists.component.ts");
const tracks_component_1 = __webpack_require__(/*! ./tracks/tracks.component */ "./ClientApp/app/tracks/tracks.component.ts");
const trackCard_component_1 = __webpack_require__(/*! ./tracks/trackCard.component */ "./ClientApp/app/tracks/trackCard.component.ts");
const votes_component_1 = __webpack_require__(/*! ./tracks/votes.component */ "./ClientApp/app/tracks/votes.component.ts");
const app_component_1 = __webpack_require__(/*! ./app.component */ "./ClientApp/app/app.component.ts");
const dataService_1 = __webpack_require__(/*! ../shared/data/dataService */ "./ClientApp/shared/data/dataService.ts");
//support using http client module to make api requests
const http_1 = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/__ivy_ngcc__/fesm2015/http.js");
//the purpose of angular is basically dependency inejction for your site
//so that's what a lot of this stuff pertains to
let AppModule = class AppModule {
};
AppModule = tslib_1.__decorate([
    core_1.NgModule({
        declarations: [
            app_component_1.AppComponent,
            artists_component_1.ArtistList,
            tracks_component_1.TrackList,
            trackCard_component_1.TrackCard,
            votes_component_1.Votes
        ],
        imports: [
            platform_browser_1.BrowserModule,
            http_1.HttpClientModule,
            safe_pipe_1.SafePipeModule
        ],
        providers: [
            //add data service here for dependency injection
            dataService_1.DataService
        ],
        bootstrap: [app_component_1.AppComponent]
    })
], AppModule);
exports.AppModule = AppModule;


/***/ }),

/***/ "./ClientApp/app/artists/artists.component.ts":
/*!****************************************************!*\
  !*** ./ClientApp/app/artists/artists.component.ts ***!
  \****************************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

Object.defineProperty(exports, "__esModule", { value: true });
const tslib_1 = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
const core_1 = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");
let ArtistList = class ArtistList {
    constructor() {
        this.artists = [{
                name: "Fi"
            }, {
                name: "Fio"
            }];
    }
};
ArtistList = tslib_1.__decorate([
    core_1.Component({
        selector: "artists",
        template: tslib_1.__importDefault(__webpack_require__(/*! raw-loader!./artists.component.html */ "./node_modules/raw-loader/dist/cjs.js!./ClientApp/app/artists/artists.component.html")).default
    })
], ArtistList);
exports.ArtistList = ArtistList;


/***/ }),

/***/ "./ClientApp/app/tracks/trackCard.component.scss":
/*!*******************************************************!*\
  !*** ./ClientApp/app/tracks/trackCard.component.scss ***!
  \*******************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = (".divNameContainer {\n  height: 142px;\n}\n\niframe {\n  display: block;\n  width: 100%;\n}\n\n.card {\n  height: 545px;\n}\n\n.divCounter {\n  float: right;\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbIkNsaWVudEFwcC9hcHAvdHJhY2tzL0M6XFxVc2Vyc1xcbHJpdHRlclxcRGVza3RvcFxceW91U2hvdWxkQ2hlY2tPdXRUaGlzQmFuZFxceW91U2hvdWxkQ2hlY2tPdXRUaGlzQmFuZC9DbGllbnRBcHBcXGFwcFxcdHJhY2tzXFx0cmFja0NhcmQuY29tcG9uZW50LnNjc3MiLCJDbGllbnRBcHAvYXBwL3RyYWNrcy90cmFja0NhcmQuY29tcG9uZW50LnNjc3MiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IkFBQUE7RUFDSSxhQUFBO0FDQ0o7O0FERUE7RUFDSSxjQUFBO0VBQ0EsV0FBQTtBQ0NKOztBREVBO0VBQ0ksYUFBQTtBQ0NKOztBREVBO0VBQ0ksWUFBQTtBQ0NKIiwiZmlsZSI6IkNsaWVudEFwcC9hcHAvdHJhY2tzL3RyYWNrQ2FyZC5jb21wb25lbnQuc2NzcyIsInNvdXJjZXNDb250ZW50IjpbIi5kaXZOYW1lQ29udGFpbmVyIHtcclxuICAgIGhlaWdodDogMTQycHg7XHJcbn1cclxuXHJcbmlmcmFtZSB7XHJcbiAgICBkaXNwbGF5OiBibG9jaztcclxuICAgIHdpZHRoOiAxMDAlO1xyXG59XHJcblxyXG4uY2FyZCB7XHJcbiAgICBoZWlnaHQ6IDU0NXB4O1xyXG59XHJcblxyXG4uZGl2Q291bnRlciB7XHJcbiAgICBmbG9hdDogcmlnaHQ7XHJcbn1cclxuIiwiLmRpdk5hbWVDb250YWluZXIge1xuICBoZWlnaHQ6IDE0MnB4O1xufVxuXG5pZnJhbWUge1xuICBkaXNwbGF5OiBibG9jaztcbiAgd2lkdGg6IDEwMCU7XG59XG5cbi5jYXJkIHtcbiAgaGVpZ2h0OiA1NDVweDtcbn1cblxuLmRpdkNvdW50ZXIge1xuICBmbG9hdDogcmlnaHQ7XG59Il19 */");

/***/ }),

/***/ "./ClientApp/app/tracks/trackCard.component.ts":
/*!*****************************************************!*\
  !*** ./ClientApp/app/tracks/trackCard.component.ts ***!
  \*****************************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

Object.defineProperty(exports, "__esModule", { value: true });
const tslib_1 = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
const core_1 = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");
let TrackCard = 
//interface that says once you're ready, call a method
class TrackCard {
    //private makes private member of the class
    //injects it into track list
    constructor() {
    }
    ngOnInit() {
        this.totalVotes = this.track.sumOfVotes;
        this.getColor(this.totalVotes);
        this.artists = this.getArtistName(this.track);
    }
    getVoteTotal($event) {
        this.totalVotes = $event;
    }
    getColor(totalVotes) {
        if (totalVotes > 0) {
            return "blue";
        }
        else if (totalVotes < 0) {
            return "red";
        }
    }
    getArtistName(tr) {
        let returnString = "";
        if (tr.artists.length > 1) {
            tr.artists.forEach(function (artist) {
                if (artist.uri == tr.artists[tr.artists.length - 2].uri) {
                    returnString += artist.name + ", and ";
                }
                else if (artist.uri == tr.artists[tr.artists.length - 1].uri) {
                    returnString += artist.name;
                }
                else {
                    returnString += artist.name + ", ";
                }
            });
        }
        else {
            returnString = tr.artists[0].name;
        }
        return returnString;
    }
};
tslib_1.__decorate([
    core_1.Input()
], TrackCard.prototype, "track", void 0);
TrackCard = tslib_1.__decorate([
    core_1.Component({
        selector: "track-card",
        template: tslib_1.__importDefault(__webpack_require__(/*! raw-loader!./trackCard.component.html */ "./node_modules/raw-loader/dist/cjs.js!./ClientApp/app/tracks/trackCard.component.html")).default,
        styles: [tslib_1.__importDefault(__webpack_require__(/*! ./trackCard.component.scss */ "./ClientApp/app/tracks/trackCard.component.scss")).default]
    })
    //interface that says once you're ready, call a method
], TrackCard);
exports.TrackCard = TrackCard;


/***/ }),

/***/ "./ClientApp/app/tracks/tracks.component.css":
/*!***************************************************!*\
  !*** ./ClientApp/app/tracks/tracks.component.css ***!
  \***************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJDbGllbnRBcHAvYXBwL3RyYWNrcy90cmFja3MuY29tcG9uZW50LmNzcyJ9 */");

/***/ }),

/***/ "./ClientApp/app/tracks/tracks.component.ts":
/*!**************************************************!*\
  !*** ./ClientApp/app/tracks/tracks.component.ts ***!
  \**************************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

Object.defineProperty(exports, "__esModule", { value: true });
const tslib_1 = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
const core_1 = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");
const dataService_1 = __webpack_require__(/*! ../../shared/data/dataService */ "./ClientApp/shared/data/dataService.ts");
let TrackList = 
//interface that says once you're ready, call a method
class TrackList {
    //private makes private member of the class
    //injects it into track list
    constructor(data) {
        this.data = data;
        //make sure that an array of tracks is getting returned
        this.tracks = [];
        this.tracks = data.tracks;
    }
    ngOnInit() {
        //once the load products happens, we want to get the data that's being passed back in
        this.data.loadTracks()
            //calls success because the shared component returns a bool
            .subscribe(success => {
            if (success) {
                this.tracks = this.data.tracks;
            }
        });
    }
};
TrackList.ctorParameters = () => [
    { type: dataService_1.DataService }
];
TrackList = tslib_1.__decorate([
    core_1.Component({
        selector: "tracks",
        template: tslib_1.__importDefault(__webpack_require__(/*! raw-loader!./tracks.component.html */ "./node_modules/raw-loader/dist/cjs.js!./ClientApp/app/tracks/tracks.component.html")).default,
        styles: [tslib_1.__importDefault(__webpack_require__(/*! ./tracks.component.css */ "./ClientApp/app/tracks/tracks.component.css")).default]
    })
    //interface that says once you're ready, call a method
], TrackList);
exports.TrackList = TrackList;


/***/ }),

/***/ "./ClientApp/app/tracks/votes.component.scss":
/*!***************************************************!*\
  !*** ./ClientApp/app/tracks/votes.component.scss ***!
  \***************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("div {\n  width: -webkit-fit-content;\n  width: -moz-fit-content;\n  width: fit-content;\n}\n\ndiv > p {\n  margin: 5px;\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbIkNsaWVudEFwcC9hcHAvdHJhY2tzL0M6XFxVc2Vyc1xcbHJpdHRlclxcRGVza3RvcFxceW91U2hvdWxkQ2hlY2tPdXRUaGlzQmFuZFxceW91U2hvdWxkQ2hlY2tPdXRUaGlzQmFuZC9DbGllbnRBcHBcXGFwcFxcdHJhY2tzXFx2b3Rlcy5jb21wb25lbnQuc2NzcyIsIkNsaWVudEFwcC9hcHAvdHJhY2tzL3ZvdGVzLmNvbXBvbmVudC5zY3NzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiJBQUFBO0VBQ0ksMEJBQUE7RUFBQSx1QkFBQTtFQUFBLGtCQUFBO0FDQ0o7O0FERUE7RUFDSSxXQUFBO0FDQ0oiLCJmaWxlIjoiQ2xpZW50QXBwL2FwcC90cmFja3Mvdm90ZXMuY29tcG9uZW50LnNjc3MiLCJzb3VyY2VzQ29udGVudCI6WyJkaXYge1xyXG4gICAgd2lkdGg6IGZpdC1jb250ZW50O1xyXG59XHJcblxyXG5kaXYgPiBwIHtcclxuICAgIG1hcmdpbjogNXB4O1xyXG59XHJcbiIsImRpdiB7XG4gIHdpZHRoOiBmaXQtY29udGVudDtcbn1cblxuZGl2ID4gcCB7XG4gIG1hcmdpbjogNXB4O1xufSJdfQ== */");

/***/ }),

/***/ "./ClientApp/app/tracks/votes.component.ts":
/*!*************************************************!*\
  !*** ./ClientApp/app/tracks/votes.component.ts ***!
  \*************************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

Object.defineProperty(exports, "__esModule", { value: true });
const tslib_1 = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
const core_1 = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");
const dataService_1 = __webpack_require__(/*! ../../shared/data/dataService */ "./ClientApp/shared/data/dataService.ts");
//import { DataService } from '../../shared/data/dataService';
//import track interface so we can use it
//import { Track } from '../../shared/track';
//import { Artist } from '../../shared/artist';
let Votes = class Votes {
    constructor(data) {
        this.data = data;
        this.newTotal = new core_1.EventEmitter();
    }
    ngOnInit() {
        this.newTotal.emit(this.upVotes - this.downVotes);
    }
    subtractVotes(uri) {
        this.downVotes += 1;
        this.changeVotesInRepo(false, uri);
        this.newTotal.emit(this.changeVotesInRepo(true, uri));
        //return downVotes;
    }
    addVotes(uri) {
        this.upVotes += 1;
        this.newTotal.emit(this.changeVotesInRepo(true, uri));
    }
    changeVotesInRepo(vote, trackUri) {
        let newTotal = this.data.getNewVoteTotal(vote, trackUri)
            .subscribe(success => {
            if (success) {
                console.log(this.data.votes);
                return this.data.votes;
            }
        });
    }
};
Votes.ctorParameters = () => [
    { type: dataService_1.DataService }
];
tslib_1.__decorate([
    core_1.Input()
], Votes.prototype, "upVotes", void 0);
tslib_1.__decorate([
    core_1.Input()
], Votes.prototype, "downVotes", void 0);
tslib_1.__decorate([
    core_1.Input()
], Votes.prototype, "uri", void 0);
tslib_1.__decorate([
    core_1.Output()
], Votes.prototype, "newTotal", void 0);
Votes = tslib_1.__decorate([
    core_1.Component({
        selector: "votes",
        template: tslib_1.__importDefault(__webpack_require__(/*! raw-loader!./votes.component.html */ "./node_modules/raw-loader/dist/cjs.js!./ClientApp/app/tracks/votes.component.html")).default,
        styles: [tslib_1.__importDefault(__webpack_require__(/*! ./votes.component.scss */ "./ClientApp/app/tracks/votes.component.scss")).default]
    })
], Votes);
exports.Votes = Votes;


/***/ }),

/***/ "./ClientApp/environments/environment.ts":
/*!***********************************************!*\
  !*** ./ClientApp/environments/environment.ts ***!
  \***********************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.
Object.defineProperty(exports, "__esModule", { value: true });
const tslib_1 = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
exports.environment = {
    production: false
};
/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.


/***/ }),

/***/ "./ClientApp/main.ts":
/*!***************************!*\
  !*** ./ClientApp/main.ts ***!
  \***************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

Object.defineProperty(exports, "__esModule", { value: true });
const tslib_1 = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
const core_1 = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");
const platform_browser_dynamic_1 = __webpack_require__(/*! @angular/platform-browser-dynamic */ "./node_modules/@angular/platform-browser-dynamic/__ivy_ngcc__/fesm2015/platform-browser-dynamic.js");
const app_module_1 = __webpack_require__(/*! ./app/app.module */ "./ClientApp/app/app.module.ts");
const environment_1 = __webpack_require__(/*! ./environments/environment */ "./ClientApp/environments/environment.ts");
if (environment_1.environment.production) {
    core_1.enableProdMode();
}
platform_browser_dynamic_1.platformBrowserDynamic().bootstrapModule(app_module_1.AppModule)
    .catch(err => console.error(err));


/***/ }),

/***/ "./ClientApp/shared/data/dataService.ts":
/*!**********************************************!*\
  !*** ./ClientApp/shared/data/dataService.ts ***!
  \**********************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

Object.defineProperty(exports, "__esModule", { value: true });
const tslib_1 = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
//support using http client to make api requests
const http_1 = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/__ivy_ngcc__/fesm2015/http.js");
const operators_1 = __webpack_require__(/*! rxjs/operators */ "./node_modules/rxjs/_esm2015/operators/index.js");
const core_1 = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");
//we have to decorate to tell the dependency injection serivce that it's part of the chain of injection
//this part is for if it requires other dependencies
let DataService = class DataService {
    constructor(http) {
        this.http = http;
        //add interface for type safety
        this.tracks = [];
    }
    loadTracks() {
        //use http to get our api
        return this.http.get("/api/Tracks")
            // subscribe() says when this is done i want to know the response
            // and kicks of the beginning of this request
            //.subscribe()
            //what we want to do is intercept the call and change the data
            .pipe(
        //this way we call subscribe by the client
        operators_1.map((data) => {
            this.tracks = data;
            //return true to say it did what we wanted it to do
            return true;
        }));
        //this should allow us to assign the tracks tp the track list
    }
    getNewVoteTotal(voteStatus, uri) {
        return this.http.post("api/Tracks/Vote", {
            vote: voteStatus,
            trackUri: uri
        }).pipe(operators_1.map((data) => {
            this.votes = data;
            return true;
        }));
    }
};
DataService.ctorParameters = () => [
    { type: http_1.HttpClient }
];
DataService = tslib_1.__decorate([
    core_1.Injectable()
], DataService);
exports.DataService = DataService;


/***/ }),

/***/ "./node_modules/raw-loader/dist/cjs.js!./ClientApp/app/app.component.html":
/*!********************************************************************************!*\
  !*** ./node_modules/raw-loader/dist/cjs.js!./ClientApp/app/app.component.html ***!
  \********************************************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("<div class=\"row\">\r\n    <div class=\"col-lg-12\">\r\n        <h3>{{  title  }}</h3>\r\n        <tracks></tracks>\r\n    </div>\r\n    \r\n</div>");

/***/ }),

/***/ "./node_modules/raw-loader/dist/cjs.js!./ClientApp/app/artists/artists.component.html":
/*!********************************************************************************************!*\
  !*** ./node_modules/raw-loader/dist/cjs.js!./ClientApp/app/artists/artists.component.html ***!
  \********************************************************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("<div class=\"row\">\r\n    <ul>\r\n        <li *ngFor=\"let a of artists\">{{  a.name  }}: {{ 1 + 1}}</li>\r\n    </ul>\r\n</div>");

/***/ }),

/***/ "./node_modules/raw-loader/dist/cjs.js!./ClientApp/app/tracks/trackCard.component.html":
/*!*********************************************************************************************!*\
  !*** ./node_modules/raw-loader/dist/cjs.js!./ClientApp/app/tracks/trackCard.component.html ***!
  \*********************************************************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("<div class=\"card bg-light m-1\">\r\n    <div class=\"m-1\">\r\n        <div class=\"divCounter\" [style.color]=\"totalVotes > 0 ? 'lightblue' : 'red'\">\r\n            {{ totalVotes }}\r\n        </div>\r\n        <div class=\"divNameContainer\">\r\n            <p>{{  this.track.name  }} by {{ this.artists }}</p>\r\n        </div>\r\n\r\n\r\n        <votes [upVotes]=\"this.track.upVotes\"\r\n               [downVotes]=\"this.track.downVotes\"\r\n               [uri]=\"this.track.uri\"\r\n               (newTotal)=\"getVoteTotal($event)\">\r\n        </votes>\r\n\r\n        <div class=\"m-1\" style=\"height:300px;\">\r\n            <iframe [src]=\"('https://open.spotify.com/embed/track/' + this.track.uri.substring(14)) | safe: 'resourceUrl'\" frameborder=\"0\" allowtransparency=\"true\" allow=\"encrypted-media\" height=\"300\"></iframe>\r\n        </div>\r\n    </div>\r\n\r\n\r\n</div>      ");

/***/ }),

/***/ "./node_modules/raw-loader/dist/cjs.js!./ClientApp/app/tracks/tracks.component.html":
/*!******************************************************************************************!*\
  !*** ./node_modules/raw-loader/dist/cjs.js!./ClientApp/app/tracks/tracks.component.html ***!
  \******************************************************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("<div class=\"row\">\r\n    <div class=\"col-lg-3 col-md-4  col-sm-6\" *ngFor=\"let t of tracks\">\r\n        <track-card [track]=\"t\"></track-card>\r\n    </div>\r\n</div>\r\n\r\n");

/***/ }),

/***/ "./node_modules/raw-loader/dist/cjs.js!./ClientApp/app/tracks/votes.component.html":
/*!*****************************************************************************************!*\
  !*** ./node_modules/raw-loader/dist/cjs.js!./ClientApp/app/tracks/votes.component.html ***!
  \*****************************************************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("<div class=\"card\">\r\n    <p><button id=\"btnUpVote\" class=\"success\" (click)=\"addVotes(uri)\"><i class=\"fa fa-arrow-up\"></i></button> {{ upVotes }}</p>\r\n    <p><button id=\"btnDownVote\" class=\"danger\" (click)=\"subtractVotes(uri)\"><i class=\"fa fa-arrow-down\"></i></button> {{ downVotes }}</p>\r\n</div>");

/***/ }),

/***/ "./node_modules/tslib/tslib.es6.js":
/*!*****************************************!*\
  !*** ./node_modules/tslib/tslib.es6.js ***!
  \*****************************************/
/*! exports provided: __extends, __assign, __rest, __decorate, __param, __metadata, __awaiter, __generator, __exportStar, __values, __read, __spread, __spreadArrays, __await, __asyncGenerator, __asyncDelegator, __asyncValues, __makeTemplateObject, __importStar, __importDefault, __classPrivateFieldGet, __classPrivateFieldSet */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "__extends", function() { return __extends; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "__assign", function() { return __assign; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "__rest", function() { return __rest; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "__decorate", function() { return __decorate; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "__param", function() { return __param; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "__metadata", function() { return __metadata; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "__awaiter", function() { return __awaiter; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "__generator", function() { return __generator; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "__exportStar", function() { return __exportStar; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "__values", function() { return __values; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "__read", function() { return __read; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "__spread", function() { return __spread; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "__spreadArrays", function() { return __spreadArrays; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "__await", function() { return __await; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "__asyncGenerator", function() { return __asyncGenerator; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "__asyncDelegator", function() { return __asyncDelegator; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "__asyncValues", function() { return __asyncValues; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "__makeTemplateObject", function() { return __makeTemplateObject; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "__importStar", function() { return __importStar; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "__importDefault", function() { return __importDefault; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "__classPrivateFieldGet", function() { return __classPrivateFieldGet; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "__classPrivateFieldSet", function() { return __classPrivateFieldSet; });
/*! *****************************************************************************
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the Apache License, Version 2.0 (the "License"); you may not use
this file except in compliance with the License. You may obtain a copy of the
License at http://www.apache.org/licenses/LICENSE-2.0

THIS CODE IS PROVIDED ON AN *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
MERCHANTABLITY OR NON-INFRINGEMENT.

See the Apache Version 2.0 License for specific language governing permissions
and limitations under the License.
***************************************************************************** */
/* global Reflect, Promise */

var extendStatics = function(d, b) {
    extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return extendStatics(d, b);
};

function __extends(d, b) {
    extendStatics(d, b);
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
}

var __assign = function() {
    __assign = Object.assign || function __assign(t) {
        for (var s, i = 1, n = arguments.length; i < n; i++) {
            s = arguments[i];
            for (var p in s) if (Object.prototype.hasOwnProperty.call(s, p)) t[p] = s[p];
        }
        return t;
    }
    return __assign.apply(this, arguments);
}

function __rest(s, e) {
    var t = {};
    for (var p in s) if (Object.prototype.hasOwnProperty.call(s, p) && e.indexOf(p) < 0)
        t[p] = s[p];
    if (s != null && typeof Object.getOwnPropertySymbols === "function")
        for (var i = 0, p = Object.getOwnPropertySymbols(s); i < p.length; i++) {
            if (e.indexOf(p[i]) < 0 && Object.prototype.propertyIsEnumerable.call(s, p[i]))
                t[p[i]] = s[p[i]];
        }
    return t;
}

function __decorate(decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
}

function __param(paramIndex, decorator) {
    return function (target, key) { decorator(target, key, paramIndex); }
}

function __metadata(metadataKey, metadataValue) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(metadataKey, metadataValue);
}

function __awaiter(thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
}

function __generator(thisArg, body) {
    var _ = { label: 0, sent: function() { if (t[0] & 1) throw t[1]; return t[1]; }, trys: [], ops: [] }, f, y, t, g;
    return g = { next: verb(0), "throw": verb(1), "return": verb(2) }, typeof Symbol === "function" && (g[Symbol.iterator] = function() { return this; }), g;
    function verb(n) { return function (v) { return step([n, v]); }; }
    function step(op) {
        if (f) throw new TypeError("Generator is already executing.");
        while (_) try {
            if (f = 1, y && (t = op[0] & 2 ? y["return"] : op[0] ? y["throw"] || ((t = y["return"]) && t.call(y), 0) : y.next) && !(t = t.call(y, op[1])).done) return t;
            if (y = 0, t) op = [op[0] & 2, t.value];
            switch (op[0]) {
                case 0: case 1: t = op; break;
                case 4: _.label++; return { value: op[1], done: false };
                case 5: _.label++; y = op[1]; op = [0]; continue;
                case 7: op = _.ops.pop(); _.trys.pop(); continue;
                default:
                    if (!(t = _.trys, t = t.length > 0 && t[t.length - 1]) && (op[0] === 6 || op[0] === 2)) { _ = 0; continue; }
                    if (op[0] === 3 && (!t || (op[1] > t[0] && op[1] < t[3]))) { _.label = op[1]; break; }
                    if (op[0] === 6 && _.label < t[1]) { _.label = t[1]; t = op; break; }
                    if (t && _.label < t[2]) { _.label = t[2]; _.ops.push(op); break; }
                    if (t[2]) _.ops.pop();
                    _.trys.pop(); continue;
            }
            op = body.call(thisArg, _);
        } catch (e) { op = [6, e]; y = 0; } finally { f = t = 0; }
        if (op[0] & 5) throw op[1]; return { value: op[0] ? op[1] : void 0, done: true };
    }
}

function __exportStar(m, exports) {
    for (var p in m) if (!exports.hasOwnProperty(p)) exports[p] = m[p];
}

function __values(o) {
    var s = typeof Symbol === "function" && Symbol.iterator, m = s && o[s], i = 0;
    if (m) return m.call(o);
    if (o && typeof o.length === "number") return {
        next: function () {
            if (o && i >= o.length) o = void 0;
            return { value: o && o[i++], done: !o };
        }
    };
    throw new TypeError(s ? "Object is not iterable." : "Symbol.iterator is not defined.");
}

function __read(o, n) {
    var m = typeof Symbol === "function" && o[Symbol.iterator];
    if (!m) return o;
    var i = m.call(o), r, ar = [], e;
    try {
        while ((n === void 0 || n-- > 0) && !(r = i.next()).done) ar.push(r.value);
    }
    catch (error) { e = { error: error }; }
    finally {
        try {
            if (r && !r.done && (m = i["return"])) m.call(i);
        }
        finally { if (e) throw e.error; }
    }
    return ar;
}

function __spread() {
    for (var ar = [], i = 0; i < arguments.length; i++)
        ar = ar.concat(__read(arguments[i]));
    return ar;
}

function __spreadArrays() {
    for (var s = 0, i = 0, il = arguments.length; i < il; i++) s += arguments[i].length;
    for (var r = Array(s), k = 0, i = 0; i < il; i++)
        for (var a = arguments[i], j = 0, jl = a.length; j < jl; j++, k++)
            r[k] = a[j];
    return r;
};

function __await(v) {
    return this instanceof __await ? (this.v = v, this) : new __await(v);
}

function __asyncGenerator(thisArg, _arguments, generator) {
    if (!Symbol.asyncIterator) throw new TypeError("Symbol.asyncIterator is not defined.");
    var g = generator.apply(thisArg, _arguments || []), i, q = [];
    return i = {}, verb("next"), verb("throw"), verb("return"), i[Symbol.asyncIterator] = function () { return this; }, i;
    function verb(n) { if (g[n]) i[n] = function (v) { return new Promise(function (a, b) { q.push([n, v, a, b]) > 1 || resume(n, v); }); }; }
    function resume(n, v) { try { step(g[n](v)); } catch (e) { settle(q[0][3], e); } }
    function step(r) { r.value instanceof __await ? Promise.resolve(r.value.v).then(fulfill, reject) : settle(q[0][2], r); }
    function fulfill(value) { resume("next", value); }
    function reject(value) { resume("throw", value); }
    function settle(f, v) { if (f(v), q.shift(), q.length) resume(q[0][0], q[0][1]); }
}

function __asyncDelegator(o) {
    var i, p;
    return i = {}, verb("next"), verb("throw", function (e) { throw e; }), verb("return"), i[Symbol.iterator] = function () { return this; }, i;
    function verb(n, f) { i[n] = o[n] ? function (v) { return (p = !p) ? { value: __await(o[n](v)), done: n === "return" } : f ? f(v) : v; } : f; }
}

function __asyncValues(o) {
    if (!Symbol.asyncIterator) throw new TypeError("Symbol.asyncIterator is not defined.");
    var m = o[Symbol.asyncIterator], i;
    return m ? m.call(o) : (o = typeof __values === "function" ? __values(o) : o[Symbol.iterator](), i = {}, verb("next"), verb("throw"), verb("return"), i[Symbol.asyncIterator] = function () { return this; }, i);
    function verb(n) { i[n] = o[n] && function (v) { return new Promise(function (resolve, reject) { v = o[n](v), settle(resolve, reject, v.done, v.value); }); }; }
    function settle(resolve, reject, d, v) { Promise.resolve(v).then(function(v) { resolve({ value: v, done: d }); }, reject); }
}

function __makeTemplateObject(cooked, raw) {
    if (Object.defineProperty) { Object.defineProperty(cooked, "raw", { value: raw }); } else { cooked.raw = raw; }
    return cooked;
};

function __importStar(mod) {
    if (mod && mod.__esModule) return mod;
    var result = {};
    if (mod != null) for (var k in mod) if (Object.hasOwnProperty.call(mod, k)) result[k] = mod[k];
    result.default = mod;
    return result;
}

function __importDefault(mod) {
    return (mod && mod.__esModule) ? mod : { default: mod };
}

function __classPrivateFieldGet(receiver, privateMap) {
    if (!privateMap.has(receiver)) {
        throw new TypeError("attempted to get private field on non-instance");
    }
    return privateMap.get(receiver);
}

function __classPrivateFieldSet(receiver, privateMap, value) {
    if (!privateMap.has(receiver)) {
        throw new TypeError("attempted to set private field on non-instance");
    }
    privateMap.set(receiver, value);
    return value;
}


/***/ }),

/***/ 0:
/*!*********************************!*\
  !*** multi ./ClientApp/main.ts ***!
  \*********************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

module.exports = __webpack_require__(/*! C:\Users\lritter\Desktop\youShouldCheckOutThisBand\youShouldCheckOutThisBand\ClientApp\main.ts */"./ClientApp/main.ts");


/***/ })

},[[0,"runtime","vendor"]]]);
//# sourceMappingURL=main.js.map