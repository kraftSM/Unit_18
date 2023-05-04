using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode.Videos;

namespace Unit_18
{
    interface IAction
    {
        void GetInfo();
        void Download();

    }
 
    class VideoAction : IAction  /// Команда работы с видео
    {
        Video _video;

        public VideoAction(Video video)
        {
            _video = video;
        }

        public void GetInfo()
        {
            _video.GetInfo();
        }

        public void Download()
        {
            _video.DownloadAsync();
        }
    }
    /// <summary>
    /// Отправитель команд
    /// </summary>
    class CommandSender
    {
        IAction _action;

        public void SetAction(IAction action) ///  Инициализация команды
        {
            _action = action;
        }

        public void GetInfo() // запуск команды GetInfo
        {            
            _action.GetInfo();
        }

        public void Download() // запуск команды Download
        {
            _action.Download();
        }
    }
}
