﻿using DAL.Entities;
using DAL.EF;
using DAL.Repositories.Impl;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DAL.Repositories.Impl
{
    internal class ApplicationRepository : BaseRepository<Application>, IApplicationRepository
    {
        internal ApplicationRepository(DistrictContext context) : base(context)
        {
        }
    }
}