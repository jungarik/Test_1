using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarOwners.Domain.Entities;

namespace CarOwners.Domain.Abstract
{
    public interface IUnitOfWork
    {
        IOwnersRepository Owners { get; }
        ICarsRepository Cars { get; }
        void Save();
    }
}
