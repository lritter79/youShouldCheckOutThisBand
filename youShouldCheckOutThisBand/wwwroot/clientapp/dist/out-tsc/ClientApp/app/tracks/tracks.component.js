import { __decorate } from "tslib";
import { Component } from '@angular/core';
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
    //public totalVotes: number;
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
    getColor(totalVotes) {
        if (totalVotes > 0) {
            return "blue;";
        }
        else if (totalVotes < 0) {
            return "red";
        }
    }
    getArtistNames(track) {
        let returnString = "";
        if (track.artists.length > 1) {
            track.artists.forEach(function (artist) {
                if (artist.uri == track.artists[track.artists.length - 2].uri) {
                    returnString += artist.name + ", and ";
                }
                else if (artist.uri == track.artists[track.artists.length - 1].uri) {
                    returnString += artist.name;
                }
                else {
                    returnString += artist.name + ", ";
                }
            });
        }
        else {
            returnString = track.artists[0].name;
        }
        return returnString;
    }
};
TrackList = __decorate([
    Component({
        selector: "tracks",
        templateUrl: "./tracks.component.html",
        styleUrls: ["./tracks.component.css"]
    })
    //interface that says once you're ready, call a method
], TrackList);
export { TrackList };
//# sourceMappingURL=tracks.component.js.map