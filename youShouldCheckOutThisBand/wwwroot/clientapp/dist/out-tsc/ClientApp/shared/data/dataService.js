import { __decorate } from "tslib";
import { map } from "rxjs/operators";
import { Injectable } from "@angular/core";
//we have to decorate to tell the dependency injection serivce that it's part of the chain of injection
//this part is for if it requires other dependencies
let DataService = class DataService {
    constructor(http) {
        this.http = http;
        //add interface for type safety
        this.tracks = [];
    }
    loadTracks() {
        //use http to get our api
        return this.http.get("/api/Tracks")
            // subscribe() says when this is done i want to know the response
            // and kicks of the beginning of this request
            //.subscribe()
            //what we want to do is intercept the call and change the data
            .pipe(
        //this way we call subscribe by the client
        map((data) => {
            this.tracks = data;
            //return true to say it did what we wanted it to do
            return true;
        }));
        //this should allow us to assign the tracks tp the track list
    }
};
DataService = __decorate([
    Injectable()
], DataService);
export { DataService };
//# sourceMappingURL=dataService.js.map