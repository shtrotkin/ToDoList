using System;

namespace ToDo.DAL.Entities
{
    [Serializable]
    public class ToDolist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Priority { get; set; }
        public string Text { get; set; }
        public ToDolist()
        {

        }
        public ToDolist(int id, string name, int priority, string text)
        {
            //проверка введенных данных
            Id = id;
            Name = name;
            Priority = priority;
            Text = text;
        }

        public override string ToString()
        {
            return "Номер записи:" + " " + Id.ToString() + "; " + "Задача:" + " " + Name.ToString() + "; " + "Приоритет:" + " " + Priority.ToString() + "; " + "Текст:" + " " + Text.ToString();
        }
    }
}
