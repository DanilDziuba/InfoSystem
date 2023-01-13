using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IDistrictRepository Districts { get; }
        IApplicationRepository Applications { get; }
        ILLCRepository LLCs { get; }
        ILandRepository Lands { get; }
        IBuildingRepository Buildings { get; }
        IPaymentRepository Payments { get; }
        void Save();
    }
}

