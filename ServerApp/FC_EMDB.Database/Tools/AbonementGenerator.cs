using System;
using System.Diagnostics;
using System.Linq;
using FC_EMDB.Database.UnitOfWork;

namespace FC_EMDB.Database.Tools
{
    public static class AbonementGenerator
    {
        static AbonementGenerator()
        {
            m_rnd = new Random();
        }

        /// <summary>
        /// Функция генерирует номер абонемента
        /// </summary>

        /// <returns>Уникальный номер абонемента</returns>
        public static int CreateNumberSubscription(IUnitOfWork context)
        {
           
            int number = 0;
            try
            {
                Generate(ref number, context);
            }
            catch (Exception e)
            {
                //Messenger.Default.Send<Exception>(e);
                Debug.Write("Исключение" + e.Message);
            }
            return number;
        }

        private static readonly Random m_rnd;
        private static int m_next;
        private const int MinValue = 999;
        private const int MaxValue = 10000;


        static void Generate(ref int inNumberSubscription, IUnitOfWork context)
        {
            if (context == null)
                return;

            if (!context.Clients.GetAll().Any())
            {
                m_next = m_rnd.Next(MinValue, MaxValue);
                inNumberSubscription = m_next;
            }
            else
            {
                //Получим номера абонементов всех клиеннтов

                var num = inNumberSubscription;
                var query = context.Clients.Find(client => client.AbonementNumber == num);
                //var query = from numberSubscription in context.Clients. select numberSubscription.Abonement.NumberSubscription;
                //сгенерировали номер абонемента
                m_next = m_rnd.Next(MinValue, MaxValue);
                if (query != null)
                {
                    Generate(ref inNumberSubscription, context);
                }
                else
                {
                    inNumberSubscription = m_next;
                }
            }
        }
    }
}
