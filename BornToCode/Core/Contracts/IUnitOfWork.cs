using System;

namespace BornToCode.Core.Contracts
{
    public interface IUnitOfWork
    {
        void SaveState<T>(IRepository<T> repository, Action postSaveCallBack = null) where T : class;
    }
}
