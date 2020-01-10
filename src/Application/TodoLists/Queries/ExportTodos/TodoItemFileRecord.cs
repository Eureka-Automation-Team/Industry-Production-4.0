using IPD.Application.Common.Mappings;
using IPD.Domain.Entities;

namespace IPD.Application.TodoLists.Queries.ExportTodos
{
    public class TodoItemRecord : IMapFrom<TodoItem>
    {
        public string Title { get; set; }

        public bool Done { get; set; }
    }
}
