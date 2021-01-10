using DRS.Is.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRS.Is.Concrete
{
    public static class HataYonetimi
    {
        public static void HataYakala(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (SameDataException exception)
            {
                throw new SameDataException();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}
