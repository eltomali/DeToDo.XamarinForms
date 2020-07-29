using System;
using System.Collections.Generic;
using DeToDo.Models;
using DeToDo.TodoRedux.Actions;
using SQLite;
using Xamarin.Forms;

namespace DeToDo.Views
{
    public partial class AddTodoPage : ContentPage
    {
        public AddTodoPage()
        {
            InitializeComponent();
        }

        void AddTodoButton_Clicked(object sender, EventArgs e)
        {
            if (TodoEntryText.Text == "")
            {
                return;
            }

            //App.TodoStore.Dispatch(new AddTodoAction(TodoEntryText.Text));

            TodoItem todoItem = new TodoItem()
            {
                Id = Guid.NewGuid(),
                Text = TodoEntryText.Text
            };

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<TodoItem>();
                int rows = conn.Insert(todoItem);

                //if (rows > 0)
                //{
                //    DisplayAlert("Success", "Todo succesfully inserted", "Ok");
                //}
                //else
                //{
                //    DisplayAlert("Failure", "Todo not inserted", "Ok");
                //}
            }

            TodoEntryText.Text = "";
            Navigation.PopAsync();
        }
    }
}
