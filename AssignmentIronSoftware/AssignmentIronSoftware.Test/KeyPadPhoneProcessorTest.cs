using AssignmentIronSoftware.Processor;
using Xunit;

namespace AssignmentIronSoftware.Test;

public class KeyPadPhoneProcessorTest
{
    [Fact]
    public void ShouldReturnCorrectResultOnSampleUnitTests()
    {
        Assert.Equal(actual: KeyPadPhoneProcessor.OldPhonePad("33#"), expected: "E");
        Assert.Equal(actual: KeyPadPhoneProcessor.OldPhonePad("227*#"), expected: "B");
        Assert.Equal(actual: KeyPadPhoneProcessor.OldPhonePad("4433555 555666#"), expected: "HELLO");
        Assert.Equal(actual: KeyPadPhoneProcessor.OldPhonePad("8 88777444666*664#"), expected: "TURING");
    }

    [Fact]
    public void ShouldReturn1stLetterOnSingleButtonPress()
    {
        Assert.Equal(actual: KeyPadPhoneProcessor.OldPhonePad("0#"), expected: " ");
        Assert.Equal(actual: KeyPadPhoneProcessor.OldPhonePad("1#"), expected: "&");
        Assert.Equal(actual: KeyPadPhoneProcessor.OldPhonePad("2#"), expected: "A");
        Assert.Equal(actual: KeyPadPhoneProcessor.OldPhonePad("3#"), expected: "D");
        Assert.Equal(actual: KeyPadPhoneProcessor.OldPhonePad("4#"), expected: "G");
        Assert.Equal(actual: KeyPadPhoneProcessor.OldPhonePad("5#"), expected: "J");
        Assert.Equal(actual: KeyPadPhoneProcessor.OldPhonePad("6#"), expected: "M");
        Assert.Equal(actual: KeyPadPhoneProcessor.OldPhonePad("7#"), expected: "P");
        Assert.Equal(actual: KeyPadPhoneProcessor.OldPhonePad("8#"), expected: "T");
        Assert.Equal(actual: KeyPadPhoneProcessor.OldPhonePad("9#"), expected: "W");
    }


    [Fact]
    public void ShouldReturn2ndLetterOnTwiceButtonPress()
    {
        Assert.Equal(actual: KeyPadPhoneProcessor.OldPhonePad("00#"), expected: " ");
        Assert.Equal(actual: KeyPadPhoneProcessor.OldPhonePad("11#"), expected: "'");
        Assert.Equal(actual: KeyPadPhoneProcessor.OldPhonePad("22#"), expected: "B");
        Assert.Equal(actual: KeyPadPhoneProcessor.OldPhonePad("33#"), expected: "E");
        Assert.Equal(actual: KeyPadPhoneProcessor.OldPhonePad("44#"), expected: "H");
        Assert.Equal(actual: KeyPadPhoneProcessor.OldPhonePad("55#"), expected: "K");
        Assert.Equal(actual: KeyPadPhoneProcessor.OldPhonePad("66#"), expected: "N");
        Assert.Equal(actual: KeyPadPhoneProcessor.OldPhonePad("77#"), expected: "Q");
        Assert.Equal(actual: KeyPadPhoneProcessor.OldPhonePad("88#"), expected: "U");
        Assert.Equal(actual: KeyPadPhoneProcessor.OldPhonePad("99#"), expected: "X");
    }

    [Fact]
    public void ShouldReturn3rdLetterOnTriceButtonPress()
    {
        Assert.Equal(actual: KeyPadPhoneProcessor.OldPhonePad("000#"), expected: " ");
        Assert.Equal(actual: KeyPadPhoneProcessor.OldPhonePad("111#"), expected: "(");
        Assert.Equal(actual: KeyPadPhoneProcessor.OldPhonePad("222#"), expected: "C");
        Assert.Equal(actual: KeyPadPhoneProcessor.OldPhonePad("333#"), expected: "F");
        Assert.Equal(actual: KeyPadPhoneProcessor.OldPhonePad("444#"), expected: "I");
        Assert.Equal(actual: KeyPadPhoneProcessor.OldPhonePad("555#"), expected: "L");
        Assert.Equal(actual: KeyPadPhoneProcessor.OldPhonePad("666#"), expected: "O");
        Assert.Equal(actual: KeyPadPhoneProcessor.OldPhonePad("777#"), expected: "R");
        Assert.Equal(actual: KeyPadPhoneProcessor.OldPhonePad("888#"), expected: "V");
        Assert.Equal(actual: KeyPadPhoneProcessor.OldPhonePad("999#"), expected: "Y");
    }

