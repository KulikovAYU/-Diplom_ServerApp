using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FC_EMDB.Entities.Entities;
using Newtonsoft.Json;

namespace NotificationTestCore
{
    public class Notification
    {
        public string title { get; set; }
        public string body { get; set; }
        public int badge { get; set; } = 1;
    }

    public class NotificationManager {


        public string _Url { get; private set; }
        public string _Key { get; private set; }
        public string _ContentType { get; private set; }
        public ICollection<string> _Tokens { get; private set; }
        public string _Priority { get; private set; }
        public ICollection<Notification> _Notifications { get; private set; }
        public string _Title { get; private set; }

        public bool Invoke()
        {
            WebRequest tRequest = WebRequest.Create(_Url);
            tRequest.Method = "post";

            //serverKey - Key from Firebase cloud messaging server  
            //см. Cloud Messaging ->Устаревший ключ сервера
            tRequest.Headers.Add(string.Format("Authorization: key={0}", _Key));

            //Sender Id - From firebase project setting 
            //tRequest.Headers.Add(string.Format("Sender: id={0}", "966097863935"));
            tRequest.ContentType = _ContentType;

            foreach (var token in _Tokens)
            {
                foreach (var notification in _Notifications)
                {
                    var payload = new
                    {
                        to = token, //это токен устройства
                        priority = _Priority,
                        content_available = true,
                        notification = new
                        {
                            title = _Title ?? notification.body,
                            body = notification.body,
                            badge = notification.badge
                        },
                    };

                    string postbody = JsonConvert.SerializeObject(payload).ToString();
                    Byte[] byteArray = Encoding.UTF8.GetBytes(postbody);
                    tRequest.ContentLength = byteArray.Length;
                    using (Stream dataStream = tRequest.GetRequestStream())
                    {
                        dataStream.Write(byteArray, 0, byteArray.Length);
                        using (WebResponse tResponse = tRequest.GetResponse())
                        {
                            using (Stream dataStreamResponse = tResponse.GetResponseStream())
                            {
                                if (dataStreamResponse != null) using (StreamReader tReader = new StreamReader(dataStreamResponse))
                                    {
                                        String sResponseFromServer = tReader.ReadToEnd();
                                        //result.Response = sResponseFromServer;
                                    }
                            }
                        }
                    }

                }
            }

            return true;
        }

        public class NotificationManagerBuilder
    {
        public string _Url { get; private set; }
        public string _Key { get; private set; }
        public string _ContentType { get; private set; }
        public ICollection<string> _Tokens { get; private set; } = new List<string>();
        public string _Priority { get; private set; } = "high";
        public ICollection<Notification> _Notifications { get; private set; } = new List<Notification>();
            public string _Title { get; private set; }


        public NotificationManagerBuilder Url(string url)
        {
            _Url = url;
            return this;
        }

        public NotificationManagerBuilder AuthorizationKey(string key)
        {
            _Key = key;
            return this;
        }

        public NotificationManagerBuilder ContentType(string content)
        {
            _ContentType = $"application/{content}";
            return this;
        }

        public NotificationManagerBuilder Tokens(IEnumerable<FcmInfo> infos)
        {
            //скопируем токены устройств
            foreach (var token in infos)
            {
                _Tokens.Add(token.FcmToken);
            }

            return this;
        }

        public NotificationManagerBuilder TitleNotification(string title)
        {
            _Title = title;
            return this;
        }

            public NotificationManagerBuilder Notification(Notification notification)
        {
            _Notifications.Add(notification);
            return this;
        }

        public NotificationManagerBuilder Notifications(ICollection<Notification> notifications)
        {
            _Notifications = notifications;
            return this;
        }

        public NotificationManager Build()
        {
            return new NotificationManager
            {
                _ContentType = this._ContentType,
                _Key = this._Key,
                _Notifications = this._Notifications,
                _Priority = this._Priority,
                _Tokens = this._Tokens,
                _Url = this._Url,
                _Title = this._Title
            };
        }

            
        }
    }

}
