using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DeToDo.Models
{
    public class TodoState
    {
        public bool isLoading { get; set; }

        public ObservableCollection<TodoItem> Todos { get; set; } = new ObservableCollection<TodoItem>();

        public static TodoState InitialState => new TodoState()
        {
            isLoading = false,
            Todos = new ObservableCollection<TodoItem>()
        };
    }
}
