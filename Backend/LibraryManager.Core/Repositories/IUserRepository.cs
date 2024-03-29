﻿using LibraryManager.Core.Entities;

namespace LibraryManager.Core.Repositories;
public interface IUserRepository
{
    Task AddAsync(User user);
    Task<User> GetByIdAsync(Guid id);
}
