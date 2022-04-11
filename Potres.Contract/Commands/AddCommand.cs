using System;
using System.Collections.Generic;
using System.Text;

namespace Potres.Contracting.Commands
{
  /// <summary>
  /// Generic add command that returns integer PK of inserted item
  /// </summary>
  public abstract class AddCommand : ICommand<int>
  {    
  }
}
