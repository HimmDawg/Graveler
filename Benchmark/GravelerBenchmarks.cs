using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using Perfolizer.Mathematics.OutlierDetection;

namespace Graveler.Benchmark;

[MemoryDiagnoser]
[Config(typeof(TinyBenchmarkConfig))]
public class GravelerBenchmarks
{
    private class TinyBenchmarkConfig : ManualConfig
    {
        public TinyBenchmarkConfig()
        {
            AddJob(new Job()
                .WithWarmupCount(1)
                .WithMaxIterationCount(3)
                .WithMinIterationCount(1)
                .WithOutlierMode(OutlierMode.DontRemove));
        }
    }

    private GravelerCalculator _calculator;

    [Params(1_000_000_000)]
    public int Count;

    [GlobalSetup]
    public void Setup()
    {
        _calculator = new GravelerCalculator(new Random(42));
    }

    [Benchmark]
    public async Task<(int, int)> GravelerParallel()
    {
        return await _calculator.GravelerParallel(Count);
    }
}
