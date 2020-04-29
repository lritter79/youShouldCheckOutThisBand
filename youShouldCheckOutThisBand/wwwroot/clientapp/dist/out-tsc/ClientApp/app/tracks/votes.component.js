import { __decorate } from "tslib";
import { Component, Input, Output, EventEmitter } from '@angular/core';
//import { DataService } from '../../shared/data/dataService';
//import track interface so we can use it
//import { Track } from '../../shared/track';
//import { Artist } from '../../shared/artist';
let Votes = class Votes {
    constructor(data) {
        this.data = data;
        this.newTotal = new EventEmitter();
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
__decorate([
    Input()
], Votes.prototype, "upVotes", void 0);
__decorate([
    Input()
], Votes.prototype, "downVotes", void 0);
__decorate([
    Input()
], Votes.prototype, "uri", void 0);
__decorate([
    Output()
], Votes.prototype, "newTotal", void 0);
Votes = __decorate([
    Component({
        selector: "votes",
        templateUrl: "votes.component.html",
        styleUrls: ["votes.component.scss"]
    })
], Votes);
export { Votes };
//# sourceMappingURL=votes.component.js.map