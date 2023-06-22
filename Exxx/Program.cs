using Exxx;
using System;
using System.Collections.Generic;
using System.Text;


/*(int, int, int) c = Utils.GetConstants("00111110001000000000000000000000");

Console.WriteLine(Utils.GetNumberFromConstants(c));*/

/*var value = 5.646587687f;

Console.WriteLine(Utils.ToBinaryString(value));*/


var pathToLE = Path.Combine(Environment.CurrentDirectory, "polynomTest2LE.dat");
var bytesLE = HornerAlgorithmExam.Bytes(pathToLE);
var arrLE = HornerAlgorithmExam.BytesToArrayOfDouble(bytesLE);
(double[] arguments, double[] coefficients) argCoeffLE = HornerAlgorithmExam.CoefficientsAndArgsLittleEnding(arrLE);
foreach (double num in argCoeffLE.arguments)
{
    Console.WriteLine(num);
}
Console.WriteLine();
foreach (double num in argCoeffLE.coefficients)
{
    Console.WriteLine(num);
}

Console.WriteLine();


foreach (double num in argCoeffLE.arguments)
{
    /*Console.WriteLine(HornerAlgorithmExam.HornerAlgorithm(argCoeffLE.coefficients, num));
    Console.WriteLine(HornerAlgorithmExam.PosterioriError(argCoeffLE.coefficients, num));*/
    Console.WriteLine(HornerAlgorithmExam.PolynomialValue(argCoeffLE.coefficients, num));
    Console.WriteLine(HornerAlgorithmExam.PosterioriError(argCoeffLE.coefficients, num));
    Console.WriteLine(HornerAlgorithmExam.AprioriError(argCoeffLE.coefficients, num));
    Console.WriteLine();
}







/*var pathToBE = Path.Combine(Environment.CurrentDirectory, "polynomTest1BE.dat");
var bytesBE = HornerAlgorithmExam.Bytes(pathToBE);
var newBytesBE = Enumerable.Reverse(bytesBE).ToArray();
var arrBE = HornerAlgorithmExam.BytesToArrayOfDouble(newBytesBE);
foreach (var item in arrBE)
{
    Console.WriteLine(item);
}
Console.WriteLine();
(double[], double[]) argCoeffBE = HornerAlgorithmExam.CoefficientsAndArgsLittleEnding(arrBE);
foreach (double num in argCoeffBE.Item1)
{
    Console.WriteLine(num);
}
Console.WriteLine();
foreach (double num in argCoeffBE.Item2)
{
    Console.WriteLine(num);
}*/




/*var a = new[] { 2.0, 3.0, 4.0 };
Console.WriteLine(HornerAlgorithmExam.HornerAlgorithm(a, 3));*/


/*var a = new[] { 2.0, 3.0, 4.0 };
Console.WriteLine(HornerAlgorithmExam.PolynomialValue(a, 3));
Console.WriteLine(HornerAlgorithmExam.PosterioriError(a, 3));
Console.WriteLine(HornerAlgorithmExam.AprioriError(a, 3));


/*var listLE = new List<double>();
var listBE = new List<double>();


int n = 60;
using (BinaryReader reader = new BinaryReader(File.Open("polynomTest2LE.dat", FileMode.Open)))
{
    for (int i = 0; i < n; i++)
    {
        double num = reader.ReadDouble();
        
        Console.WriteLine($"{num}");
        listLE.Add(num);
        
    }
}

Console.WriteLine();


(double[], double[]) arr = HornerAlgoExam.CoefficientsAndArgsLittleEnding(listLE.ToArray());

foreach (double num in arr.Item1)
{
    Console.WriteLine(num);
}

Console.WriteLine();

foreach (double num in arr.Item2)
{
    Console.WriteLine(num);
}*/











/*int n = 4;
using (BinaryReader reader = new BinaryReader(File.Open("polynomTest1BE.dat", FileMode.Open)))
{
    for (int i = 0; i < n; i++)
    {
        double num = reader.ReadDouble();
        if (i < n / 2)
        {
            Console.WriteLine($"{num}");
            list1LE.Add(num);
        }
        else
        {
            Console.WriteLine($"{num}");
            list2LE.Add(num);
        }
    }
}
*/


