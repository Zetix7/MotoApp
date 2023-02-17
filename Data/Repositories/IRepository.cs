﻿using MotoApp.Data.Entities;

namespace MotoApp.Data.Repositories;

internal interface IRepository<T> : IReadRepository<T>, IWriteRepository<T> where T : class, IEntity
{
    event EventHandler<T> ItemAdded;
    event EventHandler<T> ItemRemoved;
    event EventHandler<EventArgs> ItemsSaved;
}