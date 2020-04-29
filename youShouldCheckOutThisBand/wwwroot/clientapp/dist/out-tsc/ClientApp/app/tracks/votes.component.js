import { __decorate } from "tslib";
import { Component, Input, Output, EventEmitter } from '@angular/core';
let Votes = class Votes {
    constructor(data) {
        this.data = data;
        this.voteEvent = new EventEmitter();
    }
    ngOnInit() {
        this.voteEvent.emit(this.upVotes - this.downVotes);
        this.upClicked = false;
        this.downClicked = false;
    }
    subtractVotes(uri) {
        this.downVotes += 1;
        if (this.upClicked) {
            this.upVotes--;
        }
        this.changeVotesInRepo(false, uri);
        this.voteEvent.emit(this.upVotes - this.downVotes);
        //return downVotes;
    }
    addVotes(uri) {
        this.upVotes += 1;
        if (this.downClicked) {
            this.downVotes--;
        }
        this.changeVotesInRepo(true, uri);
        this.voteEvent.emit(this.upVotes - this.downVotes);
    }
    changeVotesInRepo(vote, trackUri) {
        let newTotal = this.data.getNewVoteTotal(vote, trackUri)
            .subscribe(success => {
            if (success) {
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
], Votes.prototype, "voteEvent", void 0);
Votes = __decorate([
    Component({
        selector: "votes",
        templateUrl: "votes.component.html",
        styleUrls: ["votes.component.scss"]
    })
], Votes);
export { Votes };
//# sourceMappingURL=votes.component.js.map