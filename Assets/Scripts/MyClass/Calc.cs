public class Calc
{
        public static string Input(string buttonName, string inputText)
        {
                int inputNumber = int.Parse(inputText);
                inputNumber *= 10;
                inputNumber += int.Parse(buttonName);
                if (inputNumber > 999)
                {
                        inputNumber %= 1000;
                }

                var text = inputNumber.ToString();

                return text;
        }
}