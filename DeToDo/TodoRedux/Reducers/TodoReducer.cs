using System.Linq;
using Redux;
using DeToDo.Models;
using DeToDo.TodoRedux.Actions;

namespace DeToDo.TodoRedux.Reducers
{
    public static class TodoReducer
    {
        public static TodoState Execute(TodoState previousState, IAction action)
        {
            switch (action)
            {
                case AddTodoAction newTodo:
                    var todo = new TodoItem()
                    {
                        Id = newTodo.Id,
                        Text = newTodo.Text
                    };
                    previousState.Todos.Add(todo);
                    break;
                case DelTodoAction d:
                    var todoToDelete = previousState.Todos
                        .FirstOrDefault(t => t.Id == d.Id);
                    previousState.Todos.Remove(todoToDelete);
                    break;
                case LoadTodosAction l:
                    previousState.Todos = l.Todos;
                    break;
            }
            return previousState;
        }
    }
}
