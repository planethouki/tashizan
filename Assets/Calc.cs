public class Calc
{
        public static string Input(string buttonName, string inputText)
        {
                string text;
                if (buttonName == "bs")
                {
                        int inputNumber = int.Parse(inputText);
                        inputNumber /= 10;
                        text = inputNumber.ToString();
                }
                else if (buttonName == "go")
                {
                        text = "0";
                }
                else
                {
                        int inputNumber = int.Parse(inputText);
                        inputNumber *= 10;
                        inputNumber += int.Parse(buttonName);
                        if (inputNumber > 999)
                        {
                                inputNumber %= 1000;
                        }

                        text = inputNumber.ToString();
                }

                return text;
        }
}