using System;
using System.Threading.Tasks;
using DeToDo.Models;
using Redux;
using SQLite;
using Xamarin.Forms;

namespace DeToDo.TodoRedux.Actions
{
    public delegate Task AsyncActionCreators<TState>(Dispatcher dispatcher, Func<TState> getState);

    public static class ActionCreators
    {
        public static AsyncActionCreators<TodoState> LoadTodosAsync()
        {
            return async (dispatch, getState) =>
            {
                dispatch(new LoadTodosAction());

                try
                {
                    SQLiteAsyncConnection conn = new SQLiteAsyncConnection(App.DatabaseLocation);
                    
                    await conn.CreateTableAsync<TodoItem>();
                    var todos = await conn.Table<TodoItem>().ToListAsync();
                    dispatch(new LoadTodosSuccessAction(todos));
                    await conn.CloseAsync();
                }
                catch (Exception ex)
                {
                    dispatch(new TodosErrorAction(ex.ToString()));
                }
            };
        }

        public static AsyncActionCreators<TodoState> AddTodoAsync(string todoEntryText)
        {
            return async (dispatch, getState) =>
            {
                TodoItem todoItem = new TodoItem()
                {
                    Id = Guid.NewGuid(),
                    Text = todoEntryText
                };
                try
                {
                    SQLiteAsyncConnection conn = new SQLiteAsyncConnection(App.DatabaseLocation);

                    await conn.CreateTableAsync<TodoItem>();
                    int rows = await conn.InsertAsync(todoItem);

                    dispatch(new AddTodoAction(todoItem.Id, todoItem.Text));
                    await conn.CloseAsync();
                }
                catch (Exception ex)
                {
                    dispatch(new TodosErrorAction(ex.ToString()));
                }
            };
        }

        public static AsyncActionCreators<TodoState> DeleteTodoAsync(TodoItem selectedTodo)
        {
            return async (dispatch, getState) =>
            {
                
                try
                {
                    SQLiteAsyncConnection conn = new SQLiteAsyncConnection(App.DatabaseLocation);

                    await conn.CreateTableAsync<TodoItem>();
                    int rows = await conn.DeleteAsync(selectedTodo);

                    dispatch(new DelTodoAction(selectedTodo.Id));
                    await conn.CloseAsync();
                }
                catch (Exception ex)
                {
                    dispatch(new TodosErrorAction(ex.ToString()));
                }
            };
        }

        public static AsyncActionCreators<TodoState> UpdateTodoAsync(TodoItem updatedTodo)
        {
            return async (dispatch, getState) =>
            {
                try
                {
                    SQLiteAsyncConnection conn = new SQLiteAsyncConnection(App.DatabaseLocation);

                    await conn.CreateTableAsync<TodoItem>();
                    int rows = await conn.UpdateAsync(updatedTodo);

                    dispatch(new UpdateTodoAction(updatedTodo.Text));
                    await conn.CloseAsync();
                }
                catch (Exception ex)
                {
                    dispatch(new TodosErrorAction(ex.ToString()));
                }
            };
        }
    }
}
