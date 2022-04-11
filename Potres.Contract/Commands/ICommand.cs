using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Potres.Contracting.Commands
{
  public interface ICommand : IRequest
  {

  }
  public interface ICommand<T> : IRequest<T>
  {
  }
}
