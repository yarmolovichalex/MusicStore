using System;
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
            return new Artist("Metallica", "USA");
        }

        private Album GetFakeAlbum()
        {
            return new Album("Metallica", GetFakeArtist(), 1991, null);
        }

        [Fact]
        public void Cant_create_artist_without_name()
        {
            Action action = () => new Artist(string.Empty, "USA");

            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void Cant_create_album_without_name()
        {
            Action action =() => new Album(string.Empty, GetFakeArtist(), 1991, null);

            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void Cant_create_album_without_artist()
        {
            Action action = () => new Album("Master of Puppets", null, 1991, null);

            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void Cant_create_track_without_number()
        {
            Action action = () => new Track(0, "Enter Sandman", GetFakeAlbum(), TimeSpan.FromMinutes(5));

            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void Cant_create_track_without_name()
        {
            Action action = () => new Track(1, string.Empty, GetFakeAlbum(), TimeSpan.FromMinutes(5) );

            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void Cant_create_track_without_album()
        {
            Action action = () => new Track(1, "Enter Sandman", null, TimeSpan.FromMinutes(5));

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
