using System;
using System.Collections.Generic;
using System.Text;

namespace Supero.TaskList.Web.Framework.Model
{
    public class TodoItemDto
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
    }
}
