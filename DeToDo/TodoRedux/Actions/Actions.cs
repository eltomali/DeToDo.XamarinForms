using System;
using Redux;

namespace DeToDo.TodoRedux.Actions
{
    public class AddTodoAction: IAction
    {
        public AddTodoAction(string text)
        {
            Text = text;
        }

        public string Text { get; }
    }
    public class DelTodoAction : IAction
    {

        public DelTodoAction(Guid id)
        {
            TodoId = id;
        }

        public Guid TodoId { get;  }
    }
}
