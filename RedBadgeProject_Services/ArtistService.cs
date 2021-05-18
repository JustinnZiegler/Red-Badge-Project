using RedBadgeProject_Data;
using RedBadgeProject_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace RedBadgeProject_Services
{
    public class ArtistService
    {
        public bool CreateArtist(ArtistCreate model)
        {
            var entity =
                new Artist()
                {
                    ArtistName = model.ArtistName,
                    Birthdate = model.Birthdate
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Artists.Add(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ArtistList> GetAllArtists()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Artists.Select(e => new ArtistList
                {
                    ArtistId = e.ArtistId,
                    ArtistName = e.ArtistName
                });

                return query.ToArray();
            }
        }

        public ArtistDetail GetArtistByArtistId(int artistId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Artists.Include(e => e.SongsByArtist).Single(e => artistId == e.ArtistId);

                var namesOfSongs = new List<string>();

                foreach (var song in entity.SongsByArtist)
                {
                    namesOfSongs.Add(song.Title);
                }

                return new ArtistDetail()
                {
                    ArtistId = entity.ArtistId,
                    ArtistName = entity.ArtistName,
                    Birthdate = entity.Birthdate.ToShortDateString(),
                    NamesOfSongsByArtist = namesOfSongs
                };
            }
        }

        public ArtistDetail GetArtistByArtistName(string artistName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Artists.Include(e => e.SongsByArtist).Single(e => artistName == e.ArtistName);

                var namesOfSongs = new List<string>();

                foreach (var song in entity.SongsByArtist)
                {
                    namesOfSongs.Add(song.Title);
                }

                return new ArtistDetail()
                {
                    ArtistId = entity.ArtistId,
                    ArtistName = entity.ArtistName,
                    Birthdate = entity.Birthdate.ToShortDateString(),
                    NamesOfSongsByArtist = namesOfSongs
                };
            }
        }

        public bool UpdateArtist(ArtistUpdate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Artists.Single(e => e.ArtistId == model.ArtistId);

                entity.ArtistName = model.ArtistName;
                entity.Birthdate = model.Birthdate;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteArtist(int artistId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Artists.Single(e => e.ArtistId == artistId);

                ctx.Artists.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
