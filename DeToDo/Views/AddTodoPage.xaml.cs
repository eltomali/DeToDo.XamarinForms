using System;
using DeToDo.TodoRedux;
using DeToDo.TodoRedux.Actions;
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
            if (todoEntryText.Text == "")
            {
                return;
            }
            await App.TodoStore.DispatchAsync(ActionCreators.AddTodoAsync(todoEntryText.Text)); 
            todoEntryText.Text = "";
            await Navigation.PopAsync();
        }
    }
}
