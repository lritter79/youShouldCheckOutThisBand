import { __decorate } from "tslib";
import { Component } from '@angular/core';
let TrackList = 
//interface that says once you're ready, call a method
class TrackList {
    //private makes private member of the class
    //injects it into track list
    constructor(data) {
        this.data = data;
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
TrackList = __decorate([
    Component({
        selector: "tracks",
        templateUrl: "./tracks.component.html",
        styleUrls: []
    })
    //interface that says once you're ready, call a method
], TrackList);
export { TrackList };
//# sourceMappingURL=tracks.component.js.map