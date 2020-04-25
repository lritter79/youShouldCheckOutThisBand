using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace youShouldCheckOutThisBand.Models
{
    public abstract class BaseAlbum
    {

        /// <summary>
        /// The type of the album: one of "album" , "single" , or "compilation".
        /// </summary>
        public string AlbumType { get; set; }


        /// <summary>
        /// A link to the Web API endpoint providing full details of the album.
        /// </summary>
        public string Href { get; set; }

        /// <summary>
        /// The label for the album.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// The name of the album. In case of an album takedown, the value may be an empty string.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The date the album was first released, for example "1981-12-15". Depending on the precision, it might be shown as "1981" or "1981-12".
        /// </summary>
        public string Release_Date { get; set; }

        /// <summary>
        /// The precision with which release_date value is known: "year" , "month" , or "day".
        /// </summary>
        public string Release_Date_Precision { get; set; }

        /// <summary>
        /// The Spotify URI for the album.
        /// </summary>
        public string Uri { get; set; }
    }
}
