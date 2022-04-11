namespace Potres.Contracting.Commands
{
  /// <summary>
  /// Generic delete command
  /// Returns true if item does not exists. Exceptions should not be handled.
  /// </summary>
  public abstract class DeleteCommand : ICommand
  {
    public int Id { get; set; }
  }
}
