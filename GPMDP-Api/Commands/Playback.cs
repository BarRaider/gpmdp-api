using GPMDP_Api.Enums;
using GPMDP_Api.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
        public static async Task<TimeSpan> GetCurrentTimeAsync(this Client c)
        {
            var r = await c.GetCommand("playback", "getCurrentTime");
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
        public static async Task<TimeSpan> GetTotalTimeAsync(this Client c)
        {
            var r = await c.GetCommand("playback", "getTotalTime");
            var ms = long.Parse(r.ToString());
            return TimeSpan.FromMilliseconds(ms);
        }


        /// <summary>
        /// Gets the current track
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static async Task<Track> GetCurrentTrackAsync(this Client c)
        {
            var r = await c.GetCommand("playback", "getCurrentTrack");
            return JsonConvert.DeserializeObject<Track>(r);
        }

        /// <summary>
        /// Checks if the track is playing or not
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static async Task<bool> IsPlayingAsync(this Client c)
        {
            return bool.Parse(await c.GetCommand("playback", "isPlaying"));
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

        public static async Task<PlaybackStatus> GetPlaybackStateAsync(this Client c)
        {
            var r = await c.GetCommand("playback", "getPlaybackState");
            if (Enum.TryParse<PlaybackStatus>(r, out PlaybackStatus result))
            {
                return result;
            }
            return PlaybackStatus.Unknown;
        }

        public static async Task<ShuffleType> GetShuffleAsync(this Client c)
        {
            var val = await c.GetCommand("playback", "getShuffle");
            switch (val)
            {
                case "ALL_SHUFFLE":
                    return ShuffleType.All;
                case "NO_SHUFFLE":
                    return ShuffleType.None;
                default:
                    return ShuffleType.Unknown;
            }
        }

        public static void SetShuffle(this Client c, ShuffleType type)
        {
            c.SendCommand("playback", "setShuffle", type.ToString());
        }

        public static async Task<ShuffleType> ToggleShuffleAsync(this Client c)
        {
            c.SendCommand("playback", "toggleShuffle");
            return await c.GetShuffleAsync();
        }

        public static async Task<RepeatType> GetRepeatAsync(this Client c)
        {
            var val = await c.GetCommand("playback", "getRepeat");
            switch (val)
            {
                case "LIST_REPEAT":
                    return RepeatType.List;
                case "SINGLE_REPEAT":
                    return RepeatType.Single;
                case "NO_REPEAT":
                    return RepeatType.None;
                default:
                    return RepeatType.Unknown;
            }
        }

        public static void SetRepeat(this Client c, RepeatType type)
        {
            c.SendCommand("playback", "setRepeat", type.ToString());
        }

        public static async Task<RepeatType> ToggleRepeatAsync(this Client c)
        {
            c.SendCommand("playback", "toggleRepeat");
            return await c.GetRepeatAsync();
        }
        
        public static bool IsPodcast(this Client c)
        {
            return bool.Parse(c.GetCommand("playback", "isPodcast").Result);
        }

        public static async Task<TimeSpan> RewindTenAsync(this Client c)
        {
            c.SendCommand("playback", "rewindTen");
            return await c.GetCurrentTimeAsync();
        }

        public static async Task<TimeSpan> ForwardThirtyAsync(this Client c)
        {
            c.SendCommand("playback", "forwardThirty");
            return await c.GetCurrentTimeAsync();
        }

        public static void ToggleVisualization(this Client c)
        {
            c.SendCommand("playback", "toggleVisualization");
        }

        public static void ImFeelingLucky(this Client c)
        {
            c.SendCommand("playback", "startFeelingLucky");
        }
    }

}
