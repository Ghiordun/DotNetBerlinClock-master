using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BerlinClock
{
    public interface ITimeConverter
    {
        StringBuilder ConvertTime(string aTime);
        StringBuilder ConvertHours(short hours);
        StringBuilder ConvertMinutes(short minutes);
        StringBuilder ConvertSeconds(short seconds);
    }
}
