﻿using System;
using System.Collections.Generic;
using MusicStore.Logic.Common;
using MusicStore.Logic.DTOs.Track;

namespace MusicStore.Logic.Artists
{
    public class Album : Entity
    {
        public virtual string Name { get; protected set; }

        public virtual Artist Artist { get; protected set; }

        public virtual int? Year { get; protected set; }

        private readonly ICollection<Track> _tracks; 
        public virtual IEnumerable<Track> Tracks => _tracks;

        protected Album()
        {
        }

        public Album(string name, Artist artist, int? year)
        {
            if (string.IsNullOrEmpty(name))
                throw new InvalidOperationException();
            if (artist == null)
                throw new InvalidOperationException();

            Name = name;
            Artist = artist;
            Year = year;
            _tracks = new List<Track>();
        }

        public virtual void AddTracks(IEnumerable<AddTrackDTO> tracks)
        {
            foreach (var track in tracks)
            {
                _tracks.Add(new Track(track.Number, track.Name, this, track.Duration));
            }
        }
    }
}
