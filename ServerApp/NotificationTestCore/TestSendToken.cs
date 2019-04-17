using System;
using FC_EMDB.Database.UnitOfWork;
using FC_EMDB.Database.UnitOfWork.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace NotificationTestCore
{
    public class TestSendToken : ITestSender
    {
        private IUnitOfWork unitOfWork;
        public TestSendToken(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
          
        }

    #region ToSave

    //WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
    //tRequest.Method = "post";
    ////serverKey - Key from Firebase cloud messaging server  
    ////см. Cloud Messaging ->Устаревший ключ сервера
    //tRequest.Headers.Add(string.Format("Authorization: key={0}", "AIzaSyA5qa6VNgZOGPzxtesk4MkJPGT_8VzIZv4"));
    ////Sender Id - From firebase project setting 
    ////tRequest.Headers.Add(string.Format("Sender: id={0}", "966097863935"));
    //tRequest.ContentType = "application/json";
    //var payload = new
    //{
    //    to = "c9nVg5C7Fik:APA91bF1ltTaaM_AmI5Wvdazpr-lAFfepkbyXMYAmQ6k2aeRfMk1-0sth8RlM6d_-dbo-OQ0Ew8WZfiJih5Z0ercOT3AnPH_YTAsuSYgBfC8K-IaemZQerV_ZVBPRZ0T7lCxDsae1j-p", //это токен устройства
    //    priority = "high",
    //    content_available = true,
    //    notification = new
    //    {
    //        title = "FitClub",
    //        body = "Замена тренировки",
    //        badge = 1
    //    },
    //};

    //string postbody = JsonConvert.SerializeObject(payload).ToString();
    //Byte[] byteArray = Encoding.UTF8.GetBytes(postbody);
    //tRequest.ContentLength = byteArray.Length;
    //using (Stream dataStream = tRequest.GetRequestStream())
    //{
    //    dataStream.Write(byteArray, 0, byteArray.Length);
    //    using (WebResponse tResponse = tRequest.GetResponse())
    //    {
    //        using (Stream dataStreamResponse = tResponse.GetResponseStream())
    //        {
    //            if (dataStreamResponse != null) using (StreamReader tReader = new StreamReader(dataStreamResponse))
    //                {
    //                    String sResponseFromServer = tReader.ReadToEnd();
    //                    //result.Response = sResponseFromServer;
    //                }
    //        }
    //    }
    //}


    #endregion

        public void Send(string message = "Замена тренировки")
        {
            IFcmInfoRepository FcmInfos = unitOfWork.FcmInfos;
            var FcmTokens = FcmInfos.GetAll();
            new NotificationManager.
                    NotificationManagerBuilder().
                Url("https://fcm.googleapis.com/fcm/send").
                AuthorizationKey("AIzaSyA5qa6VNgZOGPzxtesk4MkJPGT_8VzIZv4").
                ContentType("json").
                Tokens(FcmTokens).
                TitleNotification("FitClub").
                Notification(new Notification { body = message }).
                Build().
                Invoke();
        }
    }

    public interface ITestSender
    {
        void Send(string message);

    }
}
