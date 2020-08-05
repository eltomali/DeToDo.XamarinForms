using System;
using System.Collections.Generic;
using DeToDo.Models;
using DeToDo.TodoRedux;
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

        async void AddTodoButton_Clicked(object sender, EventArgs e)
        {
            if (TodoEntryText.Text == "")
            {
                return;
            }

            await App.TodoStore.DispatchAsync(ActionCreators.AddTodoAsync(TodoEntryText.Text)); 
            TodoEntryText.Text = "";
            await Navigation.PopAsync();
        }
    }
}
