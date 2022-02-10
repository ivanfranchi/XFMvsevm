using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace XFMvsevm.Services
{
    public interface IScraperService
    {
        Task<IEnumerable<string>> ScrapeMvsevmAsync(CancellationToken cancellationToken);
    }
}
