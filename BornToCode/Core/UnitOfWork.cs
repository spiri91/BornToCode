using System;
using BornToCode.Core.Contracts;

namespace BornToCode.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        public void SaveState<T>(IRepository<T> repository, Action postSaveCallback = null) where T : class
        {
            repository.Save();

            postSaveCallback?.Invoke();
        }
    }
}
