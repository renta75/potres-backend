using System;
using System.Collections.Generic;
using System.Text;

namespace Potres.Contracting.Commands
{
  public abstract class UpdateCommand : ICommand
  {
    public int Id { get; set; }
  }
}
