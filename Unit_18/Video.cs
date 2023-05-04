using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Converter;
using YoutubeExplode.Videos.Streams;

namespace Unit_18
{
    public class Video
    {
        public string pathVideo { get; set; }
        YoutubeClient client { get; set; }
        YoutubeExplode.Videos.Video video;
        public Video(string pathVideo)
        {
            this.pathVideo = pathVideo;
            client = new YoutubeClient();
            video = client.Videos.GetAsync(pathVideo).Result;
        }

        public void GetInfo()
        {
            Console.WriteLine("Getting Video INFO:");

            string title = video.Title;
            string description = video.Description;
            string duration = video.Duration.ToString();

            Console.WriteLine("Video title:" + title);
            Console.WriteLine("Video description:" + description);            
            Console.WriteLine("Video duration:" + duration);
        }

        public async Task DownloadAsync()
        {
            Console.WriteLine("Video dowloading");
            var streamManifest = await client.Videos.Streams.GetManifestAsync(pathVideo);
            var streamInfo = streamManifest.GetMuxedStreams().GetWithHighestVideoQuality();            
            var fileName = $"{video.Title}.{streamInfo.Container.Name}";
            //await client.Videos.DownloadAsync(pathVideo, new FileInfo(Assembly.GetExecutingAssembly().Location).Directory.FullName + "\\" + fileName);
            await client.Videos.DownloadAsync(pathVideo, new FileInfo(Assembly.GetExecutingAssembly().Location).Directory.FullName + "\\" + fileName, builder => builder.SetPreset(ConversionPreset.UltraFast));
            Console.WriteLine("Video dowloaded!");
        }
    }
}
