using Solution.BracketValidation;
using Solution.BrowserHistory;
using Solution.Palindrome;
using System;

namespace Solution;

internal class Program
{

    private static void JalankanBrowserHistory()
    {
        var history = new HistoryManager();
        history.KunjungiHalaman("google.com");
        history.KunjungiHalaman("example.com");
        history.KunjungiHalaman("stackoverflow.com");

        Console.WriteLine($"Halaman saat ini: {history.LihatHalamanSaatIni()}");

        Console.WriteLine("Kembali ke halaman sebelumnya...");
        Console.WriteLine($"Halaman saat ini: {history.Kembali()}");

        history.TampilkanHistory();
    }

    private static void JalankanBracketValidator()
    {
        var validator = new BracketValidator();
        TestBracket(validator, "[{}](){}");          // Valid
        TestBracket(validator, "([]{[]})[]{{}()}");  // Valid
        TestBracket(validator, "(]");                // Invalid
        TestBracket(validator, "([)]");              // Invalid
        TestBracket(validator, "{[}");               // Invalid
        TestBracket(validator, "");                  // Valid
    }

    private static void TestBracket(BracketValidator validator, string ekspresi)
    {
        Console.WriteLine($"Ekspresi '{ekspresi}' valid? {validator.ValidasiEkspresi(ekspresi)}");
    }

    private static void JalankanPalindromeChecker()
    {
        TestPalindrome("Kasur ini rusak");         // true
        TestPalindrome("Ibu Ratna antar ubi");     // true
        TestPalindrome("Hello World");             // false
        TestPalindrome("A man, a plan, a canal: Panama");  // true
        TestPalindrome("");                        // true
    }

    private static void TestPalindrome(string input)
    {
        Console.WriteLine($"\"{input}\" => {PalindromeChecker.CekPalindrom(input)}");
    }
}
