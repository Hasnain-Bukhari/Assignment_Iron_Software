## Overview
This solution repository includes,
- Solution class `KeyPadPhoneProcessor.cs` containing the implementation of method `OldPhonePad(string)`.
- The `Program.cs` file to debug the `KeyPadPhoneProcessor.OldPhonePad(string)` method using Console.
- The `Tests` project for unit tests.
    - The `KeyPadPhoneProcessorTest.cs` file contains unit tests of a different scenarios including happy, unhappy and some edge cases.

## Methods
```cs
KeyPadPhoneProcessor.OldPhonePad(input)
```
This static method takes string as input. Calculates and returns the output as uppercase-alpha-string. i.e, ABC.

## Solution
1. At first keep the digit to letters mapping in a Dictionary.
    ***_keypad***: *Dictionary<char, string>*  <br>
    `0 -> ' '` <br>
    `1 -> &'( `<br>
    `2 -> abc` <br>
    `3 -> def `<br>
    `4 -> ghi `<br>
    `5 -> jkl` <br>
    `6 -> mno `<br>
    `7 -> pqrs`<br>
    `8 -> tuv` <br>
    `9 -> wxyz`<br>

2. Taking a variable ***result***:*List<char>*. 
Will parse the input string and add or remove *characters* from ***result***. 
The final value of ***result*** will be converted to string and return as expected output.

3. Travarse each digit in the `input` string once. 
    Count the consecutive repeated character by using ***pressedCount***:*int* while looping through each input character.
4. When the character is not a repeat to the previous character,
    Handle the *pressed count of the previous digit* and choose the appropriete letter from the ***_keypad***: *Dictionary*.
    ```cs
    string letters = _keypad[(char)previousChar];
    result.Add(letters[(pressedCount - 1) % letters.Length]);
    ```
    i.e, for 22234\*#, when coming to the 222<u>**3**</u>4\*# index, the previous digit is 2 and pressed count is 3. So, from `abc`, 3rd letter (index 2) will be chosen.

    When the previous character is <b>\*</b> (backspace). Remove characters from the end of ***result***:*List<char>*. 
    And the internal if condition making sure that there must be some value in result.
    The external if condition is making sure that previous character is either `*` or `' '`
    i.e if for the input 22*#, when comming to input the `*`, value is not added to result but pressed counter of 2 will be 2, In this case, main if block will not be executed and counter `pressedCount` will be reset and `prevousChar` will also be reset
    ```cs
    if (previousChar == null)
    {
        if (result.Count > 0)
        {
            result.RemoveAt(result.Count - 1);
        }
    }
    previousChar = null;
    pressedCount = 0;
    ```
5. Now, reset the ***pressedCount***:*int* to 1 for every new character apart from `0`, `' '` and `*`(for these case, ***pressedCount***:*int* to 0).
6. When a space `(' ')` is found, it will automatically handle the previous character streak and continue to the next character travarsal.
7. When a `#` is found, it will check the previous char and pressed count and add in the list and break the loop considering `#` as the last character in the input.
i.e, for 223#56, when coming to 223<u>**#**</U>56 index, the loop will break. So, ***result***:List<char> = *BD*.

## Solution Complexity
##### Space Complexity: O(N) 
- Using a constant Dictionary ***_keypad***: *Dictionary*. **O(1)**
- Using ***result***:*List<char>* to store the output. **O(N)**
##### Time Complexity: O(N)
- Complexity of accessing a value by key in ***_keypad***: *Dictionary* is constant. **O(1)**
- Travarsing through each characters in the input once. **O(N)**

## Test Coverage
* Correct Result On Exanple Unit Tests
    `33#` -> `E`
    `227*#` -> `B`
    `4433555 555666#` -> `HELLO`
    `8 88777444666*664#` -> `TURING`
* 1st Letter On Single Button press
    `0#` -> ` `
    `1#` -> `&`
    `2#` -> `A`
    `3#` -> `D`
    `4#` -> `G`
    `5#` -> `J`
    `6#` -> `M`
    `7#` -> `P`
    `8#` -> `T`
    `9#` -> `W`
* 2nd Letter On Twice Button press
    `00#` -> ` `
    `11#` -> `'`
    `22#` -> `B`
    `33#` -> `E`
    `44#` -> `H`
    `55#` -> `K`
    `66#` -> `N`
    `77#` -> `Q`
    `88#` -> `U`
    `99#` -> `X`
* 3rd Letter On Trice Button press
    `000#` -> ` `
    `111#` -> `(`
    `222#` -> `C`
    `333#` -> `F`
    `444#` -> `I`
    `555#` -> `L`
    `666#` -> `O`
    `777#` -> `R`
    `888#` -> `V`
    `999#` -> `Y`
* 4th Letter On 4 Times Button press
    `7777#` -> `S`
    `9999#` -> `Z`
* Circulated Letter On 5 times Button press
    `00000#` -> ` `
    `11111#` -> `'`
    `22222#` -> `B`
    `33333#` -> `E`
    `44444#` -> `H`
    `55555#` -> `K`
    `66666#` -> `N`
    `77777#` -> `P`
    `88888#` -> `U`
    `99999#` -> `W`
* Proper Result On Backspace Press`22 2225#` -> `BCJ`
    `22 2225*#` -> `BC`
    `22 2225**#` -> `B`
    `22***2225#` -> `CJ`
    `***2225#` -> `CJ`
    `22 2225***#` -> `
    `22 2225****#` -> `
    `22*222*5*#` -> `
    `***#` -> `
* Empty Result On No Button Press
    `#` -> `
* Skip Handling Characters After Hash Symbol In The Input
    `22#33445` -> `B`
* Handle Extra Spaces In The Input
    `"8   887  7744   466 6*664#"` -> `TUPQHGNNG`