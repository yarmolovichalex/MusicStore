using System;
using System.Collections.Generic;
using FluentAssertions;
using MusicStore.Logic.Artists;
using MusicStore.Logic.SharedKernel;
using Xunit;

namespace MusicStore.Tests
{
    public class ArtistSpecs
    {
        private Artist GetFakeArtist()
        {
            return new Artist("Metallica", "USA", new List<Album> { null });
        }

        private Album GetFakeAlbum()
        {
            return new Album("Metallica", GetFakeArtist(), 1991, GetFakeTrackList(), null);
        }

        private List<Track> GetFakeTrackList()
        {
            return new List<Track> { null };
        }

        private List<Album> GetFakeAlbumList()
        {
            return new List<Album> { null };
        }

        [Fact]
        public void Cant_create_artist_without_name()
        {
            Action action = () => new Artist(string.Empty, "USA", GetFakeAlbumList());

            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void Cant_create_artist_without_country()
        {
            Action action = () => new Artist("Metallica", string.Empty, GetFakeAlbumList());

            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void Cant_create_artist_without_albums()
        {
            Action action = () => new Artist("Metallica", "USA", null);

            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void Cant_create_artist_with_zero_albums()
        {
            Action action = () => new Artist("Metallica", "USA", new List<Album>());

            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void Cant_create_album_without_name()
        {
            Action action =() => new Album(string.Empty, GetFakeArtist(), 1991, GetFakeTrackList(), null);

            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void Cant_create_album_without_artist()
        {
            Action action = () => new Album("Master of Puppets", null, 1991, GetFakeTrackList(), null);

            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void Cant_create_album_with_wrong_year()
        {
            Action action = () => new Album("Master of Puppets", GetFakeArtist(), 200, GetFakeTrackList(), null);

            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void Cant_create_album_without_tracklist()
        {
            Action action =() => new Album("Master of Puppets", GetFakeArtist(), 200, null, null);

            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void Cant_create_album_with_zero_tracks()
        {
            Action action =() => new Album("Master of Puppets", GetFakeArtist(), 200, new List<Track>(), null);

            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void Cant_create_track_without_name()
        {
            Action action = () => new Track(string.Empty, GetFakeAlbum(), TimeSpan.FromMinutes(5) );

            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void Cant_create_track_without_album()
        {
            Action action = () => new Track("Enter Sandman", null, TimeSpan.FromMinutes(5));

            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void Cant_create_money_with_negative_amount()
        {
            Action action = () => new Money(-10.0m, "USD");

            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void Cant_create_money_without_currency()
        {
            Action action = () => new Money(10.0m, string.Empty);

            action.ShouldThrow<InvalidOperationException>();
        }
    }
}
