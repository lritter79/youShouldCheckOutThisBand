import { __decorate } from "tslib";
import { Component } from '@angular/core';
//import { DataService } from '../../shared/data/dataService';
//import track interface so we can use it
//import { Track } from '../../shared/track';
//import { Artist } from '../../shared/artist';
let Votes = class Votes {
    constructor(data) {
        this.data = data;
        this.upVotes = 0;
        this.downVotes = 0;
    }
    ngOnInit() {
    }
};
Votes = __decorate([
    Component({
        selector: "votes",
        templateUrl: "votes.component.html",
        styleUrls: ["votes.component.scss"]
    })
], Votes);
export { Votes };
//# sourceMappingURL=votes.component.js.map