using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using ToDo.DAL.Entities;
using ToDo.DAL.Interfaces;

namespace ToDo.DAL.Repositories
{
    public class SerializeRepository : IRepository
    {
        public SerializeRepository()
        {

        }
        public void Add(List<ToDolist> item)
        {
            var binFormatter = new BinaryFormatter();
            using (var file = new FileStream("ToDolist.dat", FileMode.OpenOrCreate))
            {
                binFormatter.Serialize(file, item);
            }
        }
        public List<ToDolist> GetToDoList()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("ToDolist.dat", FileMode.Open))
            {
                if (fs.Length > 0 && formatter.Deserialize(fs) is List<ToDolist> ToDolists)
                {
                    return ToDolists;
                }
                else
                {
                    return new List<ToDolist>();
                }
            }
        }
    }
}
