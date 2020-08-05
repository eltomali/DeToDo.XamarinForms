using System;
using System.Collections.Generic;
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

    public class UpdateTodoAction : IAction
    {
        public string Text { get; }
        public Guid Id { get; }
        public UpdateTodoAction(string text, Guid id)
        {
            Id = id;
            Text = text;
        }

    }

    public class LoadTodosAction: IAction { }

    public class LoadTodosSuccessAction: IAction
    {
        public List<TodoItem> Todos;

        public LoadTodosSuccessAction(List<TodoItem> todos)
        {
            this.Todos = todos;
        }
    }

    public class TodosErrorAction: IAction
    {
        public string Error { get; }
        public TodosErrorAction(string error)
        {
            Error = error;
        }
    }


}
