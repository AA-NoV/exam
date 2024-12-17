using System.Diagnostics.Metrics;

namespace DemoExam.Models
{
    /// <summary>
    /// Представляет пользователя в системе.
    /// </summary>
    public class User
    {
        public int Id { get; set; } // Идентификатор клиента.
        public DateTime DateAdded { get; set; } // Дата добавления заявки.
        public string AppType { get; set; } // Вид бытовой техники.
        public string Model { get; set; } // Модель бытовой техники.
        public string ProblemDesc { get; set; } // Описание проблемы.
        public string UserName { get; set; } // ФИО клиента.
        public string PhoneNumber { get; set; } // Номер телефона.
        public string Status { get; set; } // Статус заявки.

        public int? MasterId { get; set; } // Nullable, если мастер не выбран.
        public Master Master { get; set; } // Навигационное свойство.
    }
}