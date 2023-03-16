using AS400Project.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS400Project.Services
{
    public class ExternalRepository: IExternalRepository<PrdCovP>
    {
        public async Task<List<PrdCovP>> ReadAllAsync(bool tracking = true) { }
    }
}
