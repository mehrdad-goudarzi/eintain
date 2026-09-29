# Entain
Downloading multiple pages asynchronously.

[![.NET](https://github.com/mehrdad-goudarzi/eintain/actions/workflows/dotnet.yml/badge.svg)](https://github.com/mehrdad-goudarzi/eintain/actions/workflows/dotnet.yml)

### Asynchronous processing:

Built-in object of .net called [ActionBlock](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.dataflow.actionblock-1?view=net-11.0-pp) is taking care of running many tasks in parallel and in a asynchronous way.


#### IO-Bound
The task is IO-Bound and threads will be hanging most of the time until the network IO is finished, therefore the level of parallelism can be configured reletively high.


[Considerations](docs/considerations.md)

[Show cases](docs/showcases.md)
