using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using ToDo.DAL.Entities;
using ToDo.DAL.Interfaces;
using ToDo.DAL.Repositories;

namespace ToDo.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            IRepository managerRepository = new SerializeRepository(); //определяем способ работы с данными
            //IRepository managerRepository = new InmemoryRepository();
            List<ToDolist> todolist = managerRepository.GetToDoList(); //считываем хранящиеся данные в список для дальнейшей работы уже со списком
            //List<ToDolist> todolist = new List<ToDolist>();
            while (true)
            {
                Console.WriteLine("Введите для выполнения команды");
                Console.WriteLine("1 - Добавить запись.");
                Console.WriteLine("2 - Показать список дел.");
                Console.WriteLine("3 - Поиск по названию.");
                Console.WriteLine("4 - Сортировка задач по приоритету.");
                Console.WriteLine("5 - Отметить задачу как выполненную.");
                Console.WriteLine("6 - Удалить запись по номеру.");
                Console.WriteLine("Q - выход");
                var key = Console.ReadKey();
                Console.WriteLine();
                //Console.Clear();
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        ToDolist todo = new ToDolist();
                        Console.WriteLine("Введите номер записи:");
                            todo.Id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите название задачи:");
                            todo.Name = Console.ReadLine();
                        Console.WriteLine("Обозначьте приоритет (1-высокий, 2-средний, 3-низкий): ");
                            todo.Priority = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите статус выполнения: ");
                            todo.Text = Console.ReadLine();

                        todolist.Add(todo);
                        //managerRepository.Add(todolist);

                        //Console.ReadKey();
                        Console.Clear();
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        Console.WriteLine("Список дел:");
                        //managerRepository.GetToDoList();

                            foreach (var TDL in todolist)
                            {
                                Console.WriteLine(TDL);
                            }

                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case ConsoleKey.D3:
                        Console.Clear();
                        Console.WriteLine("Введите название задачи для поиска:");
                        string searchbyName = Console.ReadLine();

                        var selectedToDolistbyName = todolist.Where(tdl => tdl.Name == searchbyName);//выбор элементов из списка с соответствующим названием задачи
                            foreach (var TDL in selectedToDolistbyName)
                            {
                                Console.WriteLine(TDL);
                            }

                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case ConsoleKey.D4:
                        Console.Clear();
                        Console.WriteLine("Сортировка по приоритету от высокого к низкому (Обозначения: 1 - высокий, 2 - средний, 3 - низкий):");

                        var sortedToDoList = todolist.OrderBy(tdl => tdl.Priority);
                            foreach (var TDL in sortedToDoList)
                            {
                                Console.WriteLine(TDL);
                            }

                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case ConsoleKey.D5:
                        Console.Clear();
                        Console.WriteLine("Введите номер задачи:");
                        int updateId = int.Parse(Console.ReadLine());

                        var todoToUpdate = todolist.Where(tdl => tdl.Id == updateId).First();
                        todoToUpdate.Text = "Выполнено";
                        Console.WriteLine($"Задача '{todoToUpdate.Name}' отмечена как выполненная");

                        //var sortedToDoList = todolist.OrderBy(tdl => tdl.Priority);


                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case ConsoleKey.D6:
                        Console.Clear();
                        Console.WriteLine("Введите номер задачи для удаления:");
                        int delId = int.Parse(Console.ReadLine());
                        var todoToDelete = todolist.Where(tdl => tdl.Id == delId).First(); //получаем элемент списка по номеру задачи для удаления

                        todolist.Remove(todoToDelete);

                        break;
                    case ConsoleKey.D7:
                        Console.Clear();
                        Console.WriteLine("Сохранить и вывести:");
                        managerRepository.Add(todolist);
                        managerRepository.GetToDoList();
                        foreach (var TDL in managerRepository.GetToDoList())
                        {
                            Console.WriteLine(TDL);
                        }
                        Console.ReadKey();

                        break;

                    case ConsoleKey.Q:
                        managerRepository.Add(todolist);
                        Environment.Exit(0);
                        break;
                }

                //Console.ReadLine();
            }
        }
    }
}
