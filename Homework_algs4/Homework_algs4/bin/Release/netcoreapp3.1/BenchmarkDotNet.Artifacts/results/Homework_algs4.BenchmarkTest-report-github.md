``` ini

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19041.985 (2004/May2020Update/20H1)
Intel Celeron CPU N3350 1.10GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=5.0.201
  [Host]     : .NET Core 3.1.13 (CoreCLR 4.700.21.11102, CoreFX 4.700.21.11602), X64 RyuJIT  [AttachedDebugger]
  DefaultJob : .NET Core 3.1.13 (CoreCLR 4.700.21.11102, CoreFX 4.700.21.11602), X64 RyuJIT


```
|        Method |        Mean |     Error |    StdDev |
|-------------- |------------:|----------:|----------:|
| FindInHashSet |    24.24 ns |  0.472 ns |  0.442 ns |
|   FindInArray | 2,421.54 ns | 28.643 ns | 26.793 ns |
