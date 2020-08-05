using System.Collections.ObjectModel;

namespace DeToDo.Models
{
    public class TodoState
    {


        public ObservableCollection<TodoItem> Todos { get; set; } = new ObservableCollection<TodoItem>();

        public static TodoState InitialState => new TodoState()
        {

            Todos = new ObservableCollection<TodoItem>()
        };
    }
}
