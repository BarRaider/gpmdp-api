using GPMDP_Api.Enums;
using GPMDP_Api.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GPMDP_Api.Playback
{
    public static class Playback
    {
        /// <summary>
        /// Play or Pause the current track
        /// </summary>
        /// <param name="c"></param>
        public static void PlayPause(this Client c)
        {
            c.SendCommand("playback", "playPause");
        }

        /// <summary>
        /// Get the current time in the track playing
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static TimeSpan GetCurrentTime(this Client c)
        {
            var r = c.GetCommand("playback", "getCurrentTime").Result;
            var ms = long.Parse(r.ToString());
            return TimeSpan.FromMilliseconds(ms);
        }

        /// <summary>
        /// Seek to a specific time
        /// </summary>
        /// <param name="c"></param>
        /// <param name="milliseconds"></param>
        public static void SetCurrentTime(this Client c, long milliseconds)
        {
            c.SendCommand("playback", "setCurrentTime", milliseconds);
        }

        /// <summary>
        /// Seek to a specific time
        /// </summary>
        /// <param name="c"></param>
        /// <param name="milliseconds"></param>
        public static void SetCurrentTime(this Client c, TimeSpan time)
        {
            c.SendCommand("playback", "setCurrentTime", time.TotalMilliseconds);
        }


        /// <summary>
        /// Gets the total length of the current track
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static TimeSpan GetTotalTime(this Client c)
        {
            var r = c.GetCommand("playback", "getTotalTime").Result;
            var ms = long.Parse(r.ToString());
            return TimeSpan.FromMilliseconds(ms);
        }


        /// <summary>
        /// Gets the current track
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static Track GetCurrentTrack(this Client c)
        {
            var r = c.GetCommand("playback", "getCurrentTrack").Result;
            return JsonConvert.DeserializeObject<Track>(r);
        }

        /// <summary>
        /// Checks if the track is playing or not
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsPlaying(this Client c)
        {
            return bool.Parse(c.GetCommand("playback", "isPlaying").Result);
        }

        /// <summary>
        /// Go to the previous track
        /// </summary>
        /// <param name="c"></param>
        public static void Previous(this Client c)
        {
            c.SendCommand("playback", "rewind");
        }

        /// <summary>
        /// Go to the next track
        /// </summary>
        /// <param name="c"></param>
        public static void Next(this Client c)
        {
            c.SendCommand("playback", "forward");
        }

        public static object GetPlaybackState()
        {
            throw new NotImplementedException();
        }

        public static ShuffleType GetShuffle()
        {
            throw new NotImplementedException();
        }

        public static void SetShuffle(ShuffleType type)
        {
            throw new NotImplementedException();
        }

        public static ShuffleType ToggleShuffle()
        {
            throw new NotImplementedException();
        }

        public static RepeatType GetRepeat()
        {
            throw new NotImplementedException();
        }

        public static void SetRepeat(RepeatType type)
        {
            throw new NotImplementedException();
        }

        public static RepeatType ToggleRepeat()
        {
            throw new NotImplementedException();
        }
        
        public static bool IsPodcast()
        {
            throw new NotImplementedException();
        }

        public static TimeSpan RewindTen()
        {
            throw new NotImplementedException();
        }

        public static TimeSpan ForwardThirty()
        {
            throw new NotImplementedException();
        }

        public static void ToggleVisualization()
        {
            throw new NotImplementedException();
        }

        public static void ImFeelingLucky()
        {
            throw new NotImplementedException();
        }
    }
}
