using System;
using System.Linq;
using Redux;
using DeToDo.Models;
using DeToDo.TodoRedux.Actions;

namespace DeToDo.TodoRedux.Reducers
{
    public static class TodoReducer
    {
        public static TodoState Execute(TodoState state, IAction action)
        {
            switch (action)
            {
                case NewTodoAction newTodo:
                    var todo = new TodoItem()
                    {
                        Id = newTodo.Id,
                        Text = newTodo.Text
                    };
                    state.Todos.Add(todo);
                    break;
                case DeleteTodoAction d:
                    var todoToDelete = state.Todos
                        .FirstOrDefault(t => t.Id == d.Id);
                    state.Todos.Remove(todoToDelete);
                    break;
            }
            return state;
        }
    }
}
