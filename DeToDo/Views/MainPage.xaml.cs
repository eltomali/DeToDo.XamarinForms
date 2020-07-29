using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DeToDo.Models;
using DeToDo.TodoRedux.Actions;
using SQLite;
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

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<TodoItem>();
                Todos = conn.Table<TodoItem>().ToList();
                TodosItemsControl.ItemsSource = Todos;
            }

            //App.TodoStore.Subscribe(state =>
            //{
            //    Todos = state.Todos.ToList();
            //    TodosItemsControl.ItemsSource = Todos;
            //});
        }

        void AddTodoToolbar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddTodoPage());
        }

        void DeleteTodo(object sender, EventArgs e)
        {
            if (!(sender != null && sender is Cell del)) return;
            if (!(del.BindingContext is TodoItem todoItem)) return;
            App.TodoStore.Dispatch(new DelTodoAction(todoItem.Id));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<TodoItem>();
                Todos = conn.Table<TodoItem>().ToList();
                TodosItemsControl.ItemsSource = Todos;
            }
            
        }

        void TodosItemsControl_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            //if (!(sender != null && sender is Cell del)) return;
            //if (!(del.BindingContext is TodoItem todoItem)) return;
            //App.TodoStore.Dispatch(new DelTodoAction(todoItem.Id));

            var selectedTodo = TodosItemsControl.SelectedItem as TodoItem;
            if(selectedTodo != null)
            {
                Navigation.PushAsync(new TodoDetailPage(selectedTodo));
            }
        }

    }
}
