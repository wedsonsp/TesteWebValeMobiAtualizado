using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD.Models
{
    public static class HorarioDeBrasilia
    {
        private static readonly TimeZoneInfo TimeZoneBrasilia;

        static HorarioDeBrasilia()
        {
            try
            {
                TimeZoneBrasilia = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
            }
            catch
            {
            }
        }

        public static DateTime Hoje
        {
            get
            {
                DateTime utcNow = DateTime.UtcNow;
                try
                {
                    return TimeZoneInfo.ConvertTimeFromUtc(utcNow, TimeZoneBrasilia).Date;
                }
                catch
                {
                    return utcNow.Date;
                }
            }
        }

        public static DateTime Agora
        {
            get
            {
                DateTime utcNow = DateTime.UtcNow;
                try
                {
                    return TimeZoneInfo.ConvertTimeFromUtc(utcNow, TimeZoneBrasilia);
                }
                catch
                {
                    return utcNow;
                }
            }
        }
    }
}