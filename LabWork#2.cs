void CreateComplexNumber(ref ComplexNuber number)
{
    Console.WriteLine("Enter complex part: ");
    number.complex = Convert.ToDouble(Console.ReadLine());
    Console.WriteLine("Enter imaginary part: ");
    number.imaginary = Convert.ToDouble(Console.ReadLine());
    Console.WriteLine("Excellent!\n");
}
void ShowComplexNumber (ref ComplexNuber number, string firstPartWriteLine = "Your complex number")
{
    if (number.imaginary > 0) Console.WriteLine($"{firstPartWriteLine} : {number.complex} + {number.imaginary}i\n");
    else if (number.imaginary < 0) Console.WriteLine($"{firstPartWriteLine}: {number.complex} - {Math.Abs(number.imaginary)}i\n");
    else Console.WriteLine($"{firstPartWriteLine}: {number.complex}\n");
}
void AddComplexNumber(ref ComplexNuber number, ref ComplexNuber secNumber)
{
    Console.WriteLine("Enter second summand: ");
    Console.WriteLine("Complex part: ");
    secNumber.complex = Convert.ToDouble(Console.ReadLine());
    Console.WriteLine("Imaginary part: ");
    secNumber.imaginary = Convert.ToDouble(Console.ReadLine());

    number.complex += secNumber.complex;
    number.imaginary += secNumber.imaginary;
    ShowComplexNumber(ref number, "The result of the addition\n");
}
void SubstructComplexNumber(ref ComplexNuber number, ref ComplexNuber secNumber)
{
    Console.WriteLine("Enter second summand: ");
    Console.WriteLine("Complex part: ");
    secNumber.complex = Convert.ToDouble(Console.ReadLine());
    Console.WriteLine("Imaginary part: ");
    secNumber.imaginary = Convert.ToDouble(Console.ReadLine());

    number.complex -= secNumber.complex;
    number.imaginary -= secNumber.imaginary;
    ShowComplexNumber(ref number, "The result of the substruction\n");
}
void MultiplyComplexNumber(ref ComplexNuber number, ref ComplexNuber secNumber)
{
    Console.WriteLine("Enter second summand: ");
    Console.WriteLine("Complex part: ");
    secNumber.complex = Convert.ToDouble(Console.ReadLine());
    Console.WriteLine("Imaginary part: ");
    secNumber.imaginary = Convert.ToDouble(Console.ReadLine());

    double saveComp;
    saveComp = number.complex * secNumber.complex - number.imaginary * secNumber.imaginary;
    number.imaginary = number.complex * secNumber.imaginary + number.imaginary * secNumber.complex;
    number.complex = saveComp;
    ShowComplexNumber(ref number, "The result of the multiplication\n");
}
void DivideComplexNumber(ref ComplexNuber number, ref ComplexNuber secNumber)
{
    Console.WriteLine("Enter second summand: ");
    Console.WriteLine("Complex part: ");
    secNumber.complex = Convert.ToDouble(Console.ReadLine());
    Console.WriteLine("Imaginary part: ");
    secNumber.imaginary = Convert.ToDouble(Console.ReadLine());
    if (secNumber.complex == 0 && secNumber.imaginary == 0)
    {
        Console.WriteLine("Error, division by zero");
        return;
    }
    double saveComp;
    saveComp = (number.complex * secNumber.complex + number.imaginary * secNumber.imaginary)
        /(Math.Pow(secNumber.complex, 2) + Math.Pow(secNumber.imaginary, 2));
    number.imaginary = (number.imaginary * secNumber.complex - number.complex * secNumber.imaginary)
        / (Math.Pow(secNumber.complex, 2) + Math.Pow(secNumber.imaginary, 2));
    number.complex = saveComp;
    ShowComplexNumber(ref number, "The result of the multiplication\n");
}
double GetAbsolutionValue(ref ComplexNuber number)
{
    return Math.Sqrt(Math.Pow(number.complex, 2) + Math.Sqrt(Math.Pow(number.imaginary, 2)));
}
void GetArgument(ref ComplexNuber number)
{
    if (number.complex > 0) Console.WriteLine($"Argument: {Math.Atan(number.imaginary / number.complex)}\n");
    else if (number.complex < 0 && number.imaginary >= 0) Console.WriteLine($"Argument: pi + " +
        $"{Math.Atan(number.imaginary / number.complex)}\n");
    else if (number.complex < 0 && number.imaginary < 0) Console.WriteLine($"Argument: -pi + " +
       $"{Math.Atan(number.imaginary / number.complex)}\n");
    else if (number.complex == 0 && number.imaginary > 0) Console.WriteLine("Argument: pi/2\n");
    else if (number.complex == 0 && number.imaginary < 0) Console.WriteLine("Argument: -pi/2\n");
}
void GetPartOfComplexNumber(ref ComplexNuber number)
{
    try
    {
        Console.WriteLine("Which part of complex number you want to get:\n\ta) complex\n\tb)imaginaty" +
            "\n*enter 'a' or 'b' *");
        char CompOrImag = Convert.ToChar(Console.Read());
        if (CompOrImag == 'a') Console.WriteLine($"Complex part: {number.complex}\n");
        else if (CompOrImag == 'b') Console.WriteLine($"Imaginary part: {number.imaginary}\n");
    }
    catch
    {
        Console.WriteLine("Enter error, please try again\n");
    }
}
void ShowHelpMenu()
{
    Console.WriteLine("List of commands:\na) Create complex number\nb) Addition\nc) Substruction\n" +
        "d) Multiplication\ne) Division\nf) Absolution\ng) Argument\nh) Get Complex or Imaginary part\n" +
        "i) Show your complex number\nj) Show help menu\n\t*for quite enter Q or q *\n");
}
ComplexNuber myNumber = new ComplexNuber();
ComplexNuber mySecNumber = new ComplexNuber();
myNumber.complex = 0; myNumber.imaginary = 0;
mySecNumber.complex = 0; mySecNumber.imaginary = 0;

string enterSign;
ShowHelpMenu();
while (true)
{
    try
    {
        enterSign = (Convert.ToString(Console.ReadLine())).ToLower();
    }
    catch
    {
        Console.WriteLine("Enter error, please try again\n");
        continue;
    }
    
    switch (enterSign)
    {
        case "a":
            CreateComplexNumber(ref myNumber); 
            break;
        case "b":
            AddComplexNumber(ref myNumber, ref mySecNumber);
            break;
        case "c":
            SubstructComplexNumber(ref myNumber, ref mySecNumber);
            break;
        case "d":
            MultiplyComplexNumber(ref myNumber, ref mySecNumber);
            break;
        case "e":
            DivideComplexNumber(ref myNumber, ref mySecNumber);
            break;
        case "f":
            GetAbsolutionValue(ref myNumber);
            break;
        case "g":
            GetArgument(ref myNumber);
            break;
        case "h":
            GetPartOfComplexNumber(ref myNumber);
            break;
        case "i":
            ShowComplexNumber(ref myNumber);
            break;
        case "j":
            ShowHelpMenu();
            break;
        case "q":
            return;
        default: 
            Console.WriteLine("Unknown command");
            break;
    }
}
struct ComplexNuber
{
    public double complex;
    public double imaginary;
}