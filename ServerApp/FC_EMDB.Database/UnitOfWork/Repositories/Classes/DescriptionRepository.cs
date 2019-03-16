﻿using FC_EMDB.Database.UnitOfWork.Interfaces;
using FC_EMDB.Entities.Entities;

namespace FC_EMDB.Database.UnitOfWork
{
    public class DescriptionRepository : Repository<Description>, IDescriptionRepository
    {
        public DescriptionRepository(Microsoft.EntityFrameworkCore.DbContext context) : base(context)
        {
        }
        //TODO: Разместите действия для работы с предварительными записями клиентов на тренировку
    }
}