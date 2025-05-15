using AssignmentIronSoftware.Processor;

namespace AssignmentIronSoftware
{
    public class Program
    {
        public static void Main(params string[] args)
        {
            var results = new List<string>
            {
                KeyPadPhoneProcessor.OldPhonePad("33#"), // Sample Case 1: E
                KeyPadPhoneProcessor.OldPhonePad("227*#"), // Sample Case 2: B
                KeyPadPhoneProcessor.OldPhonePad("4433555 555666#"), // Sample Case 3: HELLO
                KeyPadPhoneProcessor.OldPhonePad("8 88777444666*664#"), // Sample Case 4: TURING

                KeyPadPhoneProcessor.OldPhonePad("22222#"), // Edge Case 1: B (Circulate when pressed > 3 times)

                KeyPadPhoneProcessor
                    .OldPhonePad(
                        "22***2225#"), // Edge Case 2: CJ (Do not remove next letters when extra backspace pressed before)

                KeyPadPhoneProcessor
                    .OldPhonePad(
                        "***2225#"), // Edge Case 3: CJ (Do not remove next letters when extra backspace pressed before)
                KeyPadPhoneProcessor
                    .OldPhonePad("**#"), // Edge Case 4: (Empty output when only backspace but no other key pressed)
                KeyPadPhoneProcessor.OldPhonePad("#"), // Edge Case 5: (Empty output when nothing pressed.)
                KeyPadPhoneProcessor
                    .OldPhonePad("22#33445"), // Edge Case 6: B (Skip handling characters after # symbol.)
                KeyPadPhoneProcessor.OldPhonePad(
                    "8   887  7744   466 6*664#"), // Edge Case 6: TUPQHGNNG (handling extra spaces)
            };

            results.ForEach(result => Console.WriteLine("Output: " + result));
        }
    }
}