namespace DemoExam.Models
{
    /// <summary>
    /// Представляет мастера в системе обслуживания.
    /// </summary>
    public class Master
    {
        public int Id { get; set; } // Идентификатор мастера.
        public string Name { get; set; } // Имя
        public string Specialization { get; set; } // Специализация
        public string PhoneNumber { get; set; } // Номер телефона
    }
}