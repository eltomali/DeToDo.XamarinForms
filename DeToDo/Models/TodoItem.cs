using System;
using SQLite;
namespace DeToDo.Models
{
    public class TodoItem
    {
        [PrimaryKey]
        public Guid Id { get; set; }
        public string Text { get; set; }
    }
}
