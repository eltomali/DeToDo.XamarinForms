using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeToDo.Models;
using DeToDo.TodoRedux.Actions;
using Xamarin.Forms;

namespace DeToDo.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public List<TodoItem> Todos { get; set; }
        public MainPage()
        {
            InitializeComponent();
            App.TodoStore.Subscribe(state =>
            {
                Todos = state.Todos.ToList();
                TodosItemsControl.ItemsSource = Todos;
            });
        }

        void AddTodoButton_Clicked(object sender, EventArgs e)
        {
            if(TodoEntryText.Text == "")
            {
                return;
            }
            App.TodoStore.Dispatch(new AddTodoAction(TodoEntryText.Text));
            TodoEntryText.Text = "";
        }

        void DeleteTodo(object sender, EventArgs e)
        {
            if (!(sender != null && sender is Cell del)) return;
            if (!(del.BindingContext is TodoItem todoItem)) return;
            App.TodoStore.Dispatch(new DelTodoAction(todoItem.Id));
        }
    }
}
