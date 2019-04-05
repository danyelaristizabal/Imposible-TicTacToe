using System;
using System.Collections.Generic; 

namespace TicTacToe.Repositories
{
    public interface IRepository
    {
        //public List<T> Objects { get; set; }
        void Add();
        void Delete();
        void Update();
        void FindById();
        void GetBusines(); 
    }
}
