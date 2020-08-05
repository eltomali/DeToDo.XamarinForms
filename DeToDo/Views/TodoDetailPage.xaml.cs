using System;
using System.Collections.Generic;
using DeToDo.Models;
using DeToDo.TodoRedux;
using DeToDo.TodoRedux.Actions;
using SQLite;
using Xamarin.Forms;

namespace DeToDo.Views
{
    public partial class TodoDetailPage : ContentPage
    {
        TodoItem selectedTodo;

        public TodoDetailPage(TodoItem selectedTodo)
        {
            InitializeComponent();

            this.selectedTodo = selectedTodo;
            todoEntry.Text = selectedTodo.Text;
        }

        async void UpdateButton_Clicked(System.Object sender, System.EventArgs e)
        {
            selectedTodo.Text = todoEntry.Text;


            await App.TodoStore.DispatchAsync(ActionCreators.UpdateTodoAsync(selectedTodo));
            await Navigation.PopAsync();
        }

        async void DeleteButton_Clicked(System.Object sender, System.EventArgs e)
        {
            //if (!(sender != null && sender is Button del)) return;
            //if (!(del.BindingContext is TodoItem todoItem)) return;
            await App.TodoStore.DispatchAsync(ActionCreators.DeleteTodoAsync(selectedTodo));
            await Navigation.PopAsync();
        }
    }
}
