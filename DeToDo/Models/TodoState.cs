using System;
using System.Collections.Generic;

namespace DeToDo.Models
{
    public class TodoState
    {
        public bool isLoading { get; set; }

        public List<TodoItem> Todos { get; set; } = new List<TodoItem>();

        public static TodoState InitialState => new TodoState()
        {
            isLoading = false,
            Todos = new List<TodoItem>()
        };
    }
}
