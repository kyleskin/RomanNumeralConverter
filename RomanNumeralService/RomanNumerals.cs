namespace RomanNumeralService;

public static class RomanNumerals
{
    private enum RomanNumeral
    {
        I = 1,
        V = 5,
        X = 10,
        L = 50,
        C = 100,
        D = 500,
        M = 1000
    }
    
    private static RomanNumeral AsRomanNumeral(this char numeral)
    {
        if (!Enum.TryParse(numeral.ToString(), out RomanNumeral numeralAsEnum))
            throw new ArgumentOutOfRangeException(nameof(numeral), $"{numeral} is not a valid Roman Numeral");

        return numeralAsEnum;
    }
    
    public static int ConvertRomanNumeral(string? romanNumeral)
    {
        if (string.IsNullOrEmpty(romanNumeral))
            throw new ArgumentNullException(romanNumeral);
 
        var numerals = romanNumeral.Select(numeral => numeral.AsRomanNumeral()).ToList();
        var result = 0;
        
        for (var idx = 0; idx < numerals.Count; idx++)
        {
            var numeral = numerals[idx];
            
            // Have to check if there is a next numeral, and, if it's larger than the current,
            // subtract the current numeral's value
            if (idx + 1 < numerals.Count)
            {
                if (numeral < numerals[idx + 1])
                {
                    result -= (int)numeral;
                    continue;
                }
            }
            
            result += (int)numeral;
        }

        return result;
    }
}