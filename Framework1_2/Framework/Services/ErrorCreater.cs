using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Services
{
    class ErrorCreater
    {
        static readonly string invalidEmail = "Неправильный E-mail";
        static readonly string invalidPrice = "Неправильная стоимость";
        static readonly string invalidPhone = "Указан неверный номер телефона";
        static readonly string emptyEmail = "Поле 'E-mail' должно быть заполнено!";
        static readonly string emptyPhone = "Поле 'Телефон' должно быть заполнено!";
        static readonly string emptyName = "Поле 'Имя' должно быть заполнено!";
        static readonly string startDateLeaseEndDate = "Дата начала аренды позже даты окончания.";
        static readonly string similarStartDateAndEndDate = "Дата начала аренды не может совпадать с датой окончания.";
        public static string FormWithInvalidEMail()
        {
            return invalidEmail;
        }
        public static string FormWithInvalidPhone()
        {
            return invalidPhone;
        }

        public static string FormWithInvalidPrice()
        {
            return invalidPrice;
        }
        public static string CorrectNamePhoneEmail()
        {
            return "";
        }
        
        public static string StartDateLeaseEndDate()
        {
            return "×\r\n"+ startDateLeaseEndDate;
        }

        public static string SimilarStartDateAndEndDate()
        {
            return "×\r\n" + similarStartDateAndEndDate;
        }
    }
}
