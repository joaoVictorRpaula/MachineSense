using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator.Model
{
    public class ResultData
    {
        public int IdResult { get; set; }
        public DateTime ResultDate { get; set; }
        public string MachineName { get; set; }
        public int AngleResult { get; set; }
        public int AngleUpperTol { get; set; }
        public int AngleLowerTol { get; set; }
        public int DiameterResult { get; set; }
        public int DiameterUpperTol { get; set; }
        public int DiameterLowerTol { get; set; }

        public override string ToString()
        {
            return  $"IdResult: {IdResult}\n" +
                    $"ResultDate: {ResultDate}\n" +
                    $"MachineName: {MachineName}\n" +
                    $"AngleResult: {AngleResult}\n" +
                    $"AngleUpperTol: {AngleUpperTol}\n" +
                    $"AngleLowerTol: {AngleLowerTol}\n" +
                    $"DiameterResult: {DiameterResult}\n" +
                    $"DiameterUpperTol: {DiameterUpperTol}\n" +
                    $"DiameterLowerTol: {DiameterLowerTol}";
        }
    }
}
