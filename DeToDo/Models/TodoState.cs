using System;
using System.Collections.Generic;

namespace DeToDo.Models
{
    public class TodoState
    {
        public List<TodoItem> Todos { get; set; } = new List<TodoItem>();
    }
}
