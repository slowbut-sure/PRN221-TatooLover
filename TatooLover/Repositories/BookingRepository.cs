﻿using BusinessObjects.Models;
using DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class BookingRepository : IBookingRepository
    {
        BookingDAO bookingDAO = new BookingDAO();
        ArtistDAO artistDAO = new ArtistDAO();

        public Booking? GetBookingById(int bookingID) => bookingDAO.GetBookings().FirstOrDefault(a => a.BookingId == bookingID);

        public List<Booking> GetBookingByStudioId(int studioId)
        {
            var artists = artistDAO.GetArtistByStudioId(studioId);

            return bookingDAO.GetBookings()
              .Where(b => artists.Contains(b.Artist))
              .ToList();
        }

        public List<Booking> GetBookings() => bookingDAO.GetBookings().OrderByDescending(b => b.BookingDate).ToList();

        public List<Booking> GetBookingToday(int studioID)
        {
            List<Booking> bookingList = new List<Booking>();
            List<Artist> artistList = artistDAO.GetArtistByStudioId(studioID);

            return bookingDAO.GetBookings()
                .Where(b => artistList.Contains(b.Artist) && b.BookingDate == DateTime.Today)
                .ToList();
        }

        public List<Booking> GetDay(DateTime date) => bookingDAO.GetDay(date);
    }
}