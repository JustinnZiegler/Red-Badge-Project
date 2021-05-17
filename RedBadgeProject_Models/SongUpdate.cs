﻿using RedBadgeProject_Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeProject_Models
{
    public class SongUpdate
    {
        public int SongId { get; set; }

        [MaxLength(100, ErrorMessage = "Title is too long. Please shorten that shit down.")]
        public string Title { get; set; }

        public int ArtistId { get; set; }

        public int GenreId { get; set; }

        public int AlbumId { get; set; }

        public DateTime Date { get; set; }
    }
}