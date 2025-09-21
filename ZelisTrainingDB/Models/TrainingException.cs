using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZelisTrainingDB.Models
{
    public class TrainingException: Exception
    {
        public TrainingException(string message) : base(message) { }

    }
}
