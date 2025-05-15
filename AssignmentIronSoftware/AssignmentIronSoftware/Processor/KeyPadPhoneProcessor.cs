namespace AssignmentIronSoftware.Processor;

public static class KeyPadPhoneProcessor
{
    // This dictionary maps the number keys to their corresponding letters.
    private static readonly Dictionary<char, string> _keypad = new Dictionary<char, string>
    {
        {'0', " "},
        {'1', "&'("},
        {'2', "abc"},
        {'3', "def"},
        {'4', "ghi"},
        {'5', "jkl"},
        {'6', "mno"},
        {'7', "pqrs"},
        {'8', "tuv"},
        {'9', "wxyz"}
    };
    public static string OldPhonePad(string input)
    {
        List<char> result = new List<char>();
        char? previousChar = null;
        var pressedCount = 0;
        foreach (char c in input)
        {
            // Count the number of times the same button is pressed
            if (previousChar == c) {
                pressedCount++;
            }
            else   {
                /*
                   if * is pressed, remove the last character from the result
                 */
                if (c == '*') {
                    if (previousChar == null)
                    {
                        if (result.Count > 0)
                        {
                            result.RemoveAt(result.Count - 1);
                        }
                    }
                    previousChar = null;
                    pressedCount = 0;
                }
                // if # is found, append previous character to result, and break the loop
                else if (c == '#') {
                    if (previousChar != null)
                    {
                        string letters = _keypad[(char)previousChar];
                        result.Add(letters[(pressedCount - 1) % letters.Length]);
                    }
                    break;
                }
                // Any digit pressed other than previous, append into the result.
                else if (previousChar >= '0' && previousChar <= '9') {
                    string letters = _keypad[(char)previousChar];
                    result.Add(letters[(pressedCount - 1) % letters.Length]);
                    previousChar = c == ' ' ? null : c;
                    pressedCount = c == ' ' ? 0 : 1;;
                }
                // after resetting the previousChar, if the current character is not a space, set it as previousChar
                else if(c != ' ')
                {
                    previousChar = c;
                    pressedCount = 1;
                }
            }
            
        }
        return new string(result.ToArray()).ToUpper();
    }
}