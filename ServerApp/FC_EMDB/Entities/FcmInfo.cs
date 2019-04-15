using System;
using System.Collections.Generic;
using System.Text;

namespace FC_EMDB.Entities.Entities
{
    //сущности ключей(токенов) пользователей, которым необходимо разослать сообщения
   public class FcmInfo
    {
        public FcmInfo()
        {
            ClientsFcmInfos = new HashSet<ClientsFcmInfo>();
        }
        public int Id { get; set; }

        public string FcmToken { get; set; }

        public DateTime RegistrationDateTime { get; set; }

        /// <summary>
        /// Свойство навигации
        /// </summary>
        public ICollection<ClientsFcmInfo> ClientsFcmInfos { get; set; }
    }
}