    [Fact]
    public void ShouldReturn4thLetterOn4TimesButtonPress()
    {
        Assert.Equal(actual: KeyPadPhoneProcessor.OldPhonePad("7777#"), expected: "S");
        Assert.Equal(actual: KeyPadPhoneProcessor.OldPhonePad("9999#"), expected: "Z");
    }

    [Fact]
    public void ShouldReturnCirculatedLetterOn5TimesButtonPress()
    {
        Assert.Equal(actual: KeyPadPhoneProcessor.OldPhonePad("00000#"), expected: " ");
        Assert.Equal(actual: KeyPadPhoneProcessor.OldPhonePad("11111#"), expected: "'");
        Assert.Equal(actual: KeyPadPhoneProcessor.OldPhonePad("22222#"), expected: "B");
        Assert.Equal(actual: KeyPadPhoneProcessor.OldPhonePad("33333#"), expected: "E");
        Assert.Equal(actual: KeyPadPhoneProcessor.OldPhonePad("44444#"), expected: "H");
        Assert.Equal(actual: KeyPadPhoneProcessor.OldPhonePad("55555#"), expected: "K");
        Assert.Equal(actual: KeyPadPhoneProcessor.OldPhonePad("66666#"), expected: "N");
        Assert.Equal(actual: KeyPadPhoneProcessor.OldPhonePad("77777#"), expected: "P");
        Assert.Equal(actual: KeyPadPhoneProcessor.OldPhonePad("88888#"), expected: "U");
        Assert.Equal(actual: KeyPadPhoneProcessor.OldPhonePad("99999#"), expected: "W");
    }

    [Fact]
    public void ShouldReturnProperResultOnBackspacePress()
    {
        Assert.Equal(actual: KeyPadPhoneProcessor.OldPhonePad("22 2225#"), expected: "BCJ");
        Assert.Equal(actual: KeyPadPhoneProcessor.OldPhonePad("22 2225*#"), expected: "BC");
        Assert.Equal(actual: KeyPadPhoneProcessor.OldPhonePad("22 2225**#"), expected: "B");
        Assert.Equal(actual: KeyPadPhoneProcessor.OldPhonePad("22***2225#"), expected: "CJ");
        Assert.Equal(actual: KeyPadPhoneProcessor.OldPhonePad("***2225#"), expected: "CJ");
        Assert.Equal(actual: KeyPadPhoneProcessor.OldPhonePad("22 2225***#"), expected: "");
        Assert.Equal(actual: KeyPadPhoneProcessor.OldPhonePad("22 2225****#"), expected: "");
        Assert.Equal(actual: KeyPadPhoneProcessor.OldPhonePad("22*222*5*#"), expected: "");
        Assert.Equal(actual: KeyPadPhoneProcessor.OldPhonePad("***#"), expected: "");
    }

    [Fact]
    public void ShouldReturnEmptyResultOnNoButtonPress()
    {
        Assert.Equal(actual: KeyPadPhoneProcessor.OldPhonePad("#"), expected: "");
    }

    [Fact]
    public void ShouldSkipHandlingCharactersAfterHashSymbolInTheInput()
    {
        Assert.Equal(actual: KeyPadPhoneProcessor.OldPhonePad("22#33445"), expected: "B");
    }
    [Fact]
    public void ShouldHandleExtraSpacesInTheInput()
    {
        Assert.Equal(actual: KeyPadPhoneProcessor.OldPhonePad("8   887  7744   466 6*664#"), expected: "TUPQHGNNG");
    }
}