using LetsEat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsEat.DAL
{
    public interface IFamilyDAL
    {
        Family GetFamily(int familyId);
    }
}
