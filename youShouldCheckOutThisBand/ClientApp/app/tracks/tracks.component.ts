import { Component } from '@angular/core';




@Component({
    selector: "tracks",
    templateUrl: "./tracks.component.html",
    styleUrls: []
})
export class TrackList {
    tracks = [{
        name: "Fi",
        uri: "6aLfFqIT2dFbLOziB2WjZC",
        upVotes: "",
        downVotes: ""
    }, {
        name: "Fio",
        uri: "0yYJiI2DrKydyA0U68SM7H",
        upVotes: "",
        downVotes: ""
    }];
}