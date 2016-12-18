using System;
using System.Collections.Generic;
using MusicStore.Logic.Common;
using MusicStore.Logic.DTOs.Album;

namespace MusicStore.Logic.Artists
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
            var album = new Album(dto.Name, this, dto.Year);
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
    }
}