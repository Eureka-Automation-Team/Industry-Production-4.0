using IPD.Application.TodoLists.Queries.ExportTodos;
using System.Collections.Generic;

namespace IPD.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
    }
}
