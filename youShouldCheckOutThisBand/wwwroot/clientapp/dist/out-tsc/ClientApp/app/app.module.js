import { __decorate } from "tslib";
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
//see documentation on safe pipe here: https://www.npmjs.com/package/safe-pipe
import { SafePipeModule } from 'safe-pipe';
import { ArtistList } from './artists/artists.component';
import { TrackList } from './tracks/tracks.component';
import { TrackCard } from './tracks/trackCard.component';
import { Votes } from './tracks/votes.component';
import { AppComponent } from './app.component';
import { DataService } from '../shared/data/dataService';
//support using http client module to make api requests
import { HttpClientModule } from "@angular/common/http";
//support routing
import { RouterModule } from "@angular/router";
//we need a collection of routes like our mvc routes that form paths 
//and a component thats like a view that says "if you math this path, show this componenent"
//angular assumes slashes are in the path name, so for path you dont have to add a slash
//so "/tracks" == "tracks"
//path: '**' is a wildcard route. The Angular router selects this route any time the requested URL doesn't match any router paths
//path: '' is the default route.
//the redirect route that translates the initial relative URL ('') to the desired default path (/tracks).
//A redirect route requires a pathMatch property to tell the router how to match a URL to the path of a route. In this app, the router should select the route to the HeroListComponent only when the entire URL matches '', so set the pathMatch value to 'full'.
let routes = [
    { path: "tracks", component: TrackList },
    { path: "artists", component: ArtistList },
    { path: '', redirectTo: '/tracks', pathMatch: 'full' },
    { path: '**', component: TrackList }
];
//the purpose of angular is basically dependency inejction for your site
//so that's what a lot of this stuff pertains to
//"use hash" makes it so that the path is after a # in the url
let AppModule = class AppModule {
};
AppModule = __decorate([
    NgModule({
        declarations: [
            AppComponent,
            ArtistList,
            TrackList,
            TrackCard,
            Votes
        ],
        imports: [
            BrowserModule,
            HttpClientModule,
            SafePipeModule,
            RouterModule.forRoot(routes, {
                useHash: true,
                enableTracing: false //for debugging
            })
        ],
        providers: [
            //add data service here for dependency injection
            DataService
        ],
        bootstrap: [AppComponent]
    })
], AppModule);
export { AppModule };
//# sourceMappingURL=app.module.js.map