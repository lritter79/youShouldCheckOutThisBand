import { __decorate } from "tslib";
import { Component } from '@angular/core';
let ArtistList = class ArtistList {
    constructor(data) {
        //this.artists = data.artists;
        this.data = data;
        this.artists = [];
    }
    ngOnInit() {
        this.data.loadArtists()
            //calls success because the shared component returns a bool
            .subscribe(success => {
            if (success) {
                this.artists = this.data.artists;
            }
        });
    }
    getImageUrl(a) {
        if (a.images.length > 1) {
            return a.images.find(image => image.height < 300).url;
        }
        else if (a.images.length > 1) {
            return a.images[0].url;
        }
        return "";
    }
};
ArtistList = __decorate([
    Component({
        selector: "artists",
        templateUrl: "./artists.component.html",
        styleUrls: ["./artists.component.scss"]
    })
], ArtistList);
export { ArtistList };
//# sourceMappingURL=artists.component.js.map