using MediatR;
using Microsoft.Extensions.Logging;
using Potres.Contracting;
using Potres.Contracting.Commands;
using Potres.Dal.Model;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Potres.Dal.CommandHandlers
{
    public abstract class GenericCommandHandler<T, TAddCommand, TUpdateCommand, TDeleteCommand>
      where TDeleteCommand : DeleteCommand
      where TAddCommand : AddCommand
      where TUpdateCommand : UpdateCommand
      where T : class, IHasIntegerId
    {
        protected readonly PotresContext ctx;
        protected readonly ILogger logger;

        protected GenericCommandHandler(PotresContext ctx, ILogger logger)
        {
            this.ctx = ctx;
            this.logger = logger;
        }

        protected abstract void CopyValues(TUpdateCommand request, T item);
        protected abstract T CreateItem(TAddCommand request);

        public virtual async Task<Unit> Handle(TDeleteCommand request, CancellationToken cancellationToken)
        {
            var item = await ctx.Set<T>().FindAsync(request.Id);
            if (item != null)
            {
                ctx.Remove(item);
                await ctx.SaveChangesAsync();
                return default;
            }
            else
            {
                logger.LogError($"Invalid id: {request.Id} for delete command: {request.GetType().Name} ");
                throw new ArgumentException($"Invalid id: {request.Id}");
            }
        }

        /// <summary>
        /// virtualna metoda, tako da se može nadjačati za Agenciju i Klijenti koji su izvedeni iz Party
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected virtual async Task<T> LoadForUpdate(int id)
        {
            var item = await ctx.Set<T>().FindAsync(id);
            return item;
        }

        public virtual async Task<Unit> Handle(TUpdateCommand request, CancellationToken cancellationToken)
        {
            var item = await LoadForUpdate(request.Id);
            if (item != null)
            {
                CopyValues(request, item);
                await ctx.SaveChangesAsync();
                return default;
            }
            else
            {
                logger.LogError($"Invalid id: {request.Id} for update command: {request.GetType().Name} ");
                throw new ArgumentException($"Invalid id: {request.Id}");
            }
        }

        public virtual async Task<int> Handle(TAddCommand request, CancellationToken cancellationToken)
        {
            T t = CreateItem(request);
            ctx.Add(t);
            await ctx.SaveChangesAsync();
            return t.Id;
        }


    }
}
