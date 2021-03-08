using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Model;

namespace BusinessLogic.Interface
{
    public interface ElectionInterface
    {
        List<ElectionModel> listMember();
        int Add(ElectionModel model);
        int delete(int e_id);
        int update(ElectionModel model);
    }
}
