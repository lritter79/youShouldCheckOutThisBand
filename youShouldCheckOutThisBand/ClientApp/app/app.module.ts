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
let routes = [
    //{ path: "/tracks", component: Tracks },
    //{ path: "/artists", component: Artists }
];

//the purpose of angular is basically dependency inejction for your site
//so that's what a lot of this stuff pertains to
//"use hash" makes it so that the path is after a # in the url
@NgModule({
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

  ],
    providers: [
        //add data service here for dependency injection
        DataService
    ],
  bootstrap: [AppComponent]
})
export class AppModule { }
//RouterModule.forRoot(routes, {
//    useHash: true,
//    enableTracing: false //for debugging
//})