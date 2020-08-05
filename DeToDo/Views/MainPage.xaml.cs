using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DeToDo.Models;
using DeToDo.TodoRedux;
using DeToDo.TodoRedux.Actions;
using Redux;
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
        private readonly IStore<TodoState> _store;

        public MainPage():this(App.TodoStore)
        {
        }

        public MainPage(IStore<TodoState> store)
        {
            InitializeComponent();
            _store = store;

            store.Subscribe(state =>
            {
                TodoItems.IsRefreshing = state.isLoading;
                Todos = state.Todos;
                TodoItems.ItemsSource = state.Todos;

            });
        }

        void AddTodoToolbar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddTodoPage());
        }


        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _store.DispatchAsync(ActionCreators.LoadTodosAsync());
        }

        void TodosItemsControl_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {

            var selectedTodo = TodoItems.SelectedItem as TodoItem;
            if (selectedTodo != null)
            {
                Navigation.PushAsync(new TodoDetailPage(selectedTodo));
            }
        }

    }
}
