import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { ArtistList } from './artists/artists.component';
import { AppComponent } from './app.component';

@NgModule({
  declarations: [
        AppComponent,
        ArtistList
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
