using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace youShouldCheckOutThisBand.Models
{
    [NotMapped]
    public class Image
    {
        public int Id { get; set; }

        /// <summary>
        /// The image height in pixels. If unknown: null or not returned.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// The image width in pixels. If unknown: null or not returned.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// 	The source URL of the image.
        /// </summary>
        public string Url { get; set; }

    }
}
