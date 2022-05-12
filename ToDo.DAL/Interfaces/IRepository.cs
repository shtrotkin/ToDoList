using System;
using System.Collections.Generic;
using ToDo.DAL.Entities;

namespace ToDo.DAL.Interfaces
{
    public interface IRepository
    {
        List<ToDolist> GetToDoList();
        void Add(List<ToDolist> item);
    }
}
