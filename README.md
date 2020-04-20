The goal of this app is two fold: 
  1. A user should be able to search for a band, and get a list of recommended songs by that artist, organized by album.
  2. A user hould be able to add recommendations for songs to check out by a particular artist
  
  
  To do list:
    1. Create dummy data to seed the db for developing.
    2. Implement the Spotify API
    3. Create Views
      A. A Home View with a search menu for goal 1
        1. Should include search results too
      B. An add recommendation view for goal number 2
        1. Let's you search for the band by name
        2. Choose the band, add the uri of the chosen song, and submit
      C. A Band View that has the band on it and a list of recommended sons that users can vote on to decide if they're good places to start
        1. Song list should be displayed in order of popularity
        2. If a song gets -10 votes, it gets deleted as a recommendation
        3. Each song should come with a webplayer
    4. Use the Rovi API to get bios of the artists: http://prod-doc.rovicorp.com/mashery/index.php/Data/name-api/v1.1/name/music-bio
    5. Styling, possibly using angular or react for components
