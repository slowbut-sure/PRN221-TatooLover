﻿using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IBookingRepository
    {
        public List<Booking> GetBookings();
        public List<Booking> GetBookingToday(int studioID);
        public List<Booking> GetBookingByStudioId(int studioId);
        public Booking? GetBookingById(int bookingID);
        public List<Booking> GetDay(DateTime date);
    }
}