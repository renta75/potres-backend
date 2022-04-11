using System;

namespace Potres.AuditLogging
{
  public interface IUserResolverService
  {
    string GetCurrentUserName();
  }
}
