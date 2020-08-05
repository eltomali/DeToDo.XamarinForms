using System;
using System.Threading.Tasks;
using DeToDo.TodoRedux.Actions;
using Redux;

namespace DeToDo.TodoRedux
{
    public static class StoreExtensions
    {
        public static Task DispatchAsync<TState> (
            this IStore<TState> store, AsyncActionCreators<TState> asyncAction)
        {
            return asyncAction(store.Dispatch, store.GetState);
        }
    }
}
