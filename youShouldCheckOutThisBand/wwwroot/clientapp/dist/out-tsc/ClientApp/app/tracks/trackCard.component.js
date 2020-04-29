import { __decorate } from "tslib";
import { Component, Input } from '@angular/core';
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
__decorate([
    Input()
], TrackCard.prototype, "track", void 0);
TrackCard = __decorate([
    Component({
        selector: "track-card",
        templateUrl: "./trackCard.component.html",
        styleUrls: ["./trackCard.component.scss"]
    })
    //interface that says once you're ready, call a method
], TrackCard);
export { TrackCard };
//# sourceMappingURL=trackCard.component.js.map