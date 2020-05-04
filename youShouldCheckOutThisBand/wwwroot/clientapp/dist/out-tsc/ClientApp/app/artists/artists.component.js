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
            if (a.images.find(image => (image.width > 199 && image.width < 401)).url != null) {
                return a.images.find(image => (image.width > 199 && image.width < 401)).url;
            }
            else {
                return (a.images.find(image => image.width > 199).url != null) ? a.images.find(image => image.width > 199).url : "";
            }
        }
        else if (a.images.length > 1) {
            return a.images[0].url;
        }
        else {
            return "";
        }
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