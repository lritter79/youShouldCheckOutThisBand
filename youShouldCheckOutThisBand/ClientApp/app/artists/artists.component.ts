import { Component } from '@angular/core';

@Component({
    selector: "artists",
    templateUrl: "./artists.component.html",
    styleUrls: []
})
export class ArtistList {
    artists = [{
        name: "Fi"
    },{
        name: "Fio"
    }];
}