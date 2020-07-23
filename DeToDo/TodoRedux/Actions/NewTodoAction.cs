using System;
using DeToDo.Models;
using Redux;
namespace DeToDo.TodoRedux.Actions
{
    internal class NewTodoAction : IAction
    {
        public string Text { get; internal set; }
        public Guid Id { get; internal set; }
    }
}
