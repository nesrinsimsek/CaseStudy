using CaseDataAccess.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseDataAccess.Dals.Abstract
{
    public interface ITodoItemDal : IEntityRepository<TodoItem>
    {
    }
}
