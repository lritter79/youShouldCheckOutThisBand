import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { SafePipeModule } from 'safe-pipe';
import { ArtistList } from './artists/artists.component';
import { TrackList } from './tracks/tracks.component';
import { AppComponent } from './app.component';

@NgModule({
  declarations: [
        AppComponent,
        ArtistList,
        TrackList
  ],
  imports: [
      BrowserModule,
      SafePipeModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
