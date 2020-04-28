import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
//see documentation on safe pipe here: https://www.npmjs.com/package/safe-pipe
import { SafePipeModule } from 'safe-pipe';
import { ArtistList } from './artists/artists.component';
import { TrackList } from './tracks/tracks.component';
import { Votes } from './tracks/votes.component';
import { AppComponent } from './app.component';
import { DataService } from '../shared/data/dataService';
//support using http client module to make api requests
import { HttpClientModule } from "@angular/common/http";
//the purpose of angular is basically dependency inejction for your site
//so that's what a lot of this stuff pertains to
@NgModule({
  declarations: [
        AppComponent,
        ArtistList,
        TrackList,
        Votes
  ],
  imports: [
      BrowserModule,
      HttpClientModule,
      SafePipeModule
  ],
    providers: [
        //add data service here for dependency injection
        DataService
    ],
  bootstrap: [AppComponent]
})
export class AppModule { }
