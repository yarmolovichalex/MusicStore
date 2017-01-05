using System;
using System.Collections.Generic;
using MusicStore.Logic.DTO.Album;
using MusicStore.Logic.Model.Common;

namespace MusicStore.Logic.Model.Artist
{
    public class Artist : Entity
    {
        public virtual string Name { get; protected set; }

        public virtual string Country { get; protected set; }


        private readonly ICollection<Album> _albums;
        public virtual IEnumerable<Album> Albums => _albums;

        protected Artist()
        {
        }

        public Artist(string name, string country) : this()
        {
            if (string.IsNullOrEmpty(name))
                throw new InvalidOperationException();

            Name = name;
            Country = country;
            _albums = new List<Album>();
        }

        public virtual void AddAlbum(AddAlbumDTO dto)
        {
            var album = new Album(dto.Name, this, dto.Year, dto.CoverUrl);
            if (dto.Tracks != null)
            {
                album.AddTracks(dto.Tracks);
            }

            _albums.Add(album);
        }

        public virtual void AddAlbums(IEnumerable<AddAlbumDTO> albums)
        {
            foreach (var album in albums)
            {
                AddAlbum(album);
            }
        }

        public virtual void UpdateInfo(string name, string country)
        {
            if (string.IsNullOrEmpty(name))
                throw new InvalidOperationException(); // todo move validations to separate method

            Name = name;
            Country = country;
        }
    }
}