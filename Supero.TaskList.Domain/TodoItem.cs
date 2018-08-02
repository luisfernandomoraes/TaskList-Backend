using System;
using System.Collections.Generic;
using System.Text;
using Supero.TaskList.Domain.Base;

namespace Supero.TaskList.Domain
{
    public class TodoItem:Entity
    {
        public string Description { get; set; }
        public bool IsCompleted { get; set; }

        public void ChangeInformations(string todoItemDescription, bool todoItemIsCompleted)
        {
            this.Description = todoItemDescription;
            this.IsCompleted = todoItemIsCompleted;
        }
    }
}
