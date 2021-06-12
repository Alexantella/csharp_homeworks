``` ini

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19041.985 (2004/May2020Update/20H1)
Intel Celeron CPU N3350 1.10GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=5.0.201
  [Host]     : .NET Core 3.1.13 (CoreCLR 4.700.21.11102, CoreFX 4.700.21.11602), X64 RyuJIT  [AttachedDebugger]
  DefaultJob : .NET Core 3.1.13 (CoreCLR 4.700.21.11102, CoreFX 4.700.21.11602), X64 RyuJIT


```
|                                      Method |     Mean |    Error |   StdDev |
|-------------------------------------------- |---------:|---------:|---------:|
|             DistanceWithPointClassFloatTest | 31.04 ns | 0.604 ns | 0.565 ns |
|           DistanceWithPointStructDoubleTest | 36.20 ns | 0.507 ns | 0.423 ns |
|            DistanceWithPointStructFloatTest | 32.26 ns | 0.703 ns | 0.691 ns |
| DistanceWithPointStructFloatWithoutSqrtTest | 34.71 ns | 0.327 ns | 0.363 ns |
