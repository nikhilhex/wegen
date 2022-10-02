using System;
using System.Net;
using System.Text.RegularExpressions;
using System.Globalization;

namespace wegen
{

#pragma warning disable SYSLIB0014

   public  static class WeGen
    {
        public static int Number()
        {
            Random rng = new Random();
            return rng.Next();
        }
        public static int Number(int min, int max)
        {
            Random rng = new Random();
            return rng.Next(min, max + 1);
        }
        // WebClient is depracated. I've found a working fix although it would take a little more work to implement it into this project since HttpClient was intended for async use. If you would like to contribute to this, find the issue I put on GitHub and we can discuss a fix. As you see I've suppressed the warning but fixing this issue is one of the biggest implements for this project.

        public static string Word()
        {
            WebClient client = new WebClient();
            string reply = client.DownloadString("http://random-word-api.herokuapp.com/word");
            reply = Regex.Replace(reply, @"[\[\]\""]", "");
            return reply;
        }

        public static string Word(bool capital)
        {
            WebClient client = new WebClient();
            string reply = client.DownloadString("http://random-word-api.herokuapp.com/word");
            reply = Regex.Replace(reply, @"[\[\]\""]", "");
            if (capital)
            {
                return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(reply.ToLower());
            }
            else
            {
                return reply;
            }
        }

        public static DateTime Date()
        {
            Random rand = new Random();
            DateTime startPoint = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - startPoint).Days;
            return startPoint.AddDays(rand.Next(range)).Date;
        }

        public static string Time()
        {
            Random r = new Random();
            return r.Next(0, 2) + r.Next(0, 10) + ":" + r.Next(1, 6) + r.Next(1, 10);
        }

        public static string Time(bool ampm)
        {
            Random r = new Random();
            string timeOfDay = "";
            if (ampm)
            {
                if (r.Next(1, 3) == 2)
                {
                    timeOfDay = "AM";
                }
                else
                {
                    timeOfDay = "PM";
                }
            }
            return r.Next(0, 2) + r.Next(0, 10) + ":" + r.Next(1, 6) + r.Next(1, 10) + " " + timeOfDay;
        }

        public static string TwentyFourHourTime()
        {
            Random r = new Random();
            return r.Next(0, 3) + r.Next(0, 10) + ":" + r.Next(1, 6) + r.Next(1, 10);
        }

    }

    public static class WeLog
    {
        public static void Number()
        {
            Random rng = new Random();
            Console.WriteLine(rng.Next());
        }
        public static void Number(int min, int max)
        {
            Random rng = new Random();
            Console.WriteLine(rng.Next(min, max + 1));
        }
        public static void Word()
        {
            WebClient client = new WebClient();
            string reply = client.DownloadString("http://random-word-api.herokuapp.com/word");
            reply = Regex.Replace(reply, @"[\[\]\""]", "");
            Console.WriteLine(reply);
        }
        public static void Word(bool capital)
        {
            WebClient client = new WebClient();
            string reply = client.DownloadString("http://random-word-api.herokuapp.com/word");
            reply = Regex.Replace(reply, @"[\[\]\""]", "");
            if (capital)
            {
                Console.WriteLine(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(reply.ToLower()));
            }
            else
            {
                Console.WriteLine(reply);
            }

        }

        public static void Date()
        {
            Random rng = new Random();
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            Console.WriteLine(start.AddDays(rng.Next(range)).Date.ToString("MM/dd/yyyy"));
        }
        public static void Time()
        {
            Random r = new Random();
            Console.WriteLine(r.Next(0, 2) + r.Next(0, 10) + ":" + r.Next(1, 6) + r.Next(1, 10));
        }
        public static void Time(bool ampm)
        {
            Random r = new Random();
            string timeOfDay = "";
            if (ampm)
            {
                if (r.Next(1, 3) == 2)
                {
                    timeOfDay = "AM";
                }
                else
                {
                    timeOfDay = "PM";
                }
            }
            Console.WriteLine(r.Next(0, 2) + r.Next(0, 10) + ":" + r.Next(1, 6) + r.Next(1, 10) + " " + timeOfDay);
        }

        public static void TwentyFourHourTime()
        {
            Random r = new Random();
            Console.WriteLine(r.Next(0, 3) + r.Next(0, 10) + ":" + r.Next(1, 6) + r.Next(1, 10));
        }

        public static void DebugGenerator()
        {
            for (int i = 0; i < 10; i++)
            {
                Time();
            }
            for (int i = 0; i < 10; i++)
            {
                TwentyFourHourTime();
            }
            for (int i = 0; i < 10; i++)
            {
                Date();
            }
            for (int i = 0; i < 5; i++)
            {
                Word();
            }
            for (int i = 0; i < 5; i++)
            {
                Word(true);
            }
            for (int i = 0; i < 10; i++)
            {
                Number();
            }
        }

    }
}