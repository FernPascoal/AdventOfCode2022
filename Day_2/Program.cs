#region "Read input file"
string textFile = "../../../Input.txt";
string[] lines = File.ReadAllLines(textFile);
#endregion
// ---Day 2: Rock Paper Scissors ---

int totalScore = 0;
int secondTotalScore = 0;

for (int i = 0; i < lines.Length; i++)
{
    string[] symbols = lines[i].Split(' ');

    Shape opponentShape = SymbolToShape(symbols.First());
    Shape yourShape = SymbolToShape(symbols.Last());

    totalScore += GetRoundOutcome(opponentShape, yourShape);
    secondTotalScore += GetSecondRoundOutcome(opponentShape, yourShape.YourSymbol);
}

Console.WriteLine($"What would your total score be if everything goes exactly according to your strategy guide?\nR: {totalScore}");
Console.WriteLine($"Following the Elf's instructions for the second column, what would your total score be if everything goes exactly according to your strategy guide?\nR: {secondTotalScore}");

// Part One
// Get your total score based on what you should play in response.

static int GetRoundOutcome(Shape opponentShape, Shape yourShape)
{
    if (opponentShape.Name == yourShape.Name)
    {
        return yourShape.DefaultScore + 3;
    }

    if (opponentShape.LoseTo == yourShape.Name)
    {
        return yourShape.DefaultScore + 6;
    }

    return yourShape.DefaultScore;
}

// Part Two
// Get your total score based on the desired result.

static int GetSecondRoundOutcome(Shape opponentShape, string yourSymbol)
{
    if ("Y".Equals(yourSymbol))
    {
        return opponentShape.DefaultScore + 3;
    }

    if ("Z".Equals(yourSymbol))
    {
        return GetWinnerDefaultScore(opponentShape.LoseTo) + 6;
    }

    return GetLoserDefaultScore(opponentShape.WinFrom);
}

static int GetWinnerDefaultScore(string winnerShape)
{
    return winnerShape switch
    {
        "Rock" => 1,
        "Paper" => 2,
        "Scissors" => 3,
        _ => throw new NotImplementedException(),
    };
}

static int GetLoserDefaultScore(string loserShape)
{
    return loserShape switch
    {
        "Rock" => 1,
        "Paper" => 2,
        "Scissors" => 3,
        _ => throw new NotImplementedException(),
    };
}

static Shape SymbolToShape(string symbol)
{
    return symbol switch
    {
        "A" or "X" => new Rock(),
        "B" or "Y" => new Paper(),
        "C" or "Z" => new Scissors(),
        _ => throw new NotImplementedException(),
    };
}

public class Rock : Shape
{
    public override string Name => "Rock";

    public override string WinFrom => "Scissors";

    public override string LoseTo => "Paper";

    public override string YourSymbol => "X";

    public override string OpponentSymbol => "A";

    public override int DefaultScore => 1;
}

public class Paper : Shape
{
    public override string Name => "Paper";

    public override string WinFrom => "Rock";

    public override string LoseTo => "Scissors";

    public override string YourSymbol => "Y";

    public override string OpponentSymbol => "B";

    public override int DefaultScore => 2;
}

public class Scissors : Shape
{
    public override string Name => "Scissors";

    public override string WinFrom => "Paper";

    public override string LoseTo => "Rock";

    public override string YourSymbol => "Z";

    public override string OpponentSymbol => "C";

    public override int DefaultScore => 3;
}

public abstract class Shape
{
    public abstract string Name { get; }
    public abstract string WinFrom { get; }
    public abstract string LoseTo { get; }
    public abstract string YourSymbol { get; }
    public abstract string OpponentSymbol { get; }
    public abstract int DefaultScore { get; }
}
