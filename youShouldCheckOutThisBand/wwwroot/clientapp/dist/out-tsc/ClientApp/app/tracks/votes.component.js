import { __decorate } from "tslib";
import { Component, Input } from '@angular/core';
//import { DataService } from '../../shared/data/dataService';
//import track interface so we can use it
//import { Track } from '../../shared/track';
//import { Artist } from '../../shared/artist';
let Votes = class Votes {
    constructor(data) {
        this.data = data;
    }
    ngOnInit() {
    }
    subtractVotes() {
        this.downVotes -= 1;
        //return downVotes;
    }
    addVotes() {
        this.upVotes += 1;
        //return downVotes;
    }
};
__decorate([
    Input()
], Votes.prototype, "upVotes", void 0);
__decorate([
    Input()
], Votes.prototype, "downVotes", void 0);
__decorate([
    Input()
], Votes.prototype, "uri", void 0);
Votes = __decorate([
    Component({
        selector: "votes",
        templateUrl: "votes.component.html",
        styleUrls: ["votes.component.scss"]
    })
], Votes);
export { Votes };
//# sourceMappingURL=votes.component.js.map