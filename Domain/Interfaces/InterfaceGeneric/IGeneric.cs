﻿namespace Domain.Interface.InterfaceGenerics
{
    public interface IGeneric<T> where T : class
    {
        Task Add(T objeto);
        Task Update(T objeto);
        Task Delete(T objeto);
        Task<T> GeTEntityById(int Id);
        Task<List<T>> List();
    }
}
