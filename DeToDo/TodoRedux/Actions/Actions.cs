using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DeToDo.Models;
using Redux;

namespace DeToDo.TodoRedux.Actions
{
    public class AddTodoAction: IAction
    {
        public AddTodoAction(Guid id, string text)
        {
            Id = id;
            Text = text;
        }

        public Guid Id {get; }
        public string Text { get; }
    }
    public class DelTodoAction : IAction
    {

        public DelTodoAction(Guid id)
        {
            Id = id;
        }

        public Guid Id { get;  }
    }


    public class LoadTodosAction: IAction {
        public ObservableCollection<TodoItem> Todos;
        public LoadTodosAction(ObservableCollection<TodoItem> todos)
        {
            this.Todos = todos;
        }
    }


}
