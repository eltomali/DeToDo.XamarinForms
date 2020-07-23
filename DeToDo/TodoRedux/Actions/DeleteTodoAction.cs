using System;
using Redux;

namespace DeToDo.TodoRedux.Actions
{
    internal class DeleteTodoAction : IAction
    {
        public Guid Id { get; internal set; }
    }
}
