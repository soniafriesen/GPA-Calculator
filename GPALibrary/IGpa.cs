using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
/*
 * Project: Final Practical WPF
 * Purpose: Demonstrate learning and understanding of WPF
 * Coder: Sonia Friesen, 0813682        
 * Date: April 19th 2021
 */
namespace GpaCalculatorLibrary
{
    [ServiceContract]
    public interface IGpa
    {
        [OperationContract]
        double CalcCredits();
        [OperationContract]
        double CalcGpa();
        [OperationContract]
        Course AddCourse(string code, double credits, string letter);
        string Student { [OperationContract] get; [OperationContract] set; }
        int CourseCount { [OperationContract] get; }

    }
}
