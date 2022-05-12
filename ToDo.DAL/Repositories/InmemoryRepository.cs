using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.DAL.EFInMemory;
using ToDo.DAL.Entities;
using ToDo.DAL.Interfaces;

namespace ToDo.DAL.Repositories
{
    public class InmemoryRepository : IRepository
    {
        private DbContextOptions<ToDolistContext> options = new DbContextOptionsBuilder<ToDolistContext>().UseInMemoryDatabase(databaseName: "ToDolistDB").Options;

        public void Add(List<ToDolist> item)
        {           
            using (var db = new ToDolistContext(options))
            {
                db.Set<ToDolist>().AddRange(item);
                db.SaveChanges();
            }
        }

        public List<ToDolist> GetToDoList()
        {
            using (var db = new ToDolistContext(options))
            {
                return db.todolist.ToList();
            }
        }
    }
}
