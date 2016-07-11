﻿using System;

namespace MusicStore.Logic.Artists
{
    public class Track
    {
        public virtual string Name { get; protected set; }

        public virtual Album Album { get; protected set; }

        public virtual TimeSpan Duration { get; protected set; }

        protected Track()
        {
        }

        public Track(string name, Album album, TimeSpan duration)
        {
            Name = name;
            Album = album;
            Duration = duration;
        }
    }
}
