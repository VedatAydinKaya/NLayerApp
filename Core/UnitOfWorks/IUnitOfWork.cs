using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        Task CommitAsync(); //SaveAsync the asyn. one

        void Commit(); // SaveChanges()  uses globalEFCore method to manipulate to the datebase oparations
    }
}
