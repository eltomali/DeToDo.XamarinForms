using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using DeToDo.Models;
using DeToDo.TodoRedux;
using DeToDo.TodoRedux.Actions;
using Redux;
using Xamarin.Forms;

namespace DeToDo.Views
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<TodoItem> Todos { get; set; }
        private readonly IStore<TodoState> _store;

        public MainPage():this(App.TodoStore){}

        public MainPage(IStore<TodoState> store)
        {
            InitializeComponent();
            _store = store;

            store.Subscribe(state =>
            {
                Todos = state.Todos;
                todoItems.ItemsSource = Todos;
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

        async void TodosItemsControl_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            // DELETE ITEM WHEN SELECTED
            var selectedTodo = todoItems.SelectedItem as TodoItem;
            if (selectedTodo != null)
            {
                await _store.DispatchAsync(ActionCreators.DeleteTodoAsync(selectedTodo));
            }
        }

    }
}
