using System;
using System.Collections.Generic;
using DeToDo.Models;
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

        void UpdateButton_Clicked(System.Object sender, System.EventArgs e)
        {
            selectedTodo.Text = todoEntry.Text;

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<TodoItem>();
                int rows = conn.Update(selectedTodo);

                //if (rows > 0)
                //{
                //    DisplayAlert("Success", "Todo succesfully updated", "Ok");
                //}
                //else
                //{
                //    DisplayAlert("Failure", "Todo not updated", "Ok");
                //}
                Navigation.PopAsync();
            }
        }

        void DeleteButton_Clicked(System.Object sender, System.EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<TodoItem>();
                int rows = conn.Delete(selectedTodo);

                //if (rows > 0)
                //{
                //    DisplayAlert("Success", "Todo succesfully deleted", "Ok");
                //}
                //else
                //{
                //    DisplayAlert("Failure", "Todo not deleted", "Ok");
                //}
                Navigation.PopAsync();
            }
        }
    }
}
