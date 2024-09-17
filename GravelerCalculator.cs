namespace Graveler;

public class GravelerCalculator(Random random)
{
	private readonly Random _random = random;

	// int.MaxValue / 4 pre-calc
	private const int _integerQuarter = 536870911; 

	// turns to survive: 231 => unroll factor 7 pre-calc
	private const int _unrolledTurnsToSurvive = 33;

	public async Task<(int, int)> GravelerParallel(int maxLoops)
	{
		Func<int, int> taskFunction = (unrolledTurnsToSurvive) =>
		{
			int ones = 0;
			for (int i = 0; i < unrolledTurnsToSurvive; i++)
			{
				int roll1 = _random.Next();
				int roll2 = _random.Next();
				int roll3 = _random.Next();
				int roll4 = _random.Next();
				int roll5 = _random.Next();
				int roll6 = _random.Next();
				int roll7 = _random.Next();
				if (roll1 <= _integerQuarter)
				{
					ones++;
				}
				if (roll2 <= _integerQuarter)
				{
					ones++;
				}
				if (roll3 <= _integerQuarter)
				{
					ones++;
				}
				if (roll4 <= _integerQuarter)
				{
					ones++;
				}
				if (roll5 <= _integerQuarter)
				{
					ones++;
				}
				if (roll6 <= _integerQuarter)
				{
					ones++;
				}
				if (roll7 <= _integerQuarter)
				{
					ones++;
				}
			}

			return ones;
		};

		int[] results = new int[maxLoops];
		int maxOnes = results
			.AsParallel()
			.Select(i => taskFunction(_unrolledTurnsToSurvive))
			.ToArray()
			.Max();

		return (maxOnes, maxLoops);
	}
}
