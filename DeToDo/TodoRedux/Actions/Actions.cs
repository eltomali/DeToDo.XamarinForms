using System;
using System.Collections.ObjectModel;
using DeToDo.Models;
using Redux;

namespace DeToDo.TodoRedux.Actions
{
    public class AddTodoAction: IAction
    {
        public Guid Id { get; }
        public string Text { get; }

        public AddTodoAction(Guid id, string text)
        {
            Id = id;
            Text = text;
        }        
    }
    public class DelTodoAction : IAction
    {
        public Guid Id { get; }
        public DelTodoAction(Guid id)
        {
            Id = id;
        }
    }
    public class LoadTodosAction: IAction {
        public ObservableCollection<TodoItem> Todos;
        public LoadTodosAction(ObservableCollection<TodoItem> todos)
        {
            this.Todos = todos;
        }
    }
}
