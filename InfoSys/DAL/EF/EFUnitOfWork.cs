using DAL.Repositories.Impl;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.EF
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private DistrictContext db;
        private DistrictRepository districtRepository;
        private ApplicationRepository applicationRepository;
        private LLCRepository llcsRepository;
        private LandRepository landRepository;
        private BuildingRepository buildingRepository;
        private PaymentRepository paymentRepository;

        public EFUnitOfWork(DistrictContext context)
        {
            db = context;
        }
        public IDistrictRepository Districts
        {
            get
            {
                if (districtRepository == null)
                    districtRepository = new DistrictRepository(db);
                return districtRepository;
            }
        }
        public ILLCRepository LLCs
        {
            get
            {
                if (llcsRepository == null)
                    llcsRepository = new LLCRepository(db);
                return llcsRepository;
            }
        }
        public IApplicationRepository Applications
        {
            get
            {
                if (applicationRepository == null)
                    applicationRepository = new ApplicationRepository(db);
                return applicationRepository;
            }
        }
        public ILandRepository Lands
        {
            get
            {
                if (landRepository == null)
                    landRepository = new LandRepository(db);
                return landRepository;
            }
        }
        public IBuildingRepository Buildings
        {
            get
            {
                if (buildingRepository == null)
                    buildingRepository = new BuildingRepository(db);
                return buildingRepository;
            }
        }
        public IPaymentRepository Payments
        {
            get
            {
                if (paymentRepository == null)
                    paymentRepository = new PaymentRepository(db);
                return paymentRepository;
            }
        }


        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
