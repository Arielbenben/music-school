using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeFunc.Congiguration
{
    internal static class MusicSchollConfiguration
    {
        public static string musicSchoolPath = Path.Combine(
            Directory.GetCurrentDirectory(), "musicschool.xml");
    }
}
