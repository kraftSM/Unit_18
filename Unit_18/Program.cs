using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Unit_18
{
    static class Program
    {
        public static void Main()
        {
            Console.WriteLine("Введите ссылку на видео с YouTube");
            // создадим отправителя
            var CommandSender = new CommandSender();

            // создадим получателя
            //var video = new Video(Console.ReadLine()); 
            //string videoPath = Console.ReadLine();
            string videoPath = Console.ReadLine();
            //string videoPath = "https://www.youtube.com/watch?v=igNcDEEl5to";
            //string videoPath = "https://www.youtube.com/watch?v=UUQYSoC7baI";
            //string videoPath = "https://www.youtube.com/watch?v=in8w8nMbzmI";
            //string videoPath = "https://www.youtube.com/watch?v=7QA7KMfl2RM";
            //string videoPath = "https://www.youtube.com/watch?v=J-h-HXuY3zs";
            //string videoPath = "https://www.youtube.com/watch?v=fctKsVKAMNk";
            //string videoPath = "https://www.youtube.com/watch?v=iYoADuvz62E";
            //string videoPath = "https://www.youtube.com/watch?v=1La4QzGeaaQ";

            Console.WriteLine("Link = "+ videoPath);

            var video = new Video(videoPath);
            
            // создадим команду
            var commandOne = new VideoAction(video);

            // инициализация команды
            CommandSender.SetAction(commandOne);

            //  выполнение
            CommandSender.GetInfo();
            CommandSender.Download();

            Console.ReadKey();
        }
    }
}
