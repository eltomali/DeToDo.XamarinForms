using System;
using DeToDo.Models;
using DeToDo.TodoRedux.Reducers;
using Redux;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DeToDo.Views;

namespace DeToDo
{
    public partial class App : Application
    {
        public static Store<TodoState> TodoStore { get; private set; }

        public App()
        {
            InitializeComponent();

            TodoStore = new Store<TodoState>(
               TodoReducer.Execute,
               new TodoState());

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
